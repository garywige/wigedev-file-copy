using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CommandTests
    {
        private Command sut;
        private bool isActionCalled;

        [TestInitialize]
        public void Initialize()
        {
            isActionCalled = false;
            sut = new(() => true, () => isActionCalled = true);
        }

        [TestMethod]
        public void CanExecuteReturnsTrue()
        {
            var result = sut.CanExecute(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteCallsConstructorAction()
        {
            sut.Execute(null);
            Assert.IsTrue(isActionCalled);
        }
    }
}
