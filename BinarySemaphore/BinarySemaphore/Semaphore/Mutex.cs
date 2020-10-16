using System;
using System.Threading;

namespace BinarySemaphore
{
    public class Mutex: IMutex
    {
        private const bool Free = true;
        private const bool Busy = false;
        private AtomicBool _atomicBool = new AtomicBool(false);

        public Mutex() { }
        
        public void Lock()
        {
            while (_atomicBool.SetTrue() == Busy)
            {
                Console.WriteLine("[BUSY]Semaphore is busy said " + Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
            Console.WriteLine("[TOOK]Semaphore took said " + Thread.CurrentThread.Name);
        }

        public void Unlock()
        {
            Thread.Sleep(1000);
            while (_atomicBool.SetFalse() == Free)
            {
               
            }
            Console.WriteLine("[FREE]Semaphore said " + Thread.CurrentThread.Name);
            Thread.Sleep(100);
            
        }
        
        public void Dispose()
        {
        }
    }
}