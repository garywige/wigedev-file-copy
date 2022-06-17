using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WigeDev.View.Implementations;

namespace Tests
{
    [TestClass]
    public class OutputWindowAdapterTests
    {
        private OutputWindowAdapter sut;
        private bool isError;
        private bool wasShowActionCalled;
        private bool wasShowDialogFuncCalled;
        private bool wasCloseCalled;
        private Action<object?> show;
        private Func<object?, bool?> showDialog;
        private Action close;

        [TestInitialize]
        public void Initialize()
        {
            wasShowActionCalled = false;
            wasShowDialogFuncCalled = false;
            wasCloseCalled = false;

            show = o => wasShowActionCalled = true;
            showDialog = o =>
            {
                wasShowDialogFuncCalled = true;
                return false;
            };
            close = () => wasCloseCalled = true;

            sut = new(show, showDialog, close);
            isError = false;
        }

        [TestMethod]
        public void OutputDefaultNull()
        {
            var result = sut.Output;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ShowCallsAction()
        {
            sut.Show();
            Assert.IsTrue(wasShowActionCalled);
        }

        [TestMethod]
        public void ShowDialogCallsFunc()
        {
            sut.ShowDialog();
            Assert.IsTrue(wasShowDialogFuncCalled);
        }

        [TestMethod]
        public void CloseCallsAction()
        {
            sut.Close();
            Assert.IsTrue(wasCloseCalled);
        }
    }
}
