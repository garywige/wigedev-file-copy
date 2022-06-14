using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeCopyJobViewModel : ICopyJobControlViewModel
    {
        public string Source => "C:\\source";

        public string Destination => "C:\\destination";

        public ICommand EditCommand => throw new System.NotImplementedException();

        public ICommand DeleteCommand => throw new System.NotImplementedException();

        public double Progress 
        {
            get => 0;
            set => WasProgressSet = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool WasProgressSet { get; private set; } = false;
    }
}
