using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class AddJobAddCommandInitializerTests
    {
        private AddJobAddCommandInitializer sut;

        [TestInitialize]
        public void Initialize()
        {
            var textField = new FakeTextField();
            sut = new(textField, textField, new FakeValidator());
        }

        [TestMethod]
        public void InitializeIsNotNull()
        {
            var result = sut.Initialize();
            Assert.IsNotNull(result);
        }
    }
}
