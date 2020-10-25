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

            var pattern = RegExpPattern
                .With()
                .ZeroOrMore(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_Text_Pattern()
        {
            const string EXPECTED = "(?:dog)*s";

            var pattern = RegExpPattern
                .With()
                .ZeroOrMore(p => p.Value("dog"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a+b";

            var pattern = RegExpPattern
                .With()
                .OneOrMore(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Test_Pattern()
        {
            const string EXPECTED = "(?:cat)+s";

            var pattern = RegExpPattern
                .With()
                .OneOrMore(p => p.Value("cat"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Character_Pattern()
        {
            const string EXPECTED = "a?b";

            var pattern = RegExpPattern
                .With()
                .ZeroOrOne(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Text_Pattern()
        {
            const string EXPECTED = "(?:duck)?s";

            var pattern = RegExpPattern
                .With()
                .ZeroOrOne(p => p.Value("duck"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
