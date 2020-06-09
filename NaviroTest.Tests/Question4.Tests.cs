using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaviroTest.Tests
{
    class Question4_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckForInput_1()
        {
            int[] numArr = new int[] { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 };
            var q4 = new Question4();
            var result = q4.GetMostCommon(numArr);

            Assert.AreEqual(2, result.Length);
            Assert.That(result, Contains.Item(5));
            Assert.That(result, Contains.Item(4));
        }

        [Test]
        public void CheckForInput_2()
        {
            int[] numArr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var q4 = new Question4();
            var result = q4.GetMostCommon(numArr);

            Assert.AreEqual(numArr.Length, result.Length);
            foreach(int num in numArr)
            {
                Assert.That(result, Contains.Item(num));
            }
        }

        [Test]
        public void CheckForInput_3()
        {
            int[] numArr = new int[] { 1, 2, 3, 4, 5, 1, 6, 7 };
            var q4 = new Question4();
            var result = q4.GetMostCommon(numArr);

            Assert.AreEqual(1, result.Length);
            Assert.That(result, Contains.Item(1));
        }
    }
}
