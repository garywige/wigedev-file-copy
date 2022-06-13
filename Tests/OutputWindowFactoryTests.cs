using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Implementations;
using System;

namespace Tests
{
    [TestClass]
    public class OutputWindowFactoryTests
    {
        private OutputWindowFactory sut;
        private bool wasShowCalled;
        private bool wasShowDialogCalled;

        [TestInitialize]
        public void Initialize()
        {
            wasShowCalled = false;
            wasShowDialogCalled = false;
            sut = new(
                o => wasShowCalled = true,
                o =>
                {
                    wasShowDialogCalled = true;
                    return false;
                });
        }

        [TestMethod]
        public void CreateWindowIsNotNull()
        {
            var result = sut.CreateWindow();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShowActionCalled()
        {
            var window = sut.CreateWindow();
            window.Show();
            Assert.IsTrue(wasShowCalled);
        }

        [TestMethod]
        public void ShowDialogFuncCalled()
        {
            var window = sut.CreateWindow();
            window.ShowDialog();
            Assert.IsTrue(wasShowDialogCalled);
        }
    }
}
