using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class PathConstructorTests
    {
        private PathConstructor sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void ConstructDoesntThrow()
        {
            try
            {
                var output = sut.Construct("test", "test", "test\\test");
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ConstructReturnsConstructedPath()
        {
            var result = sut.Construct(@"C:\Source", @"C:\Destination", @"C:\Source\test.txt");
            Assert.AreEqual(@"C:\Destination\test.txt", result);
        }

        [TestMethod]
        public void ConstructReturnsConstructedPathWhenSubfolder()
        {
            var result = sut.Construct(@"C:\Source", @"C:\Destination", @"C:\Source\Subfolder 1\Subfolder 2\test.txt");
            Assert.AreEqual(@"C:\Destination\Subfolder 1\Subfolder 2\test.txt", result);
        }

        [TestMethod]
        public void ConstructReturnsPathWhenSourceEndsWithBackslash()
        {
            var result = sut.Construct(@"C:\Source\", @"C:\Destination", @"C:\Source\test.txt");
            Assert.AreEqual(@"C:\Destination\test.txt", result);
        }

        [TestMethod]
        public void ConstructReturnsPathWhenDestinationEndsWithBackslash()
        {
            var result = sut.Construct(@"C:\Source", @"C:\Destination\", @"C:\Source\test.txt");
            Assert.AreEqual(@"C:\Destination\test.txt", result);
        }
    }
}
