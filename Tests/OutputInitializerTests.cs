using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.Output.Interfaces;

namespace Tests
{
    [TestClass]
    public class OutputInitializerTests : InitializerTestsBase<IOutput>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new OutputInitializer();
        }
    }
}
