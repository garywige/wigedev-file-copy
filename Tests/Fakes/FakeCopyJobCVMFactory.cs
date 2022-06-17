using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeCopyJobCVMFactory : ICopyJobCVMFactory
    {
        public ICopyJobControlViewModel Create()
        {
            return new FakeCopyJobViewModel();
        }
    }
}
