using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class TextFieldTests
    {
        private TextField sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void TextSetDoesntThrow()
        {
            try
            {
                sut.Text = "test";
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void TextGetDoesntThrow()
        {
            try
            {
                var output = sut.Text;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void TextValuePersists()
        {
            sut.Text = "test";
            var result = sut.Text;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void ToStringReturnsTextValue()
        {
            sut.Text = "test";
            var result = sut.ToString();
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void PropertyChangedTriggeredOnTextSet()
        {
            bool isChanged = false;
            sut.PropertyChanged += (sender, e) => { isChanged = true; };
            sut.Text = "test";
            Assert.IsTrue(isChanged);
        }
    }
}