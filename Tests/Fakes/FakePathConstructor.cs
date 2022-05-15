using WigeDev.Copier.Interfaces;

namespace Tests
{
    public class FakePathConstructor : IPathConstructor
    {
        public FakePathConstructor()
        {
            WasConstructCalled = false;
        }

        public string Construct(string sourceDir, string destDir, string sourceFile)
        {
            WasConstructCalled = true;
            return sourceFile;
        }

        public bool WasConstructCalled { get; private set; }
    }
}
