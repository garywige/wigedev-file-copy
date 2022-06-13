using WigeDev.Execute.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.Execute.Implementations
{
    public class StartBatchExecute : IExecute
    {
        protected IJobStatus jobStatus;
        protected ICopier copier;

        public StartBatchExecute(IJobStatus jobStatus, ICopier copier)
        {
            this.jobStatus = jobStatus;
            this.copier = copier;
        }

        public async void Execute()
        {
            if (!jobStatus.IsCopying)
            {
                jobStatus.IsCopying = true;
                await copier.Copy(); 
            }
            else copier.Cancel();

            jobStatus.IsCopying = false;
        }
    }
}
