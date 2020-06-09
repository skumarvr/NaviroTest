using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaviroTest.Tests
{
    class Question2_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckForZero()
        {
            uint num = 0;
            var q2 = new Question2();
            var ex = Assert.Throws<ArgumentException>(() => q2.GetPostiveDivisors(num));

            Assert.AreEqual("value of num must be greater than 0", ex.Message);
        }

        [Test]
        public void Check_Positive_Divisors_For_1()
        {
            uint num = 1;
            var q2 = new Question2();
            var result = q2.GetPostiveDivisors(num);
            Assert.That(new uint[] { 1 }, Is.EquivalentTo(result));
        }

        [Test]
        public void Check_Positive_Divisors_For_60()
        {
            uint num = 60;
            var q2 = new Question2();
            var result = q2.GetPostiveDivisors(num);
            Assert.That(new uint[] { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 }, Is.EquivalentTo(result));
        }

        [Test]
        public void Check_Positive_Divisors_For_42()
        {
            uint num = 42;
            var q2 = new Question2();
            var result = q2.GetPostiveDivisors(num);
            Assert.That(new uint[] { 1, 2, 3, 6, 7, 14, 21, 42 }, Is.EquivalentTo(result));
        }
    }
}

