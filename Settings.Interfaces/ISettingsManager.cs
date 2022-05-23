using WigeDev.Copier.Interfaces;

namespace WigeDev.Settings.Interfaces
{
    public interface ISettingsManager
    {
        public ICopyStrategy CopyStrategy { get; }
    }
}