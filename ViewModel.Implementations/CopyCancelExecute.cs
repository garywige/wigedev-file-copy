using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyCancelExecute : IExecute
    {
        protected ICopier copier;
        protected IJobStatus jobStatus;

        public CopyCancelExecute(ICopier copier, IJobStatus jobStatus)
        {
            this.copier = copier;
            this.jobStatus = jobStatus;
        }

        public async void Execute()
        {   
            if(!jobStatus.IsCopying)
            {
                jobStatus.IsCopying = true;
                await copier.Copy();
                jobStatus.IsCopying = false;
            }
            else
            {
                jobStatus.IsCopying = false;
                copier.Cancel();
            }
        }
    }
}
