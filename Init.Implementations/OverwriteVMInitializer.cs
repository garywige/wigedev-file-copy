using WigeDev.Copier.Interfaces;
using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class OverwriteVMInitializer : IInitializer<ISelectControlViewModel<ICopyStrategy>>
    {
        protected IOutput output;

        public OverwriteVMInitializer(IOutput output)
        {
            this.output = output;
        }

        public ISelectControlViewModel<ICopyStrategy> Initialize() => new OverwriteSelectControlViewModel<ICopyStrategy>("Overwrite Mode", (new CopyStrategyInitializer(output)).Initialize());
    }
}
