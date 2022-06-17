using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    public class FakeSetExecuteCommandFactory : IFactory<ISetExecuteCommand>
    {
        public ISetExecuteCommand Create() => new SetExecuteCommand(new Command(() => true, () => { }));
    }
}
