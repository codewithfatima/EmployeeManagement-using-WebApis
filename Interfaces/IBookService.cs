using StudentManagment.DTOs;
using StudentManagment.Models;

namespace StudentManagment.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task CreateBookAsync(BookCreateDto dto);
        Task<bool> DeleteBookAsync(int id);
        Task<Book?> GetByIdAsync(int id);
    }   
}
