using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Implementations;
using System;

namespace Tests
{
    [TestClass]
    public class OutputWindowAdapterTests
    {
        private OutputWindowAdapter sut;
        private bool isError;
        private bool wasShowActionCalled;
        private bool wasShowDialogFuncCalled;
        private Action<object?> show;
        private Func<object?, bool?> showDialog;

        [TestInitialize]
        public void Initialize()
        {
            wasShowActionCalled = false;
            wasShowDialogFuncCalled = false;
            show = o => wasShowActionCalled = true;
            showDialog = o =>
            {
                wasShowDialogFuncCalled = true;
                return false;
            };

            sut = new(show, showDialog);
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
    }
}
