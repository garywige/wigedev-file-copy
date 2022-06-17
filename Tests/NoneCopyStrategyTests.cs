using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class NoneCopyStrategyTests : CopyStrategyTestsBase<NoneCopyStrategy>
    {
        [TestInitialize]
        public new void Initialize()
        {
            base.Initialize();
            sut = new(output);
        }

        [TestMethod]
        public void ToStringEqualsNoOverwrite()
        {
            var result = sut.ToString();
            Assert.AreEqual("No Overwrite", result);
        }

        [TestMethod]
        public async Task CopyFileSkipsExistingFiles()
        {
            var fs = dest.Create();
            await fs.DisposeAsync();

            await sut.CopyFile(source, dest, cancellationManager.Token);

            fs = dest.OpenRead();
            var result = fs.ReadByte();
            await fs.DisposeAsync();

            Assert.AreNotEqual(testByte, result);
        }
    }
}
