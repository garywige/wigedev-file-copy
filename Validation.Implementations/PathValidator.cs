using WigeDev.Model.Interfaces;
using System.IO;

namespace WigeDev.Validation.Implementations
{
    public class PathValidator : TextFieldValidator
    {
        public PathValidator(ITextField field): base(field)
        { }

        new public bool IsValid => base.IsValid && (new DirectoryInfo(field.Text)).Exists;
    }
}
