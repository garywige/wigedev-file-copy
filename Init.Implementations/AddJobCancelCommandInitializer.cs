using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class AddJobCancelCommandInitializer : IInitializer<SetExecuteCommand>
    {
        public SetExecuteCommand Initialize() => new SetExecuteCommand(new Command(() => true, () => { }));
    }
}
