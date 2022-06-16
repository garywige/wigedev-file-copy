using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

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
