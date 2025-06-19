using System.Text.Json.Serialization;

namespace SimpleWebApiDemo1.Models
{
    public class Course
    {
        [JsonRequired]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        [JsonRequired]
        public bool isActive { get; set; } = true;
        ICollection<Student> Students { get;set; }

    }
}
