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
        public async Task<District?> GetDistrictData(int id)
        {
            if(id<=0) return null;
            var dist = await _db.Districts.FindAsync(id);
            if(dist == null)
            {
                return null;
            }
            return dist;
        }

    }
}
//orderby groupby applyto