using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Settings.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class SourceFile : ISourceFile
    {
        protected FileInfo fi;
        protected ISettingsManager settingsManager;

        public SourceFile(FileInfo fi, ISettingsManager settingsManager)
        {
            this.fi = fi;
            this.settingsManager = settingsManager;
        }

        public string Name => fi.FullName;

        public async Task CopyTo(string dest, ICancellationManager cancellationManager)
        {
            var token = cancellationManager.Token;
            createDirectories(dest);
            await settingsManager.CopyStrategy.CopyFile(fi, new FileInfo(dest), token);
        }
        

        public static SourceFile Create(FileInfo fi, ISettingsManager settingsManager) =>
            new SourceFile(fi, settingsManager);

        private void createDirectories(string dest)
        {
            try
            {
                (new FileInfo(dest))?.Directory?.Create();
            }
            catch
            {

            }
        }
            
       
    }
}
