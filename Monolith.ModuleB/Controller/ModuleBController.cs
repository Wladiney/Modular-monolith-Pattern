using Microsoft.AspNetCore.Mvc;
using Monolith.Module1.Shared;

namespace Monolith.ModuleB
{
    [Route("[controller]")]
    internal class ModuleBController : Controller
    {
        [HttpGet("SimpleGET")]
        public ActionResult<string> Index()
        {
            return "Hello World from TestController in Module 2";
        }

        [HttpGet("SharedGET")]
        public ActionResult<string> InterModule([FromServices] ITestService testService)
        {
            return $"{testService.SayHello()} in TestController in Module 2";
        }
    }
}