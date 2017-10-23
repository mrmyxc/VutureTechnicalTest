using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuture.CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             *Console.WriteLine(returnOccurences('e', "donuts are the best and the best"));
             *Console.WriteLine(isPalindrome("Civic"));
             *Console.WriteLine(isPalindrome("Anna"));
             *Console.WriteLine(isPalindrome("Amy, must I jujitsu my ma?"));
            

            List<string> words = new List<string>();
            words.Add("cat");
            words.Add("dog");
            words.Add("large");
            string sentence = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";

            returnWordOccurences(words, sentence);
            

            List<string> anotherlist = new List<string>();
            anotherlist.Add("meow");
            anotherlist.Add("woof");
            string anothersentence = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";
            Console.WriteLine(censorWordsinSentence(anotherlist, anothersentence));

            List<string> breakdown = breakSentenceDown("I have. a cat named Meow.  .");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < breakdown.Count; i ++)
            {
                sb.Append(breakdown[i]);
            }
            Console.WriteLine(sb.ToString());*/

            Console.WriteLine(censorPalindromes("Anna went to vote in the election to fulfil her civic duty"));




            Console.ReadKey();
        }

        /// <summary>
        /// Task 1
        /// counts the number of occurrences of a given letter in a string.
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="mString"></param>
        /// <returns></returns>
        public static int returnOccurences (char letter, string mString)
        {
            int occurences = 0;
            foreach (char character in mString)
            {
                if(character == letter)
                {
                    ++occurences;
                }
            }
            return occurences;
        }

        /// <summary>
        /// Task 2
        /// returns true if a string is a palindrome.
        /// </summary>
        /// <param name="mString"></param>
        /// <returns></returns>
        public static bool isPalindrome(string mString)
        {
            StringBuilder newStringBuilder = new StringBuilder();

            /* create new string without punctuations and spaces */
            foreach (char character in mString)
            {
                if (char.IsLetter(character))
                {
                    newStringBuilder.Append(character);
                }
            }
            mString = newStringBuilder.ToString().ToLower();

            /* checks if the ends of the string are equal with two cursors moving towards the center of the string 
             *returns false once the cursors aren't the same characters
             */
            int iterations = mString.Length / 2;
            int j = mString.Length - 1;
            for (int i = 0; i < iterations; i++, j--)
            {
                if (mString[i] != mString[j])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Task 3A
        /// counts the number of occurrences of words from a "censored words list" in a text and returns value in a dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mString"></param>
        public static Dictionary<string, int>  returnWordOccurences (List<string> censoredWordsList, string text)
        {
            /* initialise dictionary with keys and 0 occurences*/
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in censoredWordsList)
            {
                dictionary.Add(word, 0);
            }
            List<string> listOfStrings = breakSentenceDown(text);

            foreach (string censoredWord in censoredWordsList)
            {
                foreach (string word in listOfStrings)
                {
                    if (censoredWord == word)
                    {
                        dictionary[word] += 1;
                    }
                }
            }

            return dictionary;
            
        }

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

        /// <summary>
        /// Task 3B
        /// censors words featured in the "censored words list" that appear in the text.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mString"></param>
        /// <returns></returns>
        public static string censorWordsinSentence (List<string> censoredWordsList, string text)
        {
            StringBuilder sb = new StringBuilder();
            List<string> words = breakSentenceDown(text);

            /* censor words which are present in both Lists, in the words List  */
            for (int i = 0; i < censoredWordsList.Count; i ++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (censoredWordsList[i].ToLower() == words[j].ToLower())
                    {
                        words[j] = censorWord(words[j]);
                    }
                }
            }
            
            foreach(string word in words)
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
        public static string censorWord (string word)
        {
            char[] newString = word.ToCharArray();
            for (int i = 1; i < word.Length - 1; i++)
            {
                newString[i] = '$';
            }
            return new string (newString);
        }

        /// <summary>
        /// Task 3C
        /// censor single word palindromes in a text.
        /// </summary>
        /// <param name="mString"></param>
        /// <returns></returns>
        public static string censorPalindromes (string mString)
        {
            StringBuilder sb = new StringBuilder();
            List<string> words = breakSentenceDown(mString);
            int iterations = words.Count;
            for (int i = 0; i < iterations; i++)
            {
                if (isPalindrome(words[i]))
                {
                    words[i] = censorWord(words[i]);
                }
                sb.Append(words[i]);
            }

            return sb.ToString();
        }
    }

    /*
     * Console input at start of application
     * ask user for input during application life
     * 
     */
}
