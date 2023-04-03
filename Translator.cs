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
            string translatedWord = "";
            string endWord = "ay";
            if (isVowel(word[0])) endWord = "yay";
            int flag = 0;
            for(int i=0; i<word.Length; i++) {
                if (isVowel(word[i])){
                    translatedWord += word.Substring(i) + word.Substring(0,i) + endWord;
                    flag = 1;
                    break;
                }

            }
            return flag == 1 ? translatedWord : word;
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

