using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace TPUM.ServerPresentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Action<String> d = message => Console.WriteLine(message);

            try
            {
                using (CommunicationManager node = new CommunicationManager(8081, d))
                {
                    await node.InitServerAsync();
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The aplikcation has been handled by the exception {ex}");
            }
        }
    }
}
