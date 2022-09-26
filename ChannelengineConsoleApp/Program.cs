using BusinessClassLibrary;
using SimpleInjector;
using System;
using System.Threading;

namespace ChannelengineConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Application app = new Application();
                app.Test();
                app.ViewOrders();
                Thread.Sleep(5000);
                Console.WriteLine("Press any key to exit. ~ ");
                Console.ReadKey();
            }catch(Exception ex)
            {
                throw ex;
            }            
        }
    }
}
