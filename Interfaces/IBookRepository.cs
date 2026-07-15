using StudentManagment.Models;

namespace StudentManagment.Interfaces
{
    public interface IBookRepository
    {
        //IIn interface there will be only the method name no implementation 
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);   
        void Delete(Book book);
        //void Update(Book book);
        Task SaveChangesAsync();
    }
}
