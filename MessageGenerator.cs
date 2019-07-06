using System;
using System.Collections.Generic;

namespace minimalClient
{
    public class MessageGenerator
    {
        List<string> cubes = new List<string>();
        
        public string generateRandomChatMessage(string receiver)
        {
            string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[20];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new string(stringChars);
            return "{ \"type\" : \"chat\", \"receiver\" : \""+receiver+"\", \"content\" : \""+finalString+System.DateTime.Now.Ticks+"\" }"+"\n";
        }
        
        
        public int RandomNumber(int min, int max)  
        {  
            Random random = new Random();  
            return random.Next(min, max);  
        }

        public string generateRandomAddCubes(string sender,int range)
        {
            string pos=RandomNumber(-range,range)+","+RandomNumber(-range,range)+","+RandomNumber(-range,range);
            cubes.Add(pos);
            string mat=""+RandomNumber(0,11);
            return "{\"matIndex\":\""+mat+"\",\"type\":\"addCube\",\"position\":\""+pos+"\",\"sender\":\""+sender+"\"}"+"\n";
        }

        public string generateRandomRemoveCubes(string sender)
        {
            if (cubes.Count > 0)
            {
                int index = RandomNumber(0, cubes.Count);
                string pos = cubes[index];
                cubes.RemoveAt(index);
                return "{\"type\":\"removeCube\",\"position\":\""+pos+"\",\"sender\":\""+sender+"\"}"+"\n";
            }

            return null;
        }



    }
}