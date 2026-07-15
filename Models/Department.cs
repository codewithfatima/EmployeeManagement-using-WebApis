namespace StudentManagment.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // The collection: One department has many students
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
