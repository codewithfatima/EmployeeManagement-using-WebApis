using StudentManagment.Models;

namespace StudentManagment.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        void Delete(Student student);
        void Update(  Student student);
        Task SaveChangesAsync();
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task <IEnumerable<Student>> GetPagedAsync(int pageNumber , int pageSize);
        Task<IEnumerable<Student>> SearchAndFilter(string? search, string? departmentName, int pageNumber, int pageSize);
        Task ProfilePicture(int id, string path);

    }
}
