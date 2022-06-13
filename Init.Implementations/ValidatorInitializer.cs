using WigeDev.Init.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.Validation.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class ValidatorInitializer : IInitializer<IValidator>
    {
        protected ITextField source;
        protected ITextField dest;

        public ValidatorInitializer(ITextField source, ITextField dest)
        {
            this.source = source;
            this.dest = dest;
        }

        public IValidator Initialize()
        {
            var validators = new IValidator[2];
            validators[0] = new PathValidator(source);
            validators[1] = new PathValidator(dest);
            return new FormValidator(validators);
        }
    }
}
