using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vuture.CodingTest;

namespace UnitTests
{
    [TestClass]
    public class Task1
    {
        [TestMethod]
        public void numberOfOccurencesTest()
        {
            Counter counter = new Counter();

            char inputChar = 'e';

            string inputText = "I have some cheese";

            int expectedOutput = 5;

            int actualOutput = counter.returnOccurences(inputChar, inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [TestClass]
    public class Task2
    {
        [TestMethod]
        public void PalindromeTest_True()
        {
            string input = "A lad named E. Mandala";

            bool expectedOutput = true;

            bool actualOutput = PalindromeDetector.isPalindrome(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void PalindromeTest_False()
        {
            string input = "A lad namad E. Mandala";

            bool expectedOutput = false;

            bool actualOutput = PalindromeDetector.isPalindrome(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
