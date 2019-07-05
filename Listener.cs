using System;
using System.Net.Sockets;


namespace minimalClient
{
    
    public class Listener
    {
        NetworkStream stream;
        
        public void listen()
        {

            while (!_shouldStop)
            {
                Byte[] data = new Byte[1024];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData); 
            }
        }
        public Listener(NetworkStream stream)
        {
            this.stream = stream;
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        
        private volatile bool _shouldStop;
    }
}