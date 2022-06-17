using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeCopyJobViewModel : ICopyJobControlViewModel
    {
        public string Source { get; set; } = "C:\\source";

        public string Destination { get; set; } = "C:\\destination";

        public ISetExecuteCommand EditCommand => throw new System.NotImplementedException();

        public ISetExecuteCommand DeleteCommand => throw new System.NotImplementedException();

        public double Progress
        {
            get => 0;
            set => WasProgressSet = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool WasProgressSet { get; private set; } = false;
    }
}
