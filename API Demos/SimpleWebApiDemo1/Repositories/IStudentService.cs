using SimpleWebApiDemo1.Models;

namespace SimpleWebApiDemo1.Repositories
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public Student GetStudentsByName(string name);
        public List<Student> GetStudentByAge(int id);
        public List<Student> GetStudentByGenderAndCity(string gender, string city);
        public string UpdateStudent(Student student);
        public IEnumerable<Student> SearchStudents(StudentSearch studentSearch);
        public string DeleteStudent(int id);
        public Student GetStudent(int id);
        public int AddStudent(Student student);
    }
}
