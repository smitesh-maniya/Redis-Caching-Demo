using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ODataRedisCaching.DataCotext;
using ODataRedisCaching.Models;

namespace ODataRedisCaching.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _dbContext;

        public StudentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student?> GetStudent(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }
    }
}
