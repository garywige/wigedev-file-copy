using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.IO;
using WigeDev.FileSystem.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class JobListFileLoaderTests
    {
        private JobListFileLoader sut;
        private FakeNotifyList<ICopyJobControlViewModel> jobList;
        private readonly string testPath = Environment.CurrentDirectory + "\\test.txt";
        private FakeCopyJobCVMFactory factory;
        private readonly string source = "test source";
        private readonly string destination = "test destnation";

        [TestInitialize]
        public void Initialize()
        {
            factory = new();
            jobList = new(new ObservableCollection<ICopyJobControlViewModel>());
            sut = new(factory);

            var fi = new FileInfo(testPath);
            if (fi.Exists) fi.Delete();
            using var writer = fi.CreateText();
            writer.WriteLine(source);
            writer.WriteLine(destination);
        }

        [TestMethod]
        public void LoadClearsJobList()
        {
            sut.Load(jobList, testPath);

            var result = jobList.WasClearCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoadAddsJobsToList()
        {
            sut.Load(jobList, testPath);

            var result = jobList.Count;
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoadJobIsNotNull()
        {
            sut.Load(jobList, testPath);

            var result = jobList[0];
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadSourceEqualsTestValue()
        {
            sut.Load(jobList, testPath);

            var result = jobList[0].Source;
            Assert.AreEqual(source, result);
        }

        [TestMethod]
        public void LoadDestinationEqualsTestValue()
        {
            sut.Load(jobList, testPath);

            var result = jobList[0].Destination;
            Assert.AreEqual(destination, result);
        }

        [TestMethod]
        public void LoadHandlesMoreThanOneJob()
        {
            var fi = new FileInfo(testPath);
            using var writer = fi.AppendText();
            writer.WriteLine(source);
            writer.WriteLine(destination);
            writer.Close();

            sut.Load(jobList, testPath);

            var result = jobList.Count;
            Assert.AreEqual(2, result);
        }
    }
}
