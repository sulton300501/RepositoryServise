using WebApplication6.Entities.DTOs;
using WebApplication6.Models;
using Npgsql;
using Dapper;

namespace WebApplication6.MyPattern
{
    public class StudentRepository : IStudentRepository
    {
        public IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateStudent(StudentDTO studentdto)
        {
            try
            {


                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "insert into student(full_name,age,course_id,phone,parent_phone,shot_number) values(@full_name,@age,@course_id,@phone,@parent_phone,@shot_number)";

                    var parametrs = new StudentDTO
                    {
                        full_name = studentdto.full_name,
                        age = studentdto.age,
                        course_id = studentdto.course_id,
                        phone = studentdto.phone,
                        parent_phone = studentdto.parent_phone,
                        shot_number = studentdto.shot_number,

                    };

                    connection.Execute(query, parametrs);



                }

                return "malumot yaratildi";
            }catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetByIdStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, StudentDTO studentdto)
        {
            throw new NotImplementedException();
        }
    }
}
