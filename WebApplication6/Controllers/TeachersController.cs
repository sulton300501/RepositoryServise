using Microsoft.AspNetCore.Mvc;
using WebApplication6.Entities.DTOs;
using WebApplication6.MyPattern.IRepositories;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {

      private readonly ITeacherRepository _teacherRepo;

        public TeachersController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpPost]
        public IActionResult CreateTeacher(TeachedDTO model)
        {
            try
            {
                var result = _teacherRepo.CreateTeacher(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      





    }

}
