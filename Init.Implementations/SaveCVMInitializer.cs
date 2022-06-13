using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class SaveCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        public ICommandControlViewModel Initialize()
        {
            return new CommandControlViewModel("Save Batch", new Command(() => true, () => { }));
        }
    }
}
