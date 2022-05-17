using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using WigeDev.Model.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeViewModel : IViewModel
    {
        public FakeViewModel()
        {
            Output = new List<string>();
        }

        public ITextField Source => throw new System.NotImplementedException();

        public ITextField Destination => throw new System.NotImplementedException();

        public ICommand CopyCancelCommand => throw new System.NotImplementedException();

        public IList<string> Output { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
