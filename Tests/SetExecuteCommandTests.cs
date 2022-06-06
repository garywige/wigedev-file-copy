using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class SetExecuteCommandTests
    {
        private SetExecuteCommand sut;
        private FakeCommand command;

        [TestInitialize]
        public void Initialize()
        {
            command = new();
            sut = new(command);
        }

        [TestMethod]
        public void CanExecuteCallsCommandCanExecute()
        {
            sut.CanExecute(null);
            Assert.IsTrue(command.WasCanExecuteCalled);
        }

        [TestMethod]
        public void ExecuteCallsCommandExecute()
        {
            sut.Execute(null);
            Assert.IsTrue(command.WasExecuteCalled);
        }

        [TestMethod]
        public void SetExecuteOverridesCommandExecute()
        {
            bool wasExecuted = false;
            sut.SetExecute(() => wasExecuted = true);
            sut.Execute(null);
            Assert.IsTrue(wasExecuted);
        }
    }
}
