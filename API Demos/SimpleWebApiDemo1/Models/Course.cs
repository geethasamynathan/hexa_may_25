namespace SimpleWebApiDemo1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public bool isActive { get; set; } = true;
        ICollection<Student> Students { get;set; }

    }
}
