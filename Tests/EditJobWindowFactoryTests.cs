using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Implementations;

namespace Tests
{
    [TestClass]
    public class EditJobWindowFactoryTests
    {
        private EditJobWindowFactory sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new EditJobWindowFactory();
        }

        [TestMethod]
        public void CreateWindowIsNotNull()
        {
            var result = sut.CreateWindow();
            Assert.IsNotNull(result);
        }
    }
}
