using Microsoft.AspNetCore.Mvc;
using WebApplication6.Entities.DTOs;
using WebApplication6.MyPattern;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var isDeleted = _studentRepo.DeleteStudent(id);

                if (isDeleted)
                {
                    return Ok("Student deleted successfully");
                }
                else
                {
                    return NotFound("Student not found or deletion failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepo.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdStudent(int id)
        {
            try
            {
                var student = _studentRepo.GetByIdStudent(id);

                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound("Student not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentDTO model)
        {
            try
            {
                var updatedStudent = _studentRepo.UpdateStudent(id, model);

                if (updatedStudent != null)
                {
                    return Ok(updatedStudent);
                }
                else
                {
                    return NotFound("Student not found or update failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}

