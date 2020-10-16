using System.Threading;

namespace BinarySemaphore
{
    public class SemaphoreTest
    {
        private const int DefaultThreadCount = 15;
        public Thread[] ThreadQueue;
        private bool _isActive = true;
        private readonly Mutex _mutex = new Mutex();

        public SemaphoreTest()
        {
            ThreadQueue = new Thread[DefaultThreadCount];
        }

        public SemaphoreTest(int threadCount)
        {
            ThreadQueue = new Thread[threadCount];
            for (int i = 0; i < ThreadQueue.Length; i++)
            {
                ThreadQueue[i] = new Thread(new ThreadStart(TaskSelectionQueue));
                ThreadQueue[i].Name = "Thread #" + i;
                ThreadQueue[i].Start();
            }
        }

        private void TaskSelectionQueue()
        {
            while (_isActive)
            {
                _mutex.Lock();
                Thread.Sleep(5000);
                _mutex.Unlock();
            }
        }

        public void Dispose()
        {
            _mutex.Lock();
            _isActive = false;
            _mutex.Unlock();
        }
    }
}