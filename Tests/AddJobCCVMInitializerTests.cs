using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AddJobCCVMInitializerTests : InitializerTestsBase<ICommandControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new AddJobCCVMInitializer(null, new List<ICopyJobControlViewModel>());
        }
    }
}
