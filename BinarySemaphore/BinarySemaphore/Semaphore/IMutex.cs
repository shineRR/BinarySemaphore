using System;

namespace BinarySemaphore
{
    public interface IMutex: IDisposable
    {
        void Lock();
        void Unlock();
    }
}