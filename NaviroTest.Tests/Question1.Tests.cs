using NUnit.Framework;

namespace NaviroTest.Tests
{
    public class Question1_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckForNull()
        {
            Assert.IsTrue(Question1.IsNullOrEmpty(null));
        }

        [Test]
        public void CheckForEmptyString()
        {
            Assert.IsTrue(Question1.IsNullOrEmpty(""));
        }

        [Test]
        public void CheckForValidString()
        {
            Assert.IsFalse(Question1.IsNullOrEmpty("Test"));
        }

        [Test]
        public void CheckForValidString_null()
        {
            Assert.IsFalse(Question1.IsNullOrEmpty("null"));
        }
    }
}