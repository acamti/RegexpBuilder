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
                .ZeroOrMoreOf(p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_Text_Pattern()
        {
            const string EXPECTED = "s*";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a+b";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Test_Pattern()
        {
            const string EXPECTED = "s+";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Character_Pattern()
        {
            const string EXPECTED = "a?b";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Text_Pattern()
        {
            const string EXPECTED = "s?";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a*?b";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(p => p.Text("a"), true)
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_As_Few_As_Possible_Text_Pattern()
        {
            const string EXPECTED = "s*?";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(
                    p => p.Text("s"),
                    true);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a+?b";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(p => p.Text("a"), true)
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_As_Few_As_Possible_Test_Pattern()
        {
            const string EXPECTED = "s+?";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(
                    p => p.Text("s"),
                    true);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a??b";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(p => p.Text("a"), true)
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_As_Few_As_Possible_Text_Pattern()
        {
            const string EXPECTED = "s??";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(
                    p => p.Text("s"),
                    true);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Time_Pattern()
        {
            const string EXPECTED = "A{3}";

            var pattern = new RegExpPattern()
                .Time(p => p.Text("A"), 3);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Time_From_To_Pattern()
        {
            const string EXPECTED = "A{1,3}";

            var pattern = new RegExpPattern()
                .Time(p => p.Text("A"), 1, 3);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_TimeAtLeast_Pattern()
        {
            const string EXPECTED = "A{3,}";

            var pattern = new RegExpPattern()
                .TimeAtLeast(p => p.Text("A"), 3);

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
