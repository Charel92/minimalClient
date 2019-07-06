using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace minimalClient
{
    public class MinimalClient
    {
        Int32 port = 4321;
        private TcpClient client;
        private NetworkStream stream;
        string receiver = "Superjhemp";
        String name;

        public MinimalClient(String name)
        {
            this.name = name;
        }

        private void Connect()
        {
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer 
            // connected to the same address as specified by the server, port
            // combination.
            string message = "{\"type\":\"hello\",\"name\":\"" + name + "\"}" + "\n";
            client = new TcpClient("localhost", port);
            Console.WriteLine(message);

            // Translate the passed message into UTF8 and store it as a Byte array.
            byte[] data = Encoding.UTF8.GetBytes(message);

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();

            stream = client.GetStream();

            // Send the message to the connected TcpServer. 

            //System.Threading.Thread.Sleep(3000);

            stream.Write(data, 0, data.Length);
            Console.WriteLine(name + " sent: " + message);


            // Receive the TcpServer.response.

           
                // Buffer to store the response bytes.
            data = new Byte[1024];

                // String to store the response ASCII representation.
            String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            

            // Close everything.
        }

        public void sendMessage(object o)
        {
            string message=(string)o;
                
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);
        }

        public void Work()
        {
            try
            {
                
                //Listener listener=new Listener(stream);
                /*Thread clientReceiveThread = new Thread(Connect);
                clientReceiveThread.IsBackground = true;
                clientReceiveThread.Start();*/
                Connect();

                
                //string msg = MessageGenerator.generateRandomChatMessage();
                sendMessage("{ \"type\" : \"chat\", \"receiver\" : \"" + receiver + "\", \"content\" : \"Hello cube\" }"+"\n");
                //Console.WriteLine(msg);
                
                Thread cubesThread =new Thread(sendMultipleCubeMessages);
                cubesThread.Start();
                
                
                MessageGenerator generator=new MessageGenerator();
                
                
                
                
                
                
                Thread newThread = new Thread(sendMessage);
                Console.WriteLine("Start newThread...\n");
                newThread.Start(generator.generateRandomChatMessage(receiver));
                
                for(int i=0;i<30;i++)
                {
                    sendMessage("{ \"type\" : \"chat\", \"receiver\" : \"" + receiver + "\", \"content\" : \""+System.DateTime.Now.Ticks+"\" }"+"\n");
                }
                
                Thread.Sleep(3000);
                
                
                 //Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
            Close();

        }

        void Close()
        {
            //NetworkStream stream=client.GetStream();
            stream.Close();
                client.Close();
            
        }

        void sendMultipleChatMessages()
        {
            
        }
        void sendMultipleCubeMessages()
        {
            
            MessageGenerator generator=new MessageGenerator();
            for (int i = 0; i < 5000; i++)
            {
                int rndm=generator.RandomNumber(0, 3);
                if (rndm==1)
                {
                    string msg = generator.generateRandomRemoveCubes("MiniClient1");
                    if (msg!= null)
                    {
                        sendMessage(msg);
                    }
                    
                }
                else
                {
                    sendMessage(generator.generateRandomAddCubes("MiniClient1",50));
                }
            }
            //Console.Write(name+" finished");
        }
        
        
        
        
        

        void listener()
        {
            while (true)
            {
                // Get a stream object for reading 		
                using (NetworkStream stream = client.GetStream())
                {
                }

            }

        }
    }
}