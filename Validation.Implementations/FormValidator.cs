using WigeDev.Validation.Interfaces;

namespace WigeDev.Validation.Implementations
{
    public class FormValidator : IValidator
    {
        protected IList<IValidator> validators;

        public FormValidator(IList<IValidator> validators)
        {
            this.validators = validators;
        }

        public bool IsValid => 
            validators.Where(validator => !validator.IsValid).Count() == 0;
    }
}
