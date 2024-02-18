using WebApplication6.Models;

namespace WebApplication6.Services.TeacherServices
{
    public interface ITeacherService
    {
        public Teacher GetByIdTeacher(int id);
    }
}
