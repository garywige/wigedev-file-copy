using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Implementations;

namespace Tests
{
    [TestClass]
    public class WindowFactoryTests
    {
        private WindowFactory<FakeWindowAdapter> sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
        }

        [TestMethod]
        public void CreateWindowIsNotNull()
        {
            var window = sut.CreateWindow();
            Assert.IsNotNull(window);
        }
    }
}
