using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class BatchJobListInitializer : IInitializer<INotifyList<ICopyJobControlViewModel>>
    {
        public INotifyList<ICopyJobControlViewModel> Initialize() => new NotifyList<ICopyJobControlViewModel>();
    }
}
