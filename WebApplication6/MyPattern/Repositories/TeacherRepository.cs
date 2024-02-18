using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebApplication6.Entities.DTOs;
using WebApplication6.Models;
using WebApplication6.MyPattern.IRepositories;

namespace WebApplication6.MyPattern.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IConfiguration _configuration;

        public TeacherRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateTeacher(TeachedDTO teacherdto)
        {

            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "";

                    var parameters = new TeachedDTO
                    {
                        full_name=teacherdto.full_name,
                        age=teacherdto.age,
                        salary=teacherdto.salary,
                        phone=teacherdto.phone,
                        groups_count=teacherdto.groups_count,
                        experience=teacherdto.experience,
                       
                       
                    };

                    connection.ExecuteAsync(query, parameters);

                    // Return the updated student
                  
                }
                return "Malumot yaratildi";
            }
            catch (Exception)
            {
                // Handle update failure
                return null;
            }


        }

        public bool DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Teacher UpdateTeacher(int id, TeachedDTO teacherdto)
        {
            throw new NotImplementedException();
        }

       
    }
}

