using Microsoft.AspNetCore.Http.HttpResults;
using SimpleWebApiDemo1.Models;

namespace SimpleWebApiDemo1.Repositories
{
    public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>()
        {
            //new Student(){StudentId=1,StudentEmail="Akshara@mail.com",StudentName="Akshara",Course="Azure",Age=23,Gender="Female",City="Chennai"},
            //new Student(){StudentId=2,StudentEmail="dharnish@mail.com",StudentName="Dharnish",Course="AWS",Age=19,Gender="Male",City="Bangalore"},
            //new Student(){StudentId=3,StudentEmail="Hanisha@mail.com",StudentName="Hanisha",Course="GCP",Age = 24,Gender="Female",City="Mumbai"},
            //new Student(){StudentId=4,StudentEmail="Nithya@mail.com",StudentName="Nithya",Course="React",Age=20,Gender="Female",City="Chennai"},
            //new Student(){StudentId=5,StudentEmail="Vivetha@mail.com",StudentName="Vivetha",Course="Data Science",Age=22,Gender="Female",City="Bangalore"},
            //new Student(){StudentId=6,StudentEmail="Raghav@mail.com",StudentName="Raghav",Course="Power BI",Age=22,Gender="Male",City="Mumbai"},
        };

        public int AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                return student.StudentId;
            }
            else
            return 0;
        }

        public string DeleteStudent(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
               if(student != null)
                {
                    students.Remove(student);
                return $"{student.StudentName} Removed";
                }
                else
                    return "Given id not present in DB";
            }
        

        public List<Student> GetAllStudents()
        {
           return students;
        }

        public Student GetStudent(int id)
        {
           var student=students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student == null)
                return null;
            return student;
        }

        public List<Student> GetStudentByAge(int age)
        {
            var studentlist = students.Where(s => s.Age == age).ToList();
            return studentlist;
        }

        public Student GetStudentsByName(string name)
        {
            var student = students.Where(s => s.StudentName.ToLower() == name.ToLower()).FirstOrDefault();
            return student;
        }
        public IEnumerable<Student> SearchStudents(StudentSearch studentSearch)
        {
            var filteredStudents=new List<Student>();

            if(!string.IsNullOrEmpty(studentSearch.Name))
            {
                filteredStudents=students.Where(s => s.StudentName.Equals(studentSearch.Name,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(studentSearch.Gender))
            {
                filteredStudents = students.Where(s => s.Gender.Equals(studentSearch.Gender, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(studentSearch.City))
            {
                filteredStudents = students.Where(s => s.City.Equals(studentSearch.City, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!filteredStudents.Any())
                return null;
            else
                return filteredStudents;


        }
        public List<Student> GetStudentByGenderAndCity(string gender, string city)
        {
            var filteredStudents=new List<Student>();
            if(!string.IsNullOrEmpty(gender))
            {
                filteredStudents= students.Where(s => s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if(!string.IsNullOrEmpty (city))
            {
                filteredStudents = students.Where(s => s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(city))
            {
                 filteredStudents = students.Where(s => s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if(!filteredStudents.Any())
            {
                return null;
            }
            else
            {
                return filteredStudents;
            }
        }
        public string UpdateStudent(Student student)
        {
            var index = students.FindIndex(s => s.StudentId == student.StudentId);
            if (index != -1) {
                students[index] = student;
                return "Record Updated";
            }
            
            else
                return "Record not updated";
        }
    }
}
