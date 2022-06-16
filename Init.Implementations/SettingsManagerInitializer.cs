using WigeDev.Copier.Interfaces;
using WigeDev.Init.Interfaces;
using WigeDev.Settings.Implementations;
using WigeDev.Settings.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class SettingsManagerInitializer : IInitializer<ISettingsManager>
    {
        protected ISelectControlViewModel<ICopyStrategy> overwriteVM;

        public SettingsManagerInitializer(ISelectControlViewModel<ICopyStrategy> overwriteVM)
        {
            this.overwriteVM = overwriteVM;
        }

        public ISettingsManager Initialize() => new SettingsManager(overwriteVM);
    }
}
