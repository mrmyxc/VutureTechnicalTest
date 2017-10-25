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


        [TestMethod]
        public void numberOfOccurencesTest_EmptyString()
        {
            Counter counter = new Counter();

            char inputChar = 'e';

            string inputText = "";

            int expectedOutput = 0;

            int actualOutput = counter.returnOccurences(inputChar, inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void numberOfOccurencesTest_Spaces()
        {
            Counter counter = new Counter();

            char inputChar = ' ';

            string inputText = "I have some cheese";

            int expectedOutput = 3;

            int actualOutput = counter.returnOccurences(inputChar, inputText);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
