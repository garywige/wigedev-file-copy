using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Execute.Implementations;

namespace Tests
{
    [TestClass]
    public class AddJobExecuteTests
    {
        private AddJobExecute sut;
        private FakeOutputWindowFactory factory;

        [TestInitialize]
        public void Initialize()
        {
            factory = new();
            sut = new(factory, null);
        }

        [TestMethod]
        public void ExecuteCallsCreateWindow()
        {
            sut.Execute();

            Assert.IsTrue(factory.WasCreateWindowCalled);
        }

        [TestMethod]
        public void ExecuteCallsShowDialog()
        {
            sut.Execute();
            var result = factory.WasShowDialogCalled;
            Assert.IsTrue(result);
        }
    }
}
