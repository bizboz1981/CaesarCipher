using System;
using System.Collections.Generic;
using System.Linq;

namespace CaesarCipher
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a secret message:");
            string msg = Console.ReadLine();

            Console.WriteLine("Please choose a key:");
            int key = Convert.ToInt32(Console.ReadLine());


            string secretMessage = CaesarCipher(msg, key);
            Console.WriteLine(secretMessage);

            Console.WriteLine(Decrypt(secretMessage, key));


        }
        static string CaesarCipher(string message, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            
            //message = (Console.ReadLine()).ToLower(); // get user input and convert to lower case
            char[] secretMessage = message.ToCharArray(); // convert string to char array (original message)
            int wordLength = secretMessage.Length; // get length of char array


            char[] encryptedMessage = new char[wordLength]; //new empty array same length as secret message

            char[] specialChars = new char[] { ' ', '!', '?', ',', '.' }; // define array of special characters

            // loop through each letter in array and reassign index by 3 positions
            for (int i = 0; i < secretMessage.Length; i++)
            {
                char letter = secretMessage[i]; // identifies each consecutive char in array and stores as var 'letter'
                if (specialChars.Contains(letter)) // if 'letter' is a special char in specialChars array... 
                {
                    encryptedMessage[i] = letter; //... assign the same value for the encrypted message...
                    continue; // ...and loop back to beginning
                }
                int index = Array.IndexOf(alphabet, letter);
                int encryptIndex = (index + key) % alphabet.Length; // for a-z chars, shift position by +3...
                char newChar = alphabet[encryptIndex]; // ...save it as a var...
                encryptedMessage[i] = newChar; // assign that var to correct position in encrypted array
            }
            string codedMsg = String.Join("", encryptedMessage); // concatenate array of encrypted lettersm 
            return codedMsg;
        }
        
        static string Decrypt(string message, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


            //message = (Console.ReadLine()).ToLower(); // get user input and convert to lower case
            char[] secretMessage = message.ToCharArray(); // convert string to char array (original message)
            int wordLength = secretMessage.Length; // get length of char array

            char[] decryptedMessage = new char[wordLength]; //new empty array same length as secret message

            char[] specialChars = new char[] { ' ', '!', '?', ',', '.' }; // define array of special characters

            // loop through each letter in array and reassign index by {-key} positions
            for (int i = 0; i < secretMessage.Length; i++)
            {
                char letter = secretMessage[i]; // identifies each consecutive char in array and stores as var 'letter'
                if (specialChars.Contains(letter)) // if 'letter' is a special char in specialChars array... 
                {
                    decryptedMessage[i] = letter; //... assign the same value for the encrypted message...
                    continue; // ...and loop back to beginning
                }

                int index = Array.IndexOf(alphabet, letter);
                int encryptIndex = index - key;// for a-z chars, shift position by -key...
                char newChar = alphabet[encryptIndex]; // ...save it as a var...
                decryptedMessage[i] = newChar; // assign that var to correct position in encrypted array
            }
            string decodedMsg = String.Join("", decryptedMessage); // concatenate array of encrypted lettersm 
            return decodedMsg;
        }
    }
}