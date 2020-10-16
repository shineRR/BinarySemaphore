using System;
using System.Threading;

namespace BinarySemaphore
{
    public class SemaphoreServiceTest: IDisposable
    {
        private readonly SemaphoreTest _semaphore;
        public SemaphoreServiceTest(int threadCount)
        { 
            _semaphore = new SemaphoreTest(threadCount);
        }

        public void Dispose()
        {
            Thread.Sleep(1000);
            _semaphore.Dispose();
            foreach (var thread in _semaphore.ThreadQueue)
            {
                thread.Join();
            }
        }
    }
}