using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class LoadCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        public ICommandControlViewModel Initialize()
        {
            return new CommandControlViewModel("Load Batch", new Command(() => true, () => { }));
        }
    }
}
