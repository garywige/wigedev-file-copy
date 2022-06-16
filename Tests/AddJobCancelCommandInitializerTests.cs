using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Implementations;

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
