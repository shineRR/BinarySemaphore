namespace BinarySemaphore
{
    public interface IAtomicBool
    {
        bool SetTrue();
        bool SetFalse();
    }
}