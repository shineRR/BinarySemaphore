using System;
using System.Threading;

namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SemaphoreTest semaphore = new SemaphoreTest(5);
            foreach (var thread in semaphore.ThreadQueue)
            {
                thread.Join();
            }
        }
    }
}