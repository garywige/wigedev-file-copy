using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeJobStatus : IJobStatus
    {
        private bool isCopying;

        public FakeJobStatus()
        {
            isCopying = false;
        }

        public bool IsCopying
        {
            get => isCopying;
            set
            {
                isCopying = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCopying"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
