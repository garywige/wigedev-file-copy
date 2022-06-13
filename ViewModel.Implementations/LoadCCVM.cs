using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class LoadCCVM : ICommandControlViewModel
    {
        public string ButtonContent => throw new NotImplementedException();

        public ICommand Command => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
