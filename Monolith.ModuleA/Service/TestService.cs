using Monolith.Module1.Shared;

namespace Monolith.ModuleA
{
    internal class TestService : ITestService
    {
        public string SayHello()
        {
            return "Hello world from Test Service (Module1)";
        }
    }
}