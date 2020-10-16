using System;

namespace BinarySemaphore
{
    public interface IMutex: IDisposable
    {
        void Enter();
        void Leave();
    }
}