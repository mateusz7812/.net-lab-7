using System;
using Xunit;
using lab7;

namespace Tests
{
    public class UnitTestChangeLetters
    {
        [Fact]
        public void TestEasy()
        {
            string str = "abcd";
            string changed = Program.ChangeLetters(str);
            Assert.Equal("aBcD", changed);
        }


        [Fact]
        public void TestMedium()
        {
            string str = "ab2cd3e5";
            string changed = Program.ChangeLetters(str);
            Assert.Equal("aB.Cd.e.", changed);
        }
    }
}