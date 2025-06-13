using SimpleWebApiDemo1.Models;
using SimpleWebApiDemo1.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApiDemo1.Repositories
{
    public class CourseService : ICourseSevice
    {
        private readonly ApplicationContext _context;
        public CourseService(ApplicationContext context)
        {
            _context = context; 
        }

        public Course AddCourse(Course course)
        {
            try
            {
                if(course!=null)
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                    return course;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
        public string DeleteCourse(int id)
        {
            try
            {
                if (id >= 0)
                {
                    var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
                    if (course != null)
                    {
                        course.isActive = false;
                        _context.Entry(course).State = EntityState.Modified;
                        _context.SaveChanges();
                        return $" Given Course id {id} Removed from DB";
                    }
                    else
                    {
                        return $" The Given Id {id} does not exist.";
                    }
                }
                else
                    return "Id is not in correct format";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Course GetCourseById(int id)
        {
           var course=_context.Courses.Where(x => x.Id==id).FirstOrDefault();
            if (course != null)
                return course;
            else
                return null;
        }

        public List<Course> GetCourses()
        {
            var courseList = _context.Courses.ToList();
            if (courseList.Count > 0)
                return courseList;
            else
                return null;

        }

        public string UpdateCourse(int id,Course course)
        {
            if (id == course.Id)
            {

                var foundCourse = _context.Courses.Where(c => c.Id == course.Id).FirstOrDefault();
                if (foundCourse != null)
                {
                    foundCourse.CourseName = course.CourseName;
                    foundCourse.Duration = course.Duration;
                   // _context.Entry(course).State = EntityState.Modified;
                    _context.SaveChanges();
                    return "Record Updated";
                }

                else
                    return "The Course id Not Found in DB ";
            }
            else
                return " Id and Course.Id is does not Match";
       
        }
    }
}
