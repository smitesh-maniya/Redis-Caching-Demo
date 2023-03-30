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
                _logger.LogInformation("Hit database");
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
    }
}