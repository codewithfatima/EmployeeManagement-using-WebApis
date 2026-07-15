using Microsoft.AspNetCore.Mvc;
using StudentManagment.DTOs;
using StudentManagment.Interfaces;
using StudentManagment.Service;

namespace StudentManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _service.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(BookCreateDto dto)
        {
            await _service.CreateBookAsync(dto);
            return Ok("Book Added Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            await _service.DeleteBookAsync(id);
            return Ok("Book has been deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            await _service.GetByIdAsync(id);
            return Ok();
        }

    }
}

