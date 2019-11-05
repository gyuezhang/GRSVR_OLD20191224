using GRSVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvrStartConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GRServer server = new GRServer();

            if (!server.Setup(6666))
                Console.WriteLine("Failed to setup GRSVR!");
            if (!server.Start())
                Console.WriteLine("Start GRSVR Failed!");

            Console.WriteLine("Start GRSVR succeed!,Press q to exit!");
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            server.Stop();
        }
    }
}
