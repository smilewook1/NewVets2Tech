using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewVets2Tech.Api.Data.Models;

namespace NewVets2Tech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly WAVets2TechContext _WAVets2TechContext;
        public StudentsController(WAVets2TechContext waVets2TechContext)
        {
            _WAVets2TechContext = waVets2TechContext;
        }

        [HttpGet]
         public async Task<IActionResult> Get()
         {
             var students = await _WAVets2TechContext.Students.ToListAsync();
             return Ok(students);
         }
    }
}

