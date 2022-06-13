using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CommandControlViewModelTests
    {
        private CommandControlViewModel sut;
        private string buttonContent;

        [TestInitialize]
        public void Initialize()
        {
            buttonContent = "test";
            sut = new(buttonContent, new FakeCommand());
        }

        [TestMethod]
        public void ButtonContentReturnsConstructorValue()
        {
            var result = sut.ButtonContent;
            Assert.AreEqual(buttonContent, result);
        }

        [TestMethod]
        public void CommandIsNotNull()
        {
            var result = sut.Command;
            Assert.IsNotNull(result);
        }
    }
}
