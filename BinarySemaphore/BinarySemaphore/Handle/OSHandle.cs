using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace BinarySemaphore
{
    public class OSHandle: IOSHandle
    {
        public IntPtr Handle { get; set; }


        public OSHandle()
        {
        }
        public OSHandle(IntPtr osId)
        {
            this.Handle = osId;
        }
        
        ~OSHandle()
        {
            this.Dispose();
        }
        
        [DllImport("kernel32", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        public void Dispose()
        {
            bool isClosed = CloseHandle(Handle);
            if (!isClosed)
            {
                Console.WriteLine("Handler is already closed");
            }
        }
    }
}