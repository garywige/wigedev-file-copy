using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ISetExecuteCommand : ICommand
    {
        public void SetExecute(Action execute);
    }
}
