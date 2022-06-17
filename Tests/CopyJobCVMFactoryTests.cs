using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyJobCVMFactoryTests
    {
        private CopyJobCVMFactory sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(new FakeSetExecuteCommandFactory(), new FakeSetExecuteCommandFactory());
        }

        [TestMethod]
        public void CreateItNotNull()
        {
            var result = sut.Create();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditCommandIsNotNull()
        {
            var job = sut.Create();

            var result = job.EditCommand;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteCommandIsNotNull()
        {
            var job = sut.Create();

            var result = job.DeleteCommand;
            Assert.IsNotNull(result);
        }
    }
}
