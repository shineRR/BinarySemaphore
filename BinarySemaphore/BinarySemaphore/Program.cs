
namespace BinarySemaphore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SemaphoreServiceTest mutex = new SemaphoreServiceTest(200);
            OSHandleServiceTest osHandleServiceTest = new OSHandleServiceTest("New text");
        }
    }
}