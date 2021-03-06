using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Interfaces;

namespace Tests
{
    public abstract class InitializerTestsBase<T>
    {
        protected IInitializer<T> sut;

        public abstract void Initialize();

        [TestMethod]
        public void InitializeIsNotNull()
        {
            var result = sut.Initialize();
            Assert.IsNotNull(result);
        }
    }
}
