using System.ComponentModel.DataAnnotations;
using StudentManagment.DTOs;


namespace StudentManagment.Models
{
    public class Student
    {
      public int Id { get; set; } 
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public DateOnly DateOfBirth { get; set; }


        // The Foreign Key: Tells the database exactly which Department this student belongs to
        public int DepartmentId { get; set; }

        // The Navigation Property: Allows you to say 'myStudent.Department.Name'
        public Department? Department { get; set; }
        public string? ProfilePicturePath { get; set; }

    }
}


