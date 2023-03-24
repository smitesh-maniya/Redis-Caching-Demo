using ODataRedisCaching.Models;

namespace ODataRedisCaching.Services
{
    public interface IDistrictDataService
    {
        Task<List<District>> GetDistricts();

        Task<District> GetDistrictData(int id);
    }
}
