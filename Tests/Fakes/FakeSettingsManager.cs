using WigeDev.Copier.Interfaces;
using WigeDev.Settings.Interfaces;

namespace Tests
{
    public class FakeSettingsManager : ISettingsManager
    {
        public ICopyStrategy CopyStrategy { get; set; }
    }
}
