using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebApiDemo1.Models
{
   // [Table("tblStudent")]
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        public string StudentEmail { get; set; }
        [Range(21,65,ErrorMessage ="Age between 21 to 65")]
        public int Age { get; set; }
        public string Gender { get;set; }
        public string City {  get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course? Course { get; set;}

    
    
    }
}
