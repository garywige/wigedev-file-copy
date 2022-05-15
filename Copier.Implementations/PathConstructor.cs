using WigeDev.Copier.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class PathConstructor : IPathConstructor
    {
        public string Construct(string sourceDir, string destDir, string sourceFile)
        {
            return sourceFile.Replace(sanitizePath(sourceDir), sanitizePath(destDir));
        }

        private string sanitizePath(string path)
        {
            return path.EndsWith('\\') ? path.Substring(0, path.Length - 1) : path;
        }
    }
}
