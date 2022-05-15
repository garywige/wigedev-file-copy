namespace WigeDev.Copier.Interfaces
{
    public interface IPathConstructor
    {
        public string Construct(string sourceDir, string destDir, string sourceFile);
    }
}
