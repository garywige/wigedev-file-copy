using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class OldCopyStrategyTests : CopyStrategyTestsBase<OldCopyStrategy>
    {
        [TestInitialize]
        public new void Initialize()
        {
            base.Initialize();
            sut = new(output);
        }

        [TestMethod]
        public void ToStringEqualsCopyIfNewer()
        {
            var result = sut.ToString();
            Assert.AreEqual("Copy If Newer", result);
        }

        [TestMethod]
        public async Task CopyFileSkipsIfDestIsNewer()
        {
            var fs = dest.Create();
            fs.WriteByte(6);
            await fs.FlushAsync();
            await fs.DisposeAsync();

            await sut.CopyFile(source, dest, cancellationManager.Token);

            fs = dest.OpenRead();
            var result = fs.ReadByte();
            await fs.DisposeAsync();

            Assert.AreEqual(6, result);
        }
    }
}
