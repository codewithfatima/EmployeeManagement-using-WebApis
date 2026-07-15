using StudentManagment.Interfaces;
using StudentManagment.Service;
using StudentManagment.Models;
using StudentManagment.DTOs;

namespace StudentManagment.Service
{
    public class BookService:IBookService
    {
        ///ob: the business logic / decision-making layer.
        ///This is where you'd put rules like "check if the author exists before creating a book"
       
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        //get all students
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllBooksAsync();
        }

        //add the books
        public async Task CreateBookAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId,
            };

            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }

        //delete the book with id 
        public async Task<bool> DeleteBookAsync(int id)
        {
            var books = await _repository.GetByIdAsync(id);
            if(books != null)
            {
                 _repository.Delete(books);
                await _repository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var findBook = await _repository.GetByIdAsync(id);
            return (findBook);
        }

    }
}
