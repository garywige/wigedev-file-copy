using WigeDev.Copier.Interfaces;
using WigeDev.Settings.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Settings.Implementations
{
    public class SettingsManager : ISettingsManager
    {
        public SettingsManager(ISelectControlViewModel<ICopyStrategy> copyStrategyViewModel)
        {
            CopyStrategy = copyStrategyViewModel.SelectedItem;
            copyStrategyViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "SelectedItem")
                    CopyStrategy = copyStrategyViewModel.SelectedItem;
            };
        }

        public ICopyStrategy CopyStrategy { get; private set; }
    }
}