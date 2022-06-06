using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyJobControlViewModelTests
    {
        private CopyJobControlViewModel sut;
        private readonly string source = "source test";
        private readonly string destination = "destination test";

        [TestInitialize]
        public void Initialize()
        {
            sut = new(source, destination, new FakeCommand(), new FakeCommand());
        }

        [TestMethod]
        public void SourceReturnsConstructorValue()
        {
            var result = sut.Source;
            Assert.AreEqual(source, result);
        }

        [TestMethod]
        public void DestinationReturnsConstructorValue()
        {
            var result = sut.Destination;
            Assert.AreEqual(destination, result);
        }

        [TestMethod]
        public void EditCommandIsNotNull()
        {
            var result = sut.EditCommand;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteCommandIsNotNull()
        {
            var result = sut.DeleteCommand;
            Assert.IsNotNull(result);
        }
    }
}
