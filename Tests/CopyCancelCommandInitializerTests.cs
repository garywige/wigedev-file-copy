using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyCancelCommandInitializerTests : InitializerTestsBase<ICommand>
    {
        [TestInitialize]
        public void Initialize()
        {
            sut = new CopyCancelCommandInitializer(
                new FakeValidator(),
                new FakeSettingsManager(),
                new FakeTextField(),
                new FakeTextField(),
                new FakeOutput(),
                new FakeJobStatus());
        }
    }
}
