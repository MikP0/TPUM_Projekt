using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace TPUM.ServerPresentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Action<String> logger = message => Console.WriteLine(message);

            try
            {
                using (CommunicationManager node = new CommunicationManager(Int32.Parse(Properties.Resources.PortNumber), logger))
                {
                    await node.InitServerAsync();
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown by the application: {ex}");
            }
        }
    }
}
