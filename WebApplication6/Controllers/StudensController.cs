using Microsoft.AspNetCore.Mvc;
using WebApplication6.Entities.DTOs;
using WebApplication6.MyPattern;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudensController : Controller
    {
       private readonly IStudentRepository _studentRepo;

        public StudensController(IStudentRepository studentRepository)
        {
            _studentRepo = studentRepository;
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO model)
        {
            try
            {
                var response = _studentRepo.CreateStudent(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
