using WigeDev.Validation.Interfaces;

namespace Tests
{
    public class FakeValidator : IValidator
    {
        public bool IsValid { get; set; }
    }
}
