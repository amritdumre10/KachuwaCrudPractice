using Dapper;
using DapperPractice.Models;
using Kachuwa.Data;
using System.Data;
using System.Data.SqlClient;

namespace DapperPractice.Services
{
    public interface IStudentService
    {
        CrudService<Student> StudentCrudService { get; set; }
    }

    public class StudentService : IStudentService
    {

        public CrudService<Student> StudentCrudService { get; set; } = new CrudService<Student>();

    }
}
