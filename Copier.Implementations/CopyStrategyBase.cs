using WigeDev.Copier.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public abstract class CopyStrategyBase : ICopyStrategy
    {
        public virtual async Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token)
        {
            FileStream? readStream = null;
            FileStream? writeStream = null;

            try
            {
                if (dest.Exists) dest.Delete();
                readStream = source.OpenRead();
                writeStream = dest.OpenWrite();
                await readStream.CopyToAsync(writeStream, token);
                await writeStream.FlushAsync(token);
            }
            catch (OperationCanceledException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                writeOutput(ex.Message);
            }
            finally
            {
                if (readStream != null) await readStream.DisposeAsync();
                if (writeStream != null) await writeStream.DisposeAsync();
            }
        }

        protected abstract void writeOutput(string message);
    }
}
