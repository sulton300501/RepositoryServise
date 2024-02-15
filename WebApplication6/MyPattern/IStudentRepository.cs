using WebApplication6.Entities.DTOs;
using WebApplication6.Models;

namespace WebApplication6.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentdto);

        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);

        public bool DeleteStudent(int id);
        public Student UpdateStudent(int id ,StudentDTO studentdto);
    }
       
    
}
