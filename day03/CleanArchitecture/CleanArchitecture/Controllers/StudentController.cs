using Application.DTO;
using Application.Features;
using Domain.ValuesObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentFeature _studentFeature) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentFeature.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromPlaceholder([FromBody] PlaceholderImport import)
        {
            var result = await _studentFeature.ImportFromPlaceholder(import.idPlaceholderUser);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
