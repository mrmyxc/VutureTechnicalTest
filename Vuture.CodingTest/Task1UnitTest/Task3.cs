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
        public void numberOfWordOccurencesTest_LargerSet()
        {
            Counter counter = new Counter();

            List<string> inputCensoredList = new List<string> { "pet", "large", "I", "horse" };

            string inputText = "I have a large pet named Meow and the largest pet named Woof. I love the dog a lot. He is larger than a small horse.";

            Dictionary<string, int> expectedOutput =
                new Dictionary<string, int> { { "pet", 2 }, { "large", 3 }, { "I", 2 }, { "horse", 1 } };

            Dictionary<string, int> actualOutput = counter.returnWordOccurences(inputCensoredList, inputText);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void numberOfWordOccurencesTest_EmptyList()
        {
            Counter counter = new Counter();

            List<string> inputCensoredList = new List<string> { };

            string inputText = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";

            Dictionary<string, int> expectedOutput = null;

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
        public void censorWordsTest_EmptyList()
        {
            Censor censor = new Censor();

            List<string> inputCensoredList = new List<string> {};

            string inputText = "I have a cat named Meow and a dog named Woof. I love the dog a lot. He is larger than a small horse.";

            string expectedOutput = "I have a cat named Meow and a dog named Woof. I love the dog a lot. He is larger than a small horse.";

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

        [TestMethod]
        public void censorPalindromesTest_EmptyString()
        {
            Censor censor = new Censor();

            string inputText = " ";

            string expectedOutput = " ";

            string actualOutput = censor.censorPalindromes(inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void censorPalindromesTest_NoPalindromes()
        {
            Censor censor = new Censor();

            string inputText = "she went to vote in the election to fulfil her duty";

            string expectedOutput = "she went to vote in the election to fulfil her duty";

            string actualOutput = censor.censorPalindromes(inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
