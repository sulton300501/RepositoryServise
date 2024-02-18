using WebApplication6.Models;
using WebApplication6.MyPattern.IRepositories;

namespace WebApplication6.Services.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepo;

        public TeacherService(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public Teacher GetByIdTeacher(int id)
        {
            var result = _teacherRepo.GetAllTeachers().FirstOrDefault(x=>x.teacher_id==id);

            return result;
        
        }

    }
}
