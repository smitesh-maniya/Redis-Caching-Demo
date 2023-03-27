using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ODataRedisCaching.Models;
using ODataRedisCaching.Services;

namespace ODataRedisCaching.Controllers
{
    [ODataRoutePrefix("District")]
    public class DistrictController : ODataController
    {
        private readonly IDistrictDataService _districtDataService;
        public DistrictController(IDistrictDataService districtDataService)
        {
            _districtDataService = districtDataService;
        }
        [HttpGet]
        [OutputCache]
        [EnableQuery()]
        public async Task<ActionResult<List<District>>> Get()
        {
            Console.WriteLine("Get all data");
            var data = await _districtDataService.GetDistricts();
            return Ok(data);
        }
        [ODataRoute("({id})")]
        [OutputCache]
        [EnableQuery()]
        public async Task<ActionResult<District>> GetById(int id)
        {
            Console.WriteLine("Get district data");
            var district = await _districtDataService.GetDistrictData(id);
            if (district == null)
            {
                return BadRequest("District not found with given id.");
            }
            return Ok(district);
        }
    }
}
