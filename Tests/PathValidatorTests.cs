using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Validation.Implementations;

namespace Tests
{
    [TestClass]
    public class PathValidatorTests
    {
        private FakeTextField field;
        private PathValidator sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            field = new();
            sut = new(field);
            isError = false;
        }

        [TestMethod]
        public void IsValidFalseWhenPathDoesntExist()
        {
            field.Text = "Horse";
            var result = sut.IsValid;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTrueWhenPathExists()
        {
            field.Text = "C:\\Windows";
            var result = sut.IsValid;
            Assert.IsTrue(result);
        }
    }
}
