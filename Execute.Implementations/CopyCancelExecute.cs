using WigeDev.Copier.Interfaces;
using WigeDev.Execute.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Execute.Implementations
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
            if (!jobStatus.IsCopying)
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
