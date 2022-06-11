using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class AddJobAddCommandInitializerTests : InitializerTestsBase<SetExecuteCommand>
    {

        [TestInitialize]
        public void Initialize()
        {
            var textField = new FakeTextField();
            sut = new AddJobAddCommandInitializer(textField, textField, new FakeValidator());
        }
    }
}
