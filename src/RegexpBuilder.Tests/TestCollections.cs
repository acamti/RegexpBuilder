using System.Collections.Generic;
using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class TestCollections
    {
        [TestMethod]
        public void Test_Simple_Text_Pattern()
        {
            const string EXPECTED = "(winter)";
            const string TRUE_MATCH_INPUT = "The winter season is coming";
            const string FALSE_MATCH_INPUT = "The summer season is coming";

            var pattern = RegExpPattern
                .With()
                .Value("winter");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            pattern.Match(TRUE_MATCH_INPUT).Should().BeTrue();
            pattern.Match(FALSE_MATCH_INPUT).Should().BeFalse();
        }

        [TestMethod]
        public void Test_Simple_Character_Pattern()
        {
            const string EXPECTED = "1";
            const string TRUE_MATCH_INPUT = "The 1st day of the year";
            const string FALSE_MATCH_INPUT = "The 2nd day of the year";

            var pattern = RegExpPattern
                .With()
                .Value("1");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            pattern.Match(TRUE_MATCH_INPUT).Should().BeTrue();
            pattern.Match(FALSE_MATCH_INPUT).Should().BeFalse();
        }

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

        [TestMethod]
        public void Test_Word_Pattern()
        {
            const string EXPECTED = @"\w";

            var trueMatchInputs = new List<string>(new[] { "a", "1" });
            var falseMatchInputs = new List<string>(new[] { ".", " " });

            var pattern = RegExpPattern
                .With()
                .AnyOneWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var trueMatchInputs = new List<string>(new[] { ".", " " });
            var falseMatchInputs = new List<string>(new[] { "a", "1" });

            var pattern = RegExpPattern
                .With()
                .AnyOneNonWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var trueMatchInputs = new List<string>(new[] { "1" });
            var falseMatchInputs = new List<string>(new[] { "a", ".", " " });

            var pattern = RegExpPattern
                .With()
                .AnyOneDigitCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Or_Constructs_Pattern()
        {
            const string EXPECTED = @"(him|her)";

            var trueMatchInputs = new List<string>(new[] { "him", "her" });
            var falseMatchInputs = new List<string>(new[] { "they", "them" });

            var pattern = RegExpPattern
                .With()
                .Either(
                    p => p.Value("him", false),
                    p => p.Value("her", false)
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }
    }
}
