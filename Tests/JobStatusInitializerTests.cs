using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

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
