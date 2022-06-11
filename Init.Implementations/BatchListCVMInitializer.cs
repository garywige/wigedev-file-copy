using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class BatchListCVMInitializer : IInitializer<IBatchListControlViewModel>
    {
        protected INotifyList<ICopyJobControlViewModel> jobList;

        public BatchListCVMInitializer(INotifyList<ICopyJobControlViewModel> jobList)
        {
            this.jobList = jobList;
        }

        public IBatchListControlViewModel Initialize() => new BatchListControlViewModel(jobList);
    }
}
