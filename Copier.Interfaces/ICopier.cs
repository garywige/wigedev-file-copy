using System.Threading.Tasks;

namespace WigeDev.Copier.Interfaces
{
    public interface ICopier
    {
        public Task Copy();
        public void Cancel();
    }
}