using System;

namespace BinarySemaphore
{
    public interface IMutex
    {
        void Lock();
        void Unlock();
    }
}