using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Copier.Implementations;
using WigeDev.Settings.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class FileEnumerator : IFileEnumerator
    {
        protected ISettingsManager settingsManager;

        public FileEnumerator(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
        }

        public async Task<IList<ISourceFile>> Enumerate(string sourcePath, ICancellationManager cancellationManager)
        {
            List<ISourceFile> output = new();

            try
            {
                enumerateFiles(output, cancellationManager, sourcePath);
                await enumerateDirectories(output, cancellationManager, sourcePath);
            }
            catch(OperationCanceledException)
            {
                output.Clear();
            }
            catch
            {
                // do nothing by default
            }
            
            return output;
        }

        private void checkForCancellation(ICancellationManager cancellationManager)
        {
            if (cancellationManager.Token.IsCancellationRequested)
                throw new OperationCanceledException();
        }

        private void enumerateFiles(IList<ISourceFile> output, ICancellationManager cancellationManager, string sourcePath)
        {
            foreach (var file in Directory.EnumerateFiles(sourcePath))
            {
                checkForCancellation(cancellationManager);
                output.Add(SourceFile.Create(new FileInfo(file), settingsManager));
            }
        }

        private async Task enumerateDirectories(IList<ISourceFile> output, ICancellationManager cancellationManager, string sourcePath)
        {
            foreach (var dir in Directory.GetDirectories(sourcePath))
            {
                checkForCancellation(cancellationManager);
                foreach (var file in await Enumerate(Path.Combine(sourcePath, dir), cancellationManager))
                {
                    checkForCancellation(cancellationManager);
                    output.Add(file);
                }
            }
        }
    }
}
