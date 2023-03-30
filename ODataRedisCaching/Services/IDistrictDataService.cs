using ODataRedisCaching.Models;

namespace ODataRedisCaching.Services
{
    public interface IDistrictDataService
    {
        IQueryable<District> GetDistricts();
    }
}
