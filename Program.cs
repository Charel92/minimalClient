using System;
using System.Net.Sockets;
using System.Text;
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
            MinimalClient client1= new MinimalClient("Miniclient");
            client1.Work("localhost");
        }

        
    }
}
