using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Quantifiers
    {
        [TestMethod]
        public void Test_Zero_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a*b";

            var pattern = new RegExpPattern()
                .WithZeroOrMore(p => p.WithValue("a"))
                .WithValue("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_Text_Pattern()
        {
            const string EXPECTED = "(?:dog)*s";

            var pattern = new RegExpPattern()
                .WithZeroOrMore(p => p.WithValue("dog"))
                .WithValue("s");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a+b";

            var pattern = new RegExpPattern()
                .WithOneOrMore(p => p.WithValue("a"))
                .WithValue("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Test_Pattern()
        {
            const string EXPECTED = "(?:cat)+s";

            var pattern = new RegExpPattern()
                .WithOneOrMore(p => p.WithValue("cat"))
                .WithValue("s");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Character_Pattern()
        {
            const string EXPECTED = "a?b";

            var pattern = new RegExpPattern()
                .WithZeroOrOne(p => p.WithValue("a"))
                .WithValue("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Text_Pattern()
        {
            const string EXPECTED = "(?:duck)?s";

            var pattern = new RegExpPattern()
                .WithZeroOrOne(p => p.WithValue("duck"))
                .WithValue("s");

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
