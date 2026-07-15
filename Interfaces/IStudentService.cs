using StudentManagment.Models;
using StudentManagment.DTOs;

namespace StudentManagment.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task CreateStudentAsync(StudentCreateDto studentDto);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student?> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(int id , StudentUpdateDto dto);
        Task<IEnumerable<Student>> GetPagedStudentsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Student>> SearchAndFilterStudentsAsync(string? search , string? departmentName, int pageNumber, int pageSize);
        Task SetProfilePicturePathAsync(int id, string path);
    }
}
