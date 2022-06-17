using WigeDev.Init.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class AddJobAddCommandInitializer : IInitializer<SetExecuteCommand>
    {
        protected ITextField sourceTF;
        protected ITextField destTF;
        protected IValidator formValidator;

        public AddJobAddCommandInitializer(ITextField source, ITextField dest, IValidator validator)
        {
            this.sourceTF = source;
            this.destTF = dest;
            this.formValidator = validator;
        }

        public SetExecuteCommand Initialize()
        {
            EventHandler? textChanged = null;
            sourceTF.PropertyChanged += (s, e) => textChanged?.Invoke(this, e);
            destTF.PropertyChanged += (s, e) => textChanged?.Invoke(this, e);
            var isFormValid = () => formValidator.IsValid;
            return new SetExecuteCommand(new CECCommand(new Command(
                isFormValid,
                () => { }),
                ref textChanged));
        }
    }
}
