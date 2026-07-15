using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentManagment.Data;
using StudentManagment.Interfaces;
using StudentManagment.Models;

namespace StudentManagment.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(s => s.Department).ToListAsync();
        }
        public async Task<Student?> GetByIdAsync(int id)
            => await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student)
            => await _context.Students.AddAsync(student);

        public void Delete(Student student)
            =>  _context.Students.Remove(student);

        public void Update(Student student)
             => _context.Students.Update(student);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task<Department?> GetDepartmentByNameAsync(string name)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<IEnumerable<Student>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Students.Include(s => s.Department)
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
        }
           
        public async Task<IEnumerable<Student>> SearchAndFilter(string? search , string? departmentName , int pageNumber, int pageSize)
        {
            var query =  _context.Students.Include(s=> s.Department).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.FirstName.Contains(search) || s.LastName.Contains(search));
            }

            if (!string.IsNullOrEmpty(departmentName))
            {
                query = query.Where(s=>s.Department.Name == departmentName);
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task ProfilePicture(int id , string path)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                student.ProfilePicturePath = path;
                await _context.SaveChangesAsync();
            }
        }

    }
}
