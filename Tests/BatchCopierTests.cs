﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Copier.Implementations;
using WigeDev.ViewModel.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class BatchCopierTests
    {
        private BatchCopier sut;
        private FakeCancellationManager cancellationManager;
        private FakeNotifyList<ICopyJobControlViewModel> jobList;
        private FakeFileEnumerator fileEnumerator;
        private FakePathConstructor pathConstructor;
        private FakeSourceFile sourceFile;

        [TestInitialize]
        public void Initialize()
        {
            sourceFile = new();
            pathConstructor = new();
            fileEnumerator = new(sourceFile);
            jobList = new(new ObservableCollection<ICopyJobControlViewModel>());
            jobList.Add(new FakeCopyJobViewModel());
            cancellationManager = new();
            sut = new(cancellationManager, jobList, fileEnumerator, pathConstructor);
        }

        [TestMethod]
        public void CancelSetsIsCancellationRequestedTrue()
        {
            var token = cancellationManager.Token;

            sut.Cancel();

            var result = token.IsCancellationRequested;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsJobListIteratesThroughJobs()
        {
            await sut.Copy();

            var result = jobList.GetEnumeratorCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsFileEnumeratorEnumerate()
        {
            await sut.Copy();

            var result = fileEnumerator.WasEnumerateCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsPathConstructorConstruct()
        {
            await sut.Copy();

            var result = pathConstructor.WasConstructCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsSourceFileCopyTo()
        {
            await sut.Copy();

            var result = sourceFile.WasCopyToCalled;
            Assert.IsTrue(result);
        }
    }
}
