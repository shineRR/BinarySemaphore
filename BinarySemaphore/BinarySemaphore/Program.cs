
namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SemaphoreServiceTest mutex = new SemaphoreServiceTest(10);
            OSHandleServiceTest osHandleServiceTest = new OSHandleServiceTest("New text");
        }
    }
}