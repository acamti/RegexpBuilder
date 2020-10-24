using System.Collections.Generic;
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

            var trueMatchInputs = new List<string>(new[] { "b", "ab", "aab", "aab" });
            var falseMatchInputs = new List<string>(new[] { "a" });

            var pattern = RegExpPattern
                .With()
                .ZeroOrMore(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Zero_Or_More_Text_Pattern()
        {
            const string EXPECTED = "(dog)*s";

            var trueMatchInputs = new List<string>(new[] { "s", "dogs", "dogdogs" });
            var falseMatchInputs = new List<string>(new[] { "dog" });

            var pattern = RegExpPattern
                .With()
                .ZeroOrMore(p => p.Value("dog"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_One_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a+b";

            var trueMatchInputs = new List<string>(new[] { "ab", "aab", "abb" });
            var falseMatchInputs = new List<string>(new[] { "a", "b" });

            var pattern = RegExpPattern
                .With()
                .OneOrMore(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_One_Or_More_Test_Pattern()
        {
            const string EXPECTED = "(cat)+s";

            var trueMatchInputs = new List<string>(new[] { "cats", "catcats", "catss" });
            var falseMatchInputs = new List<string>(new[] { "cat", "s" });

            var pattern = RegExpPattern
                .With()
                .OneOrMore(p => p.Value("cat"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Zero_Or_One_Character_Pattern()
        {
            const string EXPECTED = "a?b";

            var trueMatchInputs = new List<string>(new[] { "b", "ab", "aab", "abb" });
            var falseMatchInputs = new List<string>(new[] { "a" });

            var pattern = RegExpPattern
                .With()
                .ZeroOrOne(p => p.Value("a"))
                .Value("b");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Zero_Or_One_Text_Pattern()
        {
            const string EXPECTED = "(duck)?s";

            var trueMatchInputs = new List<string>(new[] { "s", "ducks", "duckducks", "duckss" });
            var falseMatchInputs = new List<string>(new[] { "duck" });

            var pattern = RegExpPattern
                .With()
                .ZeroOrOne(p => p.Value("duck"))
                .Value("s");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }
    }
}
