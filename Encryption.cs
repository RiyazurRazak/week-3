using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3
{
    internal class Encryption
    {

       
        public static void main(string[] args)
        {
            NicoCipher("edabitisamazing", "matt");

        }

        public static void NicoCipher(string message, string key)
        {
            List<char> sortedKey = key.ToCharArray().ToList();
            sortedKey.Sort();
            List<int> hashKey = new List<int>(key.Length);
            char previousKey = ' ';
            foreach(var c in key) {
                if (previousKey == c)
                {
                    hashKey.Add(sortedKey.IndexOf(c) + 1);
                }
                else
                {
                    hashKey.Add(sortedKey.IndexOf(c));
                   
                }
                previousKey = c;

            }
            int rowSpaceRequired = (int) Math.Ceiling((double) Decimal.Divide(message.Length ,key.Length));
            char[,] hashTable = new char [rowSpaceRequired, key.Length];
            char[,] resultTable = new char[rowSpaceRequired, key.Length];
            int messagePtr = 0;
            for (int rowItr = 0; rowItr < rowSpaceRequired; rowItr++)
            {
                for (int columnPtr = 0; columnPtr < key.Length; columnPtr++)
                {
                    
                    hashTable[rowItr, columnPtr] = ' ';
                }
            }
            for (int rowItr=0; rowItr < rowSpaceRequired; rowItr++)
            {
                for(int columnPtr=0; columnPtr<key.Length; columnPtr++)
                {
                    if(!(message.Length > messagePtr))
                    {
                        break;
                    }
                    hashTable[rowItr, columnPtr] = message[messagePtr++];
                }
            }

            foreach(int index in hashKey)
            {
                for (int rowItr = 0; rowItr < rowSpaceRequired; rowItr++)
                {
                    for (int columnPtr = 0; columnPtr < key.Length; columnPtr++)
                    {
                        resultTable[rowItr,index] = hashTable[rowItr, hashKey.IndexOf(index)];
                    }
                        
                }
            }
            for (int rowItr = 0; rowItr < rowSpaceRequired; rowItr++)
            {
                for (int columnPtr = 0; columnPtr < key.Length; columnPtr++)
                {
                    Console.Write(resultTable[rowItr, columnPtr]);
                }
                
            }

        }
    }
}



//In Nico Cipher, encoding is done by creating a numeric key and assigning each letter position of the message with the provided key.
//Create a function that takes two arguments, key and message, and returns the encoded message.
//There are some variations on the rules of encipherment. One version of the cipher rules are outlined below:
//message = "mubashirhassan"
//key = "crazy"
//nicoCipher(message, key) ➞ "bmusarhiahass n"
//Step 1: Assign numbers to sorted letters from the key:
//"crazy" = 23154
//Step 2: Assign numbers to the letters of the given message:
//2 3 1 5 4
//-------- -
//m u b a s
//h i r h a
//s s a n
//Step 3: Sort columns as per assigned numbers:
//1 2 3 4 5
//-------- -
//eMessage = "bmusarhiahass n"
//Examples
//NicoCipher("mubashirhassan", "crazy") ➞ "bmusarhiahass n"
//NicoCipher("edabitisamazing", "matt") ➞ "deabtiismaaznig "
//NicoCipher("iloveher", "612345") ➞ "lovehir    e"
//Notes
//Keys will have alphabets or numbers only.
//e d a b
//i t i s
//a m a z
//i n g