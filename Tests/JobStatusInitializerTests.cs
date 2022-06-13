using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class JobStatusInitializerTests : InitializerTestsBase<IJobStatus>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new JobStatusInitializer();
        }
    }
}
