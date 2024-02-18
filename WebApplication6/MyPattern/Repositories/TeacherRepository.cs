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
                    string query = "insert into teachers(full_name,age,salary,phone,groups_count,experience) values(@full_name,@age,@salary,@phone,@groups_count,@experience)";

                    var parameters = new TeachedDTO
                    {
                        full_name=teacherdto.full_name,
                        age=teacherdto.age,
                        salary=teacherdto.salary,
                        phone=teacherdto.phone,
                        groups_count=teacherdto.groups_count,
                        experience=teacherdto.experience,
                       
                       
                    };

                    connection.Execute(query, parameters);

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
          
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from teachers";


                    var result = connection.Query<Teacher>(query);
                   
                    return result;
 

                }
              
            
         
        }

        public Teacher UpdateTeacher(int id, TeachedDTO teacherdto)
        {
            throw new NotImplementedException();
        }

       
    }
}

