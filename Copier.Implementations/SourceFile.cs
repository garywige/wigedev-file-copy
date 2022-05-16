using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class SourceFile : ISourceFile
    {
        protected FileInfo fi;

        public SourceFile(FileInfo fi)
        {
            this.fi = fi;
        }

        public string Name => fi.FullName;

        public async Task CopyTo(string dest, ICancellationManager cancellationManager)
        {
            var token = cancellationManager.Token;
            createDirectories(dest);
            await copyFile(dest, token);
        }
        

        public static SourceFile Create(FileInfo fi) =>
            new SourceFile(fi);

        private void createDirectories(string dest) =>
            (new FileInfo(dest))?.Directory?.Create();
        

        private async Task copyFile(string dest, CancellationToken token)
        {
            FileStream? readStream = null, writeStream = null;

            try
            {
                readStream = fi.OpenRead();
                writeStream = (new FileInfo(dest)).OpenWrite();
                await readStream.CopyToAsync(writeStream, token);
                await writeStream.FlushAsync(token);
            }
            catch(OperationCanceledException)
            {
                throw new OperationCanceledException();
            }
            catch(Exception)
            {

            }
            finally
            {
                readStream?.Close();
                writeStream?.Close();
            }
        }
    }
}
