using System.Collections.ObjectModel;
using WigeDev.Copier.Implementations;
using WigeDev.Copier.Interfaces;
using WigeDev.Init.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class CopyStrategyInitializer : IInitializer<IList<ICopyStrategy>>
    {
        protected IOutput output;

        public CopyStrategyInitializer(IOutput output)
        {
            this.output = output;
        }

        public IList<ICopyStrategy> Initialize()
        {
            ObservableCollection<ICopyStrategy> copyStrategies = new();
            copyStrategies.Add(new AllCopyStrategy(output));
            copyStrategies.Add(new NoneCopyStrategy(output));
            copyStrategies.Add(new OldCopyStrategy(output));
            return copyStrategies;
        }
    }
}
