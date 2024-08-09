using Application.DTO;
using Application.Features;
using Domain.ValuesObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentFeature _studentFeature) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SieveModel sieveModel)
        {
            var result = await _studentFeature.GetAll(sieveModel);
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
