using System;
using System.Threading;

namespace BinarySemaphore
{
    public class Mutex: IMutex
    {
        private const bool Free = true;
        private const bool Busy = false;
        private readonly AtomicBool _atomicBool = new AtomicBool(false);

        public Mutex() { }
        
        public void Lock()
        {
            while (_atomicBool.SetTrue() == Busy)
            {
                Console.WriteLine("[BUSY]Semaphore said " + Thread.CurrentThread.Name);
                Thread.Sleep(200);
            }
            Console.WriteLine("[TOOK]Semaphore said " + Thread.CurrentThread.Name);
        }

        public void Unlock()
        {
            while (_atomicBool.SetFalse() == Free) { }

            Console.WriteLine("[FREE]Semaphore said " + Thread.CurrentThread.Name);
            Thread.Sleep(300);
            
        }
    }
}