using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyCancelCommandInitializerTests : InitializerTestsBase<ICommand>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new CopyCancelCommandInitializer(
                new FakeValidator(),
                new FakeTextField(),
                new FakeTextField(),
                new FakeOutput(),
                new FakeJobStatus(),
                new FakeCancellationManager(),
                new FakeFileEnumerator(new FakeSourceFile()),
                new FakePathConstructor());
        }
    }
}
