using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewVets2Tech.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Azure;
using Response = NewVets2Tech.Api.Data.Models.Response;

namespace NewVets2Tech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]

        public Response Registration(Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentRegistration(s, connection);

            return response;
        }

        [HttpPost]
        [Route("Login")]

        public Response Login(Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentLogin(s, connection);

            return response;
        }

        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentUserApproval(s, connection);

            return response;
        }
    }
}