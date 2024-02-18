using Microsoft.AspNetCore.Mvc;
using WebApplication6.Entities.DTOs;
using WebApplication6.MyPattern.IRepositories;
using WebApplication6.Services.TeacherServices;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : Controller
    {

      private readonly ITeacherRepository _teacherRepo;
    private readonly ITeacherService _service;

        public TeachersController(ITeacherRepository teacherRepo, ITeacherService service)
        {
            _teacherRepo = teacherRepo;
            _service = service;
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

        [HttpGet]
        public IActionResult GetAllTeachers (TeachedDTO model)
        {
            try
            {
                var result = _teacherRepo.GetAllTeachers();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByIdTeachers(int id)
        {
            try
            {
                var result = _service.GetByIdTeacher(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






    }

}
