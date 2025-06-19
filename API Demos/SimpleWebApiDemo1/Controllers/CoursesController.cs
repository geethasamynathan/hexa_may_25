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
        [ProducesResponseType(typeof(IEnumerable<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
           
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving courses.");
            }
        }

        [HttpGet("GetCourseById/{id:int}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the course."); 
            }
        }

        [HttpPost("createCourse")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while Creating the course.");

            }
        }
        [HttpPut("updateCourse")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id,Course course)
        {
            try
            {
                _courseService.UpdateCourse(id,course);
                 return Ok($"Course Updated  with id {course.Id}");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the course.");
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}

