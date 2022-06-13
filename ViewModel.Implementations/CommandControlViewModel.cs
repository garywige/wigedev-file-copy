using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CommandControlViewModel : ICommandControlViewModel
    {
        public CommandControlViewModel(string buttonContent, ICommand command)
        {
            ButtonContent = buttonContent;
            Command = command;
        }

        public string ButtonContent { get; protected set; }

        public ICommand Command { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
