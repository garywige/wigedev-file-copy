using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyCancelExecute : IExecute
    {
        protected ICopier copier;
        protected bool isCopying;

        public CopyCancelExecute(ICopier copier)
        {
            this.copier = copier;
            this.isCopying = false;
        }

        public async void Execute()
        {   
            if(!isCopying)
            {
                isCopying = true;
                await copier.Copy();
            }
            else
            {
                isCopying = false;
                copier.Cancel();
            }
        }
    }
}
