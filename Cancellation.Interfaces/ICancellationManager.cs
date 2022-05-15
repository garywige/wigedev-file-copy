using System.Threading.Tasks;

namespace WigeDev.Cancellation.Interfaces
{
    public interface ICancellationManager
    {
        public void Cancel();
        public CancellationToken Token { get; }
    }
}