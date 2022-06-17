using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;

namespace Tests
{
    [TestClass]
    public class FormValidatorTests
    {
        private FakeValidator fieldValidator;
        private FormValidator sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            var validators = new List<IValidator>();
            fieldValidator = new FakeValidator();
            validators.Add(fieldValidator);
            sut = new(validators);
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
        public void IsValidTrueWhenFieldsValid()
        {
            fieldValidator.IsValid = true;
            var result = sut.IsValid;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidFalseWhenFieldsInvalid()
        {
            fieldValidator.IsValid = false;
            var result = sut.IsValid;
            Assert.IsFalse(result);
        }
    }
}
