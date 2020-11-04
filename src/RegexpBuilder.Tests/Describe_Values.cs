using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Values
    {
        [TestMethod]
        public void Test_Simple_Text_Pattern()
        {
            const string EXPECTED = "winter";

            var pattern = new RegExpPattern()
                .WithValue("winter");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Simple_Character_Pattern()
        {
            const string EXPECTED = "1";

            var pattern = new RegExpPattern()
                .WithValue("1");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Repeat_Pattern()
        {
            const string EXPECTED = "(?:6?6?6?)";

            var pattern = new RegExpPattern()
                .WithGroupOf(
                    p => p.Repeat(
                        r => r.WithZeroOrOneOf(p2 => p2.WithValue("6")),
                        3
                    )
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_LookAhead_Pattern()
        {
            const string EXPECTED = "a(?=b)";

            var pattern = new RegExpPattern()
                .OnlyIfAheadIs(p => p.WithValue("b"), p => p.WithValue("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_LookAhead_Pattern()
        {
            const string EXPECTED = "a(?!b)";

            var pattern = new RegExpPattern()
                .OnlyIfAheadIsNot(p => p.WithValue("b"), p => p.WithValue("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_LookBehind_Pattern()
        {
            const string EXPECTED = "(?<=c)a";

            var pattern = new RegExpPattern()
                .OnlyIfBehindIs(p => p.WithValue("c"), p => p.WithValue("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_LookBehind_Pattern()
        {
            const string EXPECTED = "(?<!c)a";

            var pattern = new RegExpPattern()
                .OnlyIfBehindIsNot(p => p.WithValue("c"), p => p.WithValue("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(".")]
        [DataRow("$")]
        [DataRow("^")]
        [DataRow("{")]
        [DataRow("[")]
        [DataRow("(")]
        [DataRow("|")]
        [DataRow(")")]
        [DataRow("*")]
        [DataRow("+")]
        [DataRow("?")]
        [DataRow("\\")]
        public void Test_Escaped_Special_Character_Pattern(string special)
        {
            var expected = @"\" + special;

            var pattern = new RegExpPattern()
                .WithValue(special);

            pattern.ToString().Should().Be(expected);
        }
    }
}
