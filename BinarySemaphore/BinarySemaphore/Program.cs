using System;
using System.Threading;

namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SemaphoreServiceTest semaphoreTest = new SemaphoreServiceTest(2);
            semaphoreTest.Dispose();
        }
    }
}