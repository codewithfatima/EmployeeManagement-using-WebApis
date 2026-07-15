using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagment.Data;
using StudentManagment.DTOs;
using StudentManagment.Interfaces;
using StudentManagment.Models;
using StudentManagment.Service;
using System.Threading.Tasks;

namespace StudentManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            await _service.CreateStudentAsync(dto);
            return Ok("Student created successfully!");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);

            if (student == null) return NotFound();

            return Ok(student);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, StudentUpdateDto dto)
        {
            await _service.UpdateStudentAsync(id, dto);
            return Ok("Student updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteStudentAsync(id);
            if (!deleted)
            {
                return NotFound($"Student with Id {id} not found.");
            }
            return Ok("Student Deleted Successfully");
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedStudentsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var students = await _service.GetPagedStudentsAsync(pageNumber, pageSize);
            return Ok(students);
        }

        [HttpGet("search")]

        public async Task<IActionResult> SearchAndFilterAsync(
            [FromQuery] string? search,
            [FromQuery] string? departmentName,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)

        {
            var students = await _service.SearchAndFilterStudentsAsync(search, departmentName, pageNumber, pageSize);
            return Ok(students);
        }

        //profilepicture
        [HttpPost("{id}/upload-picture")]
        public async Task<IActionResult> SetProfilePicturePathAsync(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadsFolder = Path.Combine("wwwroot", "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{id}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            await _service.SetProfilePicturePathAsync(id, $"/uploads/{fileName}");

            return Ok(new { message = "File uploaded successfully", path = $"/uploads/{fileName}" });

        }
    }
}