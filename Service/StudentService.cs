using StudentManagment.DTOs;
using StudentManagment.Models;
using StudentManagment.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace StudentManagment.Service
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;


        public StudentService(IStudentRepository repository , ILogger<StudentService> logger)
        { 
            _repository = repository;
            _logger = logger;
        }

        //get all students
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            _logger.LogInformation("Fetching all students");
            return await _repository.GetAllStudentsAsync();
        }

        //create studenrt 
        public async Task CreateStudentAsync(StudentCreateDto studentCreateDto)
        {
            _logger.LogInformation("Creating student {FirstName} {LastName}", studentCreateDto.FirstName, studentCreateDto.LastName);

            var department = await _repository.GetDepartmentByNameAsync(studentCreateDto.DepartmentName);

            if (department == null)
            {
                _logger.LogWarning("Department {DepartmentName} not found", studentCreateDto.DepartmentName);
                throw new Exception($"Department '{studentCreateDto.DepartmentName}' not found.");
            }

            var student = new Student
            {
                FirstName = studentCreateDto.FirstName,
                LastName = studentCreateDto.LastName,
                Email = studentCreateDto.Email,
                DepartmentId = department.Id
            };

            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();
        }

        //GHet student by id 
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if(student == null) return null;

            return student;
        }

        //update existing student by ID 
        public async Task UpdateStudentAsync(int id , StudentUpdateDto dto)
        {
            _logger.LogInformation("Updating student information {FirstName} {LastName} {Email}", dto.FirstName, dto.LastName, dto.Email);

            var student  = await  _repository.GetByIdAsync(id);

            if(student != null)
            {
                student.FirstName = dto.FirstName;
                student.LastName = dto.LastName;
                student.Email = dto.Email;

                await _repository.SaveChangesAsync();
            };

        }

        //Delet student by id 
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student != null)
            {
                _logger.LogInformation("Deleting student with Id {Id}", id);
                _repository.Delete(student);
                await _repository.SaveChangesAsync();
                return true;
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent student with Id {Id}", id);
                return false;
            }

            
        }

        //page pangitation 
        public async Task<IEnumerable<Student>> GetPagedStudentsAsync(int pageNumber, int pageSize)
        {
            return await  _repository.GetPagedAsync(pageNumber , pageSize);
        }

        //searchandfilter
        public async Task<IEnumerable<Student>> SearchAndFilterStudentsAsync(string? search , string? departmentName , int pageNumber =  1 , int pageSize = 10)
        {
            return await _repository.SearchAndFilter(search, departmentName, pageNumber, pageSize);
        }

        //profile picture
        public async Task SetProfilePicturePathAsync(int id, string path)
        {
            await   _repository.ProfilePicture(id, path);
        }
    }
}






//A static variable lives in the computer's memory for as long as the application is running.
//If you didn't use static, your list of students would be wiped clean every single time you hit an endpoint.
//private static List<Student> _students = new List<Student>();