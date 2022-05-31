using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ILogger logger;
        public ValuesController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> GetValues()
        {
            logger.Log("GetValues accessed!");
            var strResponse = new DataResponse<string>("Hello world!");
            Console.WriteLine(strResponse.GetData());
            
            var boolResponse = new DataResponse<bool>(true);
            Console.WriteLine(boolResponse.GetData());

            var intResponse = new DataResponse<int>(5);
            Console.WriteLine(intResponse.GetData());
            return new[] { "Value 1", "Value 2"};
        }
    }
}
