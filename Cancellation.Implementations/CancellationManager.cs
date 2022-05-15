using System.Threading.Tasks;
using WigeDev.Cancellation.Interfaces;

namespace WigeDev.Cancellation.Implementations
{
    public class CancellationManager : ICancellationManager
    {
        protected CancellationTokenSource cts;

        public CancellationManager() =>
            cts = new CancellationTokenSource();

        ~CancellationManager() =>
            cts.Dispose();
        

        public CancellationToken Token => cts.Token;

        public void Cancel()
        {
            cts.Cancel();
            resetTokenSource();
        }

        private void resetTokenSource()
        {
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }
}