using ODataRedisCaching.Models;

namespace ODataRedisCaching.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student?> GetStudent(int id);

    }
}
