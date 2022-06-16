using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WigeDev.FileSystem.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class JobListFileSaverTests
    {
        private JobListFileSaver sut;
        private FakeNotifyList<ICopyJobControlViewModel> jobList;
        private readonly string filePath = Environment.CurrentDirectory + "test.txt";

        [TestInitialize]
        public void Initialize()
        {
            var file = new FileInfo(filePath);
            if (file.Exists) file.Delete();

            jobList = new(new ObservableCollection<ICopyJobControlViewModel>());
            sut = new();
        }

        [TestMethod]
        public async Task SaveCallsGetEnumerator()
        {
            await sut.Save(jobList, filePath);

            var result = jobList.GetEnumeratorCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task SaveCreatesFile()
        {
            await sut.Save(jobList, filePath);

            var result = new FileInfo(filePath).Exists;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task SaveFileContainsPaths()
        {
            bool isEqual = true;
            var job = new FakeCopyJobViewModel();
            jobList.Add(job);
            await sut.Save(jobList, filePath);

            var file = new FileInfo(filePath);
            using var reader = file.OpenText();

            var source = reader.ReadLine();
            var dest = reader.ReadLine();
            reader.Close();

            if (source != job.Source || dest != job.Destination)
                isEqual = false;

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public async Task SaveDoesntThrowIfFileExists()
        {
            using var stream = new FileInfo(filePath).Create();
            stream.Close();
            bool isError = false;

            try
            {
                await sut.Save(jobList, filePath);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }
    }
}
