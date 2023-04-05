using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace week_3
{
    internal class Translator
    {
        private char[] voewls = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I','O', 'U' };
        public bool isVowel(char letter)
        {
            return voewls.Contains(letter);
        }

        public string Translate(string word)
        {
           
            bool isUpperCase = Char.IsUpper(word[0]);
            if (isVowel(word[0])) return word + "yay";
            string translatedWord = "";
            for (int i=0; i<word.Length; i++) {
                if (isVowel(word[i])){
                    if (isUpperCase)
                    {
                        translatedWord += word.Substring(i, 1).ToUpper() + word.Substring(i+1) + word.Substring(0, i).ToLower() + "ay";
                    }
                    else
                    {
                        translatedWord += word.Substring(i) + word.Substring(0, i) + "ay";
                    }
                    
                    break;
                }

            }
            return translatedWord;
        }
        public string PigLatinTranslator(string messageToTranslate)
        {
            string translatedMessage = "";
            string[] words = messageToTranslate.Split(' ');
            foreach (string word in words)
            {
                if(Regex.IsMatch(word, @"^[a-zA-z]+$"))
                {
                    translatedMessage += Translate(word);
                }
                else
                {
                    translatedMessage += Translate(word.Substring(0,word.Length - 2));
                    translatedMessage += word[word.Length - 1];

                }
               
                translatedMessage += " ";
            }
            return translatedMessage;
        }
    }
}

