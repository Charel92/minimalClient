using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using minimalClient;


namespace minimalClient
{
    class 
        Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ServerController.Start();
            MinimalClient client1= new MinimalClient("Miniclient1");
            //client1.Work("localhost");
            Thread worker1 = new Thread(client1.Work);
            
            
            MinimalClient client2= new MinimalClient("Miniclient2");
            //client1.Work("localhost");
            Thread worker2 = new Thread(client2.Work);
 
            // Den Parameter in die Methode DoWork übertragen.
            worker1.Start();
            Thread.Sleep(50);
            worker2.Start();
        }

        
    }
}
