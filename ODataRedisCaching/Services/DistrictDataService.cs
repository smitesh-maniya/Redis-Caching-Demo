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
        public IQueryable<District> GetDistricts()
        {
            return _db.Districts;
        }

    }
}