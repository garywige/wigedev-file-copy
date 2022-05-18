using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class JobStatus : IJobStatus
    {
        protected bool isCopying;

        public JobStatus()
        {
            IsCopying = false;
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
