using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyStrategyInitializerTests
    {
        private CopyStrategyInitializer sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(new FakeOutput());
        }

        [TestMethod]
        public void InitializeItNotNull()
        {
            var result = sut.Initialize();
            Assert.IsNotNull(result);
        }
    }
}
