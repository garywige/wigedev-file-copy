using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Output.Implementations;

namespace WigeDev.Init.Implementations
{
    public class OutputInitializer : IInitializer<IOutput>
    {
        public IOutput Initialize() =>
            new BasicOutput(new NotifyList<string>());
    }
}
