using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class BatchJobListInitializer : IInitializer<INotifyList<ICopyJobControlViewModel>>
    {
        public INotifyList<ICopyJobControlViewModel> Initialize() => new NotifyList<ICopyJobControlViewModel>(new NotifyListEnumerator<ICopyJobControlViewModel>());
    }
}
