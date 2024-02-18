using WebApplication6.Entities.DTOs;
using WebApplication6.Models;

namespace WebApplication6.MyPattern.IRepositories
{
    public interface ITeacherRepository
    {

        public string CreateTeacher(TeachedDTO teacherdto);

        public IEnumerable<Teacher> GetAllTeachers();


        public bool DeleteTeacher(int id);
        public Teacher UpdateTeacher(int id, TeachedDTO teacherdto);




    }
}
