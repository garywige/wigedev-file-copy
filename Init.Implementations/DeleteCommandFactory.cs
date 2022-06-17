using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class DeleteCommandFactory : IFactory<ISetExecuteCommand>
    {
        protected Func<bool> canExecute;
        protected Action execute;

        public DeleteCommandFactory(Func<bool> canExecute, Action execute, ref EventHandler deleteCommandChanged)
        {
            this.canExecute = canExecute;
            this.execute = execute;
            deleteCommandChanged += (s, e) => this.deleteCommandChanged?.Invoke(this, new EventArgs());
        }

        public ISetExecuteCommand Create()
        {
            return new SetExecuteCommand(
                new CECCommand(new Command(
                                    canExecute,
                                    execute),
                                    ref deleteCommandChanged));
        }

        protected EventHandler deleteCommandChanged;
    }
}
