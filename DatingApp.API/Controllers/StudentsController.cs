using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class StudentsController : ControllerBase
    {

        public StudentsController()
        {

        }
        [HttpGet]
        public void Get(int id, string name)
        {

        }

        [HttpPost]
        public void Post(StudentEntity student, string name)
        {
            string s = Request.QueryString.Value;
            string x = Request.ContentType;
            var xxx = Request.HttpContext;
            //var fd = Request.Form;
        }

        [HttpPost("create", Name ="Create")]
        public void Create(string name)
        {
            string s = Request.QueryString.Value;
            string x = Request.ContentType;
        }
    }

    public class StudentEntity
    {
        public string Name  { get; set; }
    }
}