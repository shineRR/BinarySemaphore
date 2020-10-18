using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // SemaphoreServiceTest mutex = new SemaphoreServiceTest(10);
            OSHandleServiceTest osHandleServiceTest = new OSHandleServiceTest("New text");
        }
    }
}