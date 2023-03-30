using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OutputCaching;
using ODataRedisCaching.Models;
using ODataRedisCaching.Services;

namespace ODataRedisCaching.Controllers
{
    //[ODataRoutePrefix("District")]
    public class DistrictController : ODataController
    {
        private readonly IDistrictDataService _districtDataService;
        private readonly ILogger<DistrictController> _logger;
        public DistrictController(IDistrictDataService districtDataService, ILogger<DistrictController> logger)
        {
            _districtDataService = districtDataService;
            _logger = logger;
        }
        [HttpGet]
        [OutputCache]
        [EnableQuery]
        public ActionResult<List<District>> Get()
        {
            try
            {
                _logger.LogInformation("Get all data");
                var data = _districtDataService.GetDistricts();
                if(data== null)
                {
                    return NotFound("No data found.");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Exception occurs in fetching data");
                return BadRequest(ex);
            }
        }

        [OutputCache]
        [EnableQuery]
        public async Task<ActionResult<District>> Get([FromRoute]int key) //only key as a variable name can get the route value 
                                                                          //Naming convention should be maintained...variable name for route value must be key.
        {
            try
            {
                _logger.LogInformation("Get district data");
                var district = await _districtDataService.GetDistrictData(key);
                if (district == null)
                {
                    _logger.LogError($"District with {key} not found in database.");
                    return BadRequest("District not found with given id.");
                }
                return Ok(district);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}