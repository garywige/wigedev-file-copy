using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Validation.Implementations
{
    public class PathValidator : TextFieldValidator
    {
        public PathValidator(ITextField field): base(field)
        { }

        public override bool IsValid => base.IsValid && (new DirectoryInfo(field.Text)).Exists;
    }
}
