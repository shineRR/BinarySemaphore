using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BinarySemaphore
{
    public class OSHandleServiceTest
    {
        private const string Path = @"D:\test\text.txt";
        private static readonly OSHandle OsHandle = new OSHandle();
        
        public OSHandleServiceTest(string text)
        {
            FileStream fs = File.Open(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            OsHandle.Handle = fs.Handle;
            OsHandle.Dispose();
            
            WriteToFile(fs, text);
        }

        void WriteToFile(FileStream fs, string text)
        {
            byte[] info = Encoding.Unicode.GetBytes(text);
            try
            {
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Handler");
            }
        }
    }
}