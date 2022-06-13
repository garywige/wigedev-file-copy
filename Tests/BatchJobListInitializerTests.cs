using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class BatchJobListInitializerTests : InitializerTestsBase<INotifyList<ICopyJobControlViewModel>>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new BatchJobListInitializer();
        }
    }
}
