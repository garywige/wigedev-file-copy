using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Settings.Implementations;
using WigeDev.Copier.Interfaces;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SettingsManagerTests
    {
        private SettingsManager sut;
        private bool isError;
        private FakeSelectControlViewModel<ICopyStrategy> overwriteVM;

        [TestInitialize]
        public void Initialize()
        {
            List<ICopyStrategy> copyStrategies = new();
            copyStrategies.Add(new FakeCopyStrategy());
            overwriteVM = new(copyStrategies);
            sut = new SettingsManager(overwriteVM);
            isError = false;
        }

        [TestMethod]
        public void CopyStrategyDoesntThrow()
        {
            try
            {
                var output = sut.CopyStrategy;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CopyStrategyIsNotNull()
        {
            var result = sut.CopyStrategy;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CopyStrategyEqualsVMSelectedItem()
        {
            var fakeCopyStrategy = new FakeCopyStrategy();
            overwriteVM.SelectedItem = fakeCopyStrategy;
            var result = sut.CopyStrategy;
            Assert.AreEqual(fakeCopyStrategy, result);
        }
    }
}
