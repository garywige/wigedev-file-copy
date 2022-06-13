using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class AddJobCancelCommandInitializerTests : InitializerTestsBase<SetExecuteCommand>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new AddJobCancelCommandInitializer();
        }
    }
}
