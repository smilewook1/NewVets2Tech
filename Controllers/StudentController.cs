using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewVets2Tech.Api.Data.Models;
using NewVets2Tech.Api.Data;

namespace NewVets2Tech.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly WAVets2TechContext _WAVets2TechContext;
        public StudentController(WAVets2TechContext waVets2TechContext)
        {
            _WAVets2TechContext = waVets2TechContext;
        }

        /* [HttpGet]
         public async Task<IActionResult> Get()
         {
             var students = await _WAVets2TechContext.Student.ToListAsync();
             return Ok(students);
         }*/
    }
}

