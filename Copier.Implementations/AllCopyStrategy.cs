using WigeDev.Copier.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class AllCopyStrategy : ICopyStrategy
    {
        protected IOutput output;

        public AllCopyStrategy(IOutput output)
        {
            this.output = output;
        }
        

        public async Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token)
        {
            FileStream? readStream = null;
            FileStream? writeStream = null;

            try
            {
                readStream = source.OpenRead();
                writeStream = dest.OpenWrite();
                await readStream.CopyToAsync(writeStream, token);
                await writeStream.FlushAsync(token);
            }
            catch(OperationCanceledException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                output.Write(ex.Message);
            }
            finally
            {
                readStream?.Dispose();
                writeStream?.Dispose();
            }
        }
    }
}
