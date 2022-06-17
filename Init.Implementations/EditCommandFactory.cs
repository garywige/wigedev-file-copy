using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class EditCommandFactory : IFactory<ISetExecuteCommand>
    {
        protected Func<bool> canExecute;
        protected Action execute;
        protected EventHandler handler;

        public EditCommandFactory(Func<bool> canExecute, Action execute, ref EventHandler handler)
        {
            this.canExecute = canExecute;
            this.execute = execute;
            handler += (s, e) => this.handler?.Invoke(this, new EventArgs());
        }

        public ISetExecuteCommand Create()
        {
            return new SetExecuteCommand(
                                new CECCommand(
                                new Command(
                                    canExecute,
                                    execute),
                                ref handler));
        }
    }
}
