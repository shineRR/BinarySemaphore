using System;
using System.IO;
using System.Text;

namespace BinarySemaphore
{
    public class OSHandleServiceTest
    {
        private const string Path = @"C:\Users\shine\Desktop\Dev\text.txt";
        private static readonly OSHandle OsHandle = new OSHandle();
        
        public OSHandleServiceTest(string text)
        {
            var fs = File.Open(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
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
                Console.WriteLine("[EXCEPTION]Invalid Handler");
            }
        }
    }
}