using Microsoft.AspNetCore.Mvc;
using Monolith.Module1.Shared;

namespace Monolith.ModuleA
{
    [Route("[controller]")]
    internal class ModuleAController : Controller
    {
        private readonly ITestService _testService;

        public ModuleAController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("SimpleGET")]
        public ActionResult<string> Index()
        {
            return $"{_testService.SayHello()} in TestController in Module 1";
        }
    }
}