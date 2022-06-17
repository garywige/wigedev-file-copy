using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CECCommandTests
    {
        private CECCommand sut;
        private FakeCommand command;
        private bool wasCanExecuteChangedTriggered;
        private event EventHandler? Trigger;

        [TestInitialize]
        public void Initialize()
        {
            wasCanExecuteChangedTriggered = false;
            command = new();
            sut = new(
                command,
                ref Trigger);
            sut.CanExecuteChanged += (s, e) => wasCanExecuteChangedTriggered = true;
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
        public void CanExecuteChangedTriggered()
        {
            Trigger?.Invoke(this, new EventArgs());
            Assert.IsTrue(wasCanExecuteChangedTriggered);
        }
    }
}
