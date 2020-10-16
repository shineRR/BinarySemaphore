using System;
using System.Threading;

namespace BinarySemaphore
{
    public class SemaphoreTest
    {
        private const int DefaultThreadCount = 15;
        public Thread[] ThreadQueue;
        private bool _isActive = true;
        private readonly Mutex _mutex = new Mutex();

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
                Thread.Sleep(100);
                _mutex.Unlock();
            }
            Console.WriteLine("[Disposed] " + Thread.CurrentThread.Name);
        }

        public void Dispose()
        {
            _mutex.Lock();
            _isActive = false;
            Thread.Sleep(100);
            _mutex.Unlock();
        }
    }
}