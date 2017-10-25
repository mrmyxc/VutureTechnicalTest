using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuture.CodingTest
{
    public class Program
    {
        static void Main(string[] args)
        {

        }        
    }

    public class PalindromeDetector
    {
        /// <summary>
        /// Task 2
        /// returns true if a string is a palindrome.
        /// </summary>
        /// <param name="mString"></param>
        /// <returns></returns>
        public bool isPalindrome(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            /* create new string without punctuations and spaces */
            text = removePunctuation(text).ToLower();

            /* checks if the ends of the string are equal with two cursors moving towards the center of the string 
             *returns false once the cursors aren't the same characters
             */
            int iterations = text.Length / 2;
            int j = text.Length - 1;
            for (int i = 0; i < iterations; i++, j--)
            {
                if (text[i] != text[j])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// returns a string with punctuation and white spaces removed
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string removePunctuation (string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char character in text)
            {
                if (char.IsLetter(character))
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }

    public class Censor
    {
        /// <summary>
        /// Task 3B
        /// censors words featured in the "censored words list" that appear in the text.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mString"></param>
        /// <returns></returns>
        public string censorWordsinSentence(List<string> censoredWordsList, string text)
        {
            
            /* null/empty string and list check */
            if (string.IsNullOrEmpty(text) || !censoredWordsList.Any<string>())
            {
                return text;
            }
            StringBuilder sb = new StringBuilder();
            List<string> words = Utils.breakSentenceDown(text);

            /* censor words which are present in both Lists, in the words List  */
            for (int i = 0; i < censoredWordsList.Count; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (censoredWordsList[i].ToLower() == words[j].ToLower())
                    {
                        words[j] = censorWord(words[j]);
                    }
                }
            }

            foreach (string word in words)
            {
                sb.Append(word);
            }
            return sb.ToString();
        }

        /// <summary>
        /// censors a single word by replacing all characters apart from start and end with '$'
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string censorWord(string word)
        {
            char[] newString = word.ToCharArray();
            for (int i = 1; i < word.Length - 1; i++)
            {
                newString[i] = '$';
            }
            return new string(newString);
        }

        /// <summary>
        /// Task 3C
        /// censor single word palindromes in a text.
        /// </summary>
        /// <param name="mString"></param>
        /// <returns></returns>
        public string censorPalindromes(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            PalindromeDetector palindromeDetector = new PalindromeDetector();
            StringBuilder sb = new StringBuilder();
            List<string> words = Utils.breakSentenceDown(text);
            int iterations = words.Count;
            for (int i = 0; i < iterations; i++)
            {
                if (palindromeDetector.isPalindrome(words[i]))
                {
                    words[i] = censorWord(words[i]);
                }
                sb.Append(words[i]);
            }

            return sb.ToString();
        }
    }

    public class Counter
    {
        /// <summary>
        /// Task 1
        /// counts the number of occurrences of a given letter in a string.
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="mString"></param>
        /// <returns></returns>
        public int returnOccurences(char letter, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            int occurences = 0;

            foreach (char c in text)
            {
                if (c == letter) occurences++;
            }

            return occurences;
        }

        /// <summary>
        /// Task 3A
        /// counts the number of occurrences of words from a "censored words list" in a text and returns value in a dictionary
        /// including as substrings
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mString"></param>
        public Dictionary<string, int> returnWordOccurences(List<string> censoredWordsList, string text)
        {
            /* null/empty string and list check */
            if (string.IsNullOrEmpty(text) || !censoredWordsList.Any<string>())
            {
                return null;
            }
            /* initialise dictionary with keys and 0 occurences */
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string censoredWord in censoredWordsList)
            {
                dictionary.Add(censoredWord, 0);
            }
            List<string> words = Utils.breakSentenceDown(text);
           
            foreach (string censoredWord in censoredWordsList)
            {
                foreach (string word in words)
                {
                    if (word == censoredWord || word.Contains(censoredWord)) dictionary[censoredWord]++;
                }
            }

            return dictionary;

        }
    }

    public class Utils
    {  
        /// <summary>
        /// breaks a sentence into a list of strings
        /// preserves spaces and punctuation
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static List<string> breakSentenceDown(string text)
        {
            List<string> words = new List<string>();
            StringBuilder sb = new StringBuilder();

            /* create a string and append to List when the current char is not a letter */
            foreach (char character in text)
            {
                /* add current sb to List then reset sb and add character to List as a new entry */
                if (!char.IsLetter(character))
                {
                    words.Add(sb.ToString());
                    sb.Length = 0;
                    words.Add(sb.Append(character).ToString());
                    sb.Length = 0;
                }
                else
                {
                    sb.Append(character);
                }
            }
            /* add last sb item to List */
            words.Add(sb.ToString());
            return words;
        }
    }
}
