using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyCancelCommandTests
    {
        private CopyCancelCommand sut;
        private bool isError;
        private FakeValidator validator;
        private FakeExecute execute;

        [TestInitialize]
        public void Initialize()
        {
            validator = new FakeValidator();
            execute = new FakeExecute();
            sut = new(validator, execute);
            isError = false;
        }

        [TestMethod]
        public void CanExecuteDoesntThrow()
        {
            try
            {
                var output = sut.CanExecute(null);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CanExecuteFalseWhenInvalid()
        {
            validator.IsValid = false;
            var result = sut.CanExecute(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanExecuteTrueWhenValid()
        {
            validator.IsValid = true;
            var result = sut.CanExecute(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteDoesntThrow()
        {
            try
            {
                sut.Execute(null);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ExecuteExecutesExecute()
        {
            sut.Execute(null);
            Assert.IsTrue(execute.WasCalled);
        }
    }
}
