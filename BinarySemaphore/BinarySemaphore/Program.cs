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
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
            [MarshalAs(UnmanagedType.LPTStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes, // optional SECURITY_ATTRIBUTES struct or IntPtr.Zero
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);
        
        [DllImportAttribute("kernel32.dll", SetLastError = true, EntryPoint = "CreateFile")]
        public static extern SafeFileHandle CreateFileW(
            [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)] string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            [InAttribute()] System.IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            [InAttribute()] System.IntPtr hTemplateFile
        );
        public static void Main(string[] args)
        {

            string path = @"D:\test\text.txt";

            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            OSHandle osHandle = new OSHandle();
            osHandle.Handle = fs.Handle;
            Console.WriteLine(osHandle.Handle);
            osHandle.Dispose();
            byte[] info = Encoding.Unicode.GetBytes(path);
            try
            {
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}