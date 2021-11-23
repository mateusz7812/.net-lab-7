using System;
using Xunit;

namespace Tests
{
    public class UnitTestMixedNumber
    {
        [Fact]
        public void TestConstructorEasy()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 1, 0, 1);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(0, mixedNumber.L);
            Assert.Equal(1, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorMedium()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 1, 2, 3);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(2, mixedNumber.L);
            Assert.Equal(3, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorHard()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 1, 3, 2);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(2, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(2, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorDefaultC()
        {
            MixedNumber mixedNumber = new MixedNumber(false, -4, 0, 1);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(0, mixedNumber.C);
            Assert.Equal(0, mixedNumber.L);
            Assert.Equal(1, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorDefaultL()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 4, -5, 1);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(4, mixedNumber.C);
            Assert.Equal(0, mixedNumber.L);
            Assert.Equal(1, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorDefaultM()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 4, 0, -4);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(4, mixedNumber.C);
            Assert.Equal(0, mixedNumber.L);
            Assert.Equal(1, mixedNumber.M);
        }

        [Fact]
        public void TestConstructorDefaultMHarder()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 4, 1, -4);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(5, mixedNumber.C);
            Assert.Equal(0, mixedNumber.L);
            Assert.Equal(1, mixedNumber.M);
        }

        [Fact]
        public void TestSecondConstructor()
        {
            MixedNumber mixedNumber = new MixedNumber(-4, 1, 4);
            Assert.True(mixedNumber.Zn);
            Assert.Equal(4, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(4, mixedNumber.M);
        }

        [Fact]
        public void TestThirdConstructor1()
        {
            MixedNumber mixedNumber = new MixedNumber(5, 4);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(4, mixedNumber.M);
        }

        [Fact]
        public void TestThirdConstructor2()
        {
            MixedNumber mixedNumber = new MixedNumber(-5, 4);
            Assert.True(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(4, mixedNumber.M);
        }

        [Fact]
        public void TestThirdConstructor3()
        {
            MixedNumber mixedNumber = new MixedNumber(5, -4);
            Assert.True(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(4, mixedNumber.M);
        }

        [Fact]
        public void TestThirdConstructor4()
        {
            MixedNumber mixedNumber = new MixedNumber(-5, -4);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(1, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(4, mixedNumber.M);
        }


        [Fact]
        public void TestSmallestDenominator()
        {
            MixedNumber mixedNumber = new MixedNumber(10, 20);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(0, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(2, mixedNumber.M);
        }

        [Fact]
        public void TestChangeDecominator()
        {
            MixedNumber mixedNumber = new MixedNumber(10, 13);
            Assert.False(mixedNumber.Zn);
            Assert.Equal(0, mixedNumber.C);
            Assert.Equal(10, mixedNumber.L);
            Assert.Equal(13, mixedNumber.M);
            mixedNumber.M = 4;
            Assert.False(mixedNumber.Zn);
            Assert.Equal(2, mixedNumber.C);
            Assert.Equal(1, mixedNumber.L);
            Assert.Equal(2, mixedNumber.M);
        }

        [Fact]
        public void TestAddTwoNumbers()
        {
            MixedNumber m1 = new MixedNumber(3, 4);
            MixedNumber m2 = new MixedNumber(7, 4);
            MixedNumber result = m1 + m2;
            Assert.False(result.Zn);
            Assert.Equal(2, result.C);
            Assert.Equal(1, result.L);
            Assert.Equal(2, result.M);
        }

        [Fact]
        public void TestAddTwoNumbersOneIsNegative()
        {
            MixedNumber m1 = new MixedNumber(3, 4);
            MixedNumber m2 = new MixedNumber(-7, 4);
            MixedNumber result = m1 + m2;
            Assert.True(result.Zn);
            Assert.Equal(1, result.C);
            Assert.Equal(0, result.L);
            Assert.Equal(16, result.M);
        }

        [Fact]
        public void TestIsGreater1()
        {
            MixedNumber m1 = new MixedNumber(5, 4);
            MixedNumber m2 = new MixedNumber(4, 3);
            Assert.False(m1 > m2);
        }

        [Fact]
        public void TestIsGreater2()
        {
            MixedNumber m1 = new MixedNumber(-5, 4);
            MixedNumber m2 = new MixedNumber(4, 3);
            Assert.False(m1 > m2);
        }

        [Fact]
        public void TestIsGreater3()
        {
            MixedNumber m1 = new MixedNumber(5, 4);
            MixedNumber m2 = new MixedNumber(-4, 3);
            Assert.True(m1 > m2);
        }

        [Fact]
        public void TestIsGreater4()
        {
            MixedNumber m1 = new MixedNumber(-5, 4);
            MixedNumber m2 = new MixedNumber(-4, 3);
            Assert.True(m1 > m2);
        }

        [Fact]
        public void TestToDouble()
        {
            MixedNumber m = new MixedNumber(-5, 4);
            Assert.Equal(-1.25, m.ToDouble);
        }

        [Fact]
        public void TestToString()
        {
            MixedNumber m = new MixedNumber(-5, 4);
            Assert.Equal("-5/4", m.ToString());
        }

        [Fact]
        public void TestDeconstruct()
        {
            MixedNumber mixedNumber = new MixedNumber(false, 5, 1, 4);
            bool zn;
            int c, l, m; 
            mixedNumber.Deconstruct(out zn, out c, out l, out m);
            Assert.False(zn);
            Assert.Equal(5, c);
            Assert.Equal(1, l);
            Assert.Equal(4, m);        
        }
    }
}
