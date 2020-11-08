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
                .Text("winter");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Simple_Character_Pattern()
        {
            const string EXPECTED = "1";

            var pattern = new RegExpPattern()
                .Text("1");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Repeat_Pattern()
        {
            const string EXPECTED = "6?6?6?";

            var pattern = new RegExpPattern()
                .Repeat(3, r => r.Text("6?", false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_LookAhead_Pattern()
        {
            const string EXPECTED = "a(?=b)";

            var pattern = new RegExpPattern()
                .OnlyIfAheadIs(p => p.Text("b"), p => p.Text("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_LookAhead_Pattern()
        {
            const string EXPECTED = "a(?!b)";

            var pattern = new RegExpPattern()
                .OnlyIfAheadIsNot(p => p.Text("b"), p => p.Text("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_LookBehind_Pattern()
        {
            const string EXPECTED = "(?<=c)a";

            var pattern = new RegExpPattern()
                .OnlyIfBehindIs(p => p.Text("c"), p => p.Text("a"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_LookBehind_Pattern()
        {
            const string EXPECTED = "(?<!c)a";

            var pattern = new RegExpPattern()
                .OnlyIfBehindIsNot(p => p.Text("c"), p => p.Text("a"));

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
                .Text(special);

            pattern.ToString().Should().Be(expected);
        }
    }
}
