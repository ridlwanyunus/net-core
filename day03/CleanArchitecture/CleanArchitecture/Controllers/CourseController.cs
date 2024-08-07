using Application.Features;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(CourseFeature _courseFeature) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllResource()
        {
            var result = await _courseFeature.GetAllCourse();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _courseFeature.GetCoursById(id);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCourseByName(string name)
        {
            var result = await _courseFeature.FindByTitle(name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCOurse(CourseCreateDto couserDto)
        {
            await _courseFeature.CreateCourse(couserDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseFeature.RemoveCourseById(id);
            if (!course)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseCreateDto courseDto)
        {
            var course = await _courseFeature.UpdateCourseById(id, courseDto);
            if (course == null)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}
