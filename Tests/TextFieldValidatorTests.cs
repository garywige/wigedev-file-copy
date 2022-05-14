using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Validation.Implementations;

namespace Tests
{
    [TestClass]
    public class TextFieldValidatorTests
    {
        private TextFieldValidator sut;
        private bool isError;
        private FakeTextField field;

        [TestInitialize]
        public void Initialize()
        {
            field = new FakeTextField();
            sut = new(field);
            isError = false;
        }

        [TestMethod]
        public void IsValidDoesntThrow()
        {
            try
            {
                var output = sut.IsValid;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void IsValidFalseWhenTextEmpty()
        {
            field.Text = string.Empty;
            var result = sut.IsValid;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTrueWhenTextNotEmpty()
        {
            field.Text = "test";
            var result = sut.IsValid;
            Assert.IsTrue(result);
        }
    }
}
