using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vuture.CodingTest;

namespace Task1UnitTest
{
    [TestClass]
    public class Task2
    {
        [TestMethod]
        public void PalindromeTest_True()
        {
            PalindromeDetector palindromeDectector = new PalindromeDetector();

            string input = "A lad named E. Mandala";

            bool expectedOutput = true;

            bool actualOutput = palindromeDectector.isPalindrome(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void PalindromeTest_False()
        {
            PalindromeDetector palindromeDetector = new PalindromeDetector();

            string input = "A lad namad E. Mandala";

            bool expectedOutput = false;

            bool actualOutput = palindromeDetector.isPalindrome(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
