using Microsoft.EntityFrameworkCore;
using StudentManagment.Data;
using StudentManagment.Interfaces;
using StudentManagment.Models;


namespace StudentManagment.Repositories
{
    public class BookRepository:IBookRepository
    {
        //this layer will talk to db databse like_context EF Core, SQL.
        //It implements the promise made in IBookRepository
        //it doesnt care about business logic
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        => await _context.Books.Include(b=>b.Author).ToListAsync();

        public async Task AddAsync(Book book)
            => await _context.Books.AddAsync(book);

        public async Task<Book?> GetByIdAsync(int id)
            => await _context.Books.FindAsync(id); 
        public  void Delete(Book book)
            => _context.Books.Remove(book);
       
        public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    }
}
