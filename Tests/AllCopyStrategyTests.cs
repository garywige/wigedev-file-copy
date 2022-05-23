using WigeDev.Copier.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Tests
{
    [TestClass]
    public class AllCopyStrategyTests : CopyStrategyTestsBase<AllCopyStrategy>
    {

        [TestInitialize]
        public void Initialize()
        {
            base.Initialize();
            sut = new(output);
        }

        [TestMethod]
        public async Task CopyFileReplacesNewerFile()
        {
            var fs = dest.Create();
            fs.Close();

            await sut.CopyFile(source, dest, cancellationManager.Token);

            fs = dest.OpenRead();
            var result = fs.ReadByte();
            fs.Close();

            Assert.AreEqual(testByte, result);
        }

        [TestMethod]
        public void ToStringEqualsAllFiles()
        {
            var result = sut.ToString();
            Assert.AreEqual("All Files", result);
        }
    }
}
