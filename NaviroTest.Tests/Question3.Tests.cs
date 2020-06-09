using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaviroTest.Tests
{
    class Question3_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckForZero()
        {
            int a = 0, b = 0, c = 0;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideA()
        {
            int a = 0, b = 2, c = 3;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideB()
        {
            int a = 1, b = 0, c = 3;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideC()
        {
            int a = 1, b = 2, c = 0;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideAB()
        {
            int a = 0, b = 0, c = 3;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideBC()
        {
            int a = 1, b = 0, c = 0;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForZero_SideCA()
        {
            int a = 0, b = 2, c = 0;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Negative inputs", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_AB_lt_C()
        {
            int a = 1, b = 2, c = 4;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_AC_lt_B()
        {
            int a = 1, b = 4, c = 2;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_BC_lt_A()
        {
            int a = 4, b = 1, c = 2;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_AB_eq_C()
        {
            int a = 1, b = 2, c = 3;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_AC_eq_B()
        {
            int a = 1, b = 3, c = 2;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForInvalidTriangle_BC_eq_A()
        {
            int a = 3, b = 1, c = 2;
            var q3 = new Question3();
            var ex = Assert.Throws<InvalidTriangleException>(() => q3.CalculateArea(a, b, c));

            Assert.AreEqual("Inputs cannot form a valid triangle", ex.Message);
        }

        [Test]
        public void CheckForValidValues()
        {
            int a = 3, b = 4, c = 5;
            var q3 = new Question3();
            var area = q3.CalculateArea(a, b, c);

            Assert.AreEqual(6, area);
        }
    }
}
