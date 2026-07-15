using StudentManagment.Models;
namespace StudentManagment.DTOs
{
    public class StudentUpdateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? DepartmentName { get; set; }
    }
}
