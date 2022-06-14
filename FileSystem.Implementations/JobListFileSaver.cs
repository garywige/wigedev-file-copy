using WigeDev.FileSystem.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.FileSystem.Implementations
{
    public class JobListFileSaver : IFileSaver<INotifyList<ICopyJobControlViewModel>>
    {
        public Task Save(INotifyList<ICopyJobControlViewModel> data, string filePath)
        {
            var file = new FileInfo(filePath);
            if(file.Exists) file.Delete();

            using var writer = file.CreateText();

            foreach (var datum in data)
            {
                writer.WriteLine(datum.Source);
                writer.WriteLine(datum.Destination);
            }

            return Task.CompletedTask;
        }
    }
}