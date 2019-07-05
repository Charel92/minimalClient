using System;

namespace minimalClient
{
    public class MessageGenerator
    {
        static public string generateRandomChatMessage(string receiver)
        {
            string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[20];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new string(stringChars);
            return "{ \"type\" : \"chat\", \"receiver\" : \""+receiver+"\", \"content\" : \""+finalString+"\" }";
        }

        
    }
}