using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApiDemo1.Models;
using SimpleWebApiDemo1.Repositories;

namespace SimpleWebApiDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseSevice _courseService;
        public CoursesController(ICourseSevice courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            try
            {
                var courses = _courseService.GetCourses();
                if (courses == null)
                {
                    return NotFound("No Courses Added ");
                }
                else
                    return Ok(courses);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetCourseById/{id:int}")]
        public IActionResult GetCourseById(int id)
        {
            try
            {
                var courses = _courseService.GetCourseById(id);
                if (courses == null)
                {
                    return NotFound($"No Courses found with the Given Id {id}");
                }
                else
                    return Ok(courses);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost("createCourse")]
        public IActionResult Create(Course course)
        {
            try
            {
                var courses = _courseService.AddCourse(course);
                if (courses == null)
                {
                    return NotFound($"Something went wrong while adding the Course");
                }
                else
                    return Ok($"Course added  with id {courses.Id}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        [HttpPut("updateCourse")]
        public IActionResult Update(int id,Course course)
        {
            try
            {
                var courses = _courseService.UpdateCourse(id,course);
                 return Ok($"Course Updated  with id {course.Id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var courses = _courseService.DeleteCourse(id);
                if (courses == null)
                {
                    return NotFound($"Something went wrong while upating the Course");
                }
                else
                    return Ok($"Course deleted  with id {id}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

