using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Validation.Implementations
{
    public class TextFieldValidator : IValidator
    {
        protected ITextField field;

        public TextFieldValidator(ITextField field)
        { 
            this.field = field; 
        }

        public virtual bool IsValid => field.Text != String.Empty;
    }
}