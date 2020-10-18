using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace BinarySemaphore
{
    public class OSHandle: IDisposable
    {
        public IntPtr Handle { get; set; }

        public OSHandle() { }
        public OSHandle(IntPtr osId)
        {
            this.Handle = osId;
        }
        
        ~OSHandle()
        {
            Dispose();
        }
        
        [DllImport("kernel32", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        public void Dispose()
        {
            if (Handle != IntPtr.Zero && CloseHandle(Handle))
            {
                Console.WriteLine("Closed");
            }
        }
    }
}