using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataRedisCaching.DataCotext;
using ODataRedisCaching.Models;

namespace ODataRedisCaching.Services
{
    public class DistrictDataService : IDistrictDataService
    {
        private readonly AppDbContext _db;

        public DistrictDataService(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<District>> GetDistricts()
        {
            return await _db.Districts.ToListAsync();
        }
        public async Task<District?> GetDistrictData(int id)
        {
            var dist = await _db.Districts.FindAsync(id);
            if(dist == null)
            {
                return null;
            }
            return dist;
        }

    }
}
