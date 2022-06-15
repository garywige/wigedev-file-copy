using WigeDev.FileSystem.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.FileSystem.Implementations
{
    public class JobListFileLoader : IFileLoader<INotifyList<ICopyJobControlViewModel>>
    {
        protected ICopyJobCVMFactory factory;

        public JobListFileLoader(ICopyJobCVMFactory factory)
        {
            this.factory = factory;
        }

        public void Load(INotifyList<ICopyJobControlViewModel> data, string filePath)
        {
            var fi = new FileInfo(filePath);
            using var reader = fi.OpenText();

            data.Clear();
            
            while(!reader.EndOfStream)
            {
                var copyJob = factory.Create();
                copyJob.Source = reader.ReadLine() ?? "";
                copyJob.Destination = reader.ReadLine() ?? "";
                data.Add(copyJob);
            }
        }
    }
}
