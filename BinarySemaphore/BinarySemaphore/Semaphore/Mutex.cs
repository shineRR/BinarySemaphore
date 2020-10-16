using System.Threading;

namespace BinarySemaphore
{
    public class Mutex: IMutex
    {
        public int _bit;//{ get; set; }

        public Mutex(int bit)
        {
            _bit = bit;
        }
        
        public void Enter()
        {
            Interlocked.CompareExchange(ref _bit, 0, 1);
        }

        public void Leave()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
        }
    }
}