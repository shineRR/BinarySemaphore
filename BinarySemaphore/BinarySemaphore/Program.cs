using System;
using System.Threading;

namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SemaphoreServiceTest semaphoreTest = new SemaphoreServiceTest(10);
            semaphoreTest.Dispose();
        }
    }
}