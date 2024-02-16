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
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "DELETE FROM student WHERE id = @Id";
                    connection.Execute(query, new { Id = id });
                }

                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "SELECT * FROM student";
                return connection.Query<Student>(query);
            }
        }

        public Student GetByIdStudent(int id)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "SELECT * FROM student WHERE id = @Id";
                return connection.QueryFirstOrDefault<Student>(query, new { Id = id });
            }
        }

        public Student UpdateStudent(int id, StudentDTO studentdto)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "UPDATE student SET full_name = @full_name, age = @age, course_id = @course_id, phone = @phone, parent_phone = @parent_phone, shot_number = @shot_number WHERE id = @Id";

                    var parameters = new
                    {
                        Id = id,
                        full_name = studentdto.full_name,
                        age = studentdto.age,
                        course_id = studentdto.course_id,
                        phone = studentdto.phone,
                        parent_phone = studentdto.parent_phone,
                        shot_number = studentdto.shot_number,
                    };

                    connection.Execute(query, parameters);

                    // Return the updated student
                    return GetByIdStudent(id);
                }
            }
            catch (Exception)
            {
                // Handle update failure
                return null;
            }
        }
    }
}
