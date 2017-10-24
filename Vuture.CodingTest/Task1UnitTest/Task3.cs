using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vuture.CodingTest;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class Task3
    {
        [TestMethod]
        public void numberOfWordOccurencesTest()
        {
            Counter counter = new Counter();

            List<string> inputCensoredList = new List<string> { "cat", "dog", "large" };

            string inputText = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";

            Dictionary<string, int> expectedOutput = 
                new Dictionary<string, int> { { "cat", 1 }, { "dog", 2 }, { "large", 1 } };

            Dictionary<string, int> actualOutput = counter.returnWordOccurences(inputCensoredList, inputText);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void censorWordsTest()
        {
            Censor censor = new Censor();

            List<string> inputCensoredList = new List<string> { "meow", "woof" };

            string inputText = "I have a cat named Meow and a dog named Woof. I love the dog a lot. He is larger than a small horse.";

            string expectedOutput = "I have a cat named M$$w and a dog named W$$f. I love the dog a lot. He is larger than a small horse.";

            string actualOutput = censor.censorWordsinSentence(inputCensoredList, inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void censorPalindromesTest()
        {
            Censor censor = new Censor();

            string inputText = "Anna went to vote in the election to fulfil her civic duty";

            string expectedOutput = "A$$a went to vote in the election to fulfil her c$$$c duty";

            string actualOutput = censor.censorPalindromes(inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
