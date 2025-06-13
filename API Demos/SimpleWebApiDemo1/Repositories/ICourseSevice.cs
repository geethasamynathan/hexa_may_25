using SimpleWebApiDemo1.Models;

namespace SimpleWebApiDemo1.Repositories
{
    public interface ICourseSevice
    {
        public List<Course> GetCourses();
        public Course GetCourseById(int id);
        public string UpdateCourse(int id,Course course);
        public string DeleteCourse(int id);
        public Course AddCourse(Course course);
    }
}
