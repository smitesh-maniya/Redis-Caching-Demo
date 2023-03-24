using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Newtonsoft.Json;
using ODataRedisCaching.DataCotext;
using ODataRedisCaching.Models;
using ODataRedisCaching.Services;

namespace ODataRedisCaching.Controllers
{
    [ODataRoutePrefix("Student")]
    public class StudentController : ODataController
    {
        private readonly IStudentService _studentService;
       public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //[OutputCache]
        //[OutputCache(VaryByQueryKeys = new string[] { "SName" })]
        [HttpGet]
        [OutputCache()]
        [EnableQuery()]
        public async Task<ActionResult<List<Student>>> Get()
        {
            Console.WriteLine("Get all data");
            var data = await _studentService.GetStudents();
            return Ok(data);
        }
        [OutputCache]
        [EnableQuery()]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Student>> Get([FromODataUri] int id)
        {
            var data = await _studentService.GetStudent(id);
            return Ok(data);
        }

       
    }
}
