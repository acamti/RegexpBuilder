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
                .ZeroOrMoreOf(false, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_Text_Pattern()
        {
            const string EXPECTED = "s*";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(false, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Character_Pattern()
        {
            const string EXPECTED = "a+b";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(false, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Test_Pattern()
        {
            const string EXPECTED = "s+";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(false, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Character_Pattern()
        {
            const string EXPECTED = "a?b";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(false, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Text_Pattern()
        {
            const string EXPECTED = "s?";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(false, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a*?b";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(true, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_As_Few_As_Possible_Text_Pattern()
        {
            const string EXPECTED = "s*?";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(true, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_More_Grouped_Text_Pattern()
        {
            const string EXPECTED = "(s)*";

            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(false, true, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_Grouped_Text_Pattern()
        {
            const string EXPECTED = "(s)+";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(false, true, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_Grouped_Text_Pattern()
        {
            const string EXPECTED = "(s)?";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(false, true, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a+?b";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(true, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_One_Or_More_As_Few_As_Possible_Test_Pattern()
        {
            const string EXPECTED = "s+?";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(true, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_As_Few_As_Possible_Character_Pattern()
        {
            const string EXPECTED = "a??b";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(true, false, p => p.Text("a"))
                .Text("b");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Zero_Or_One_As_Few_As_Possible_Text_Pattern()
        {
            const string EXPECTED = "s??";

            var pattern = new RegExpPattern()
                .ZeroOrOneOf(true, false, p => p.Text("s"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Time_Pattern()
        {
            const string EXPECTED = "A{3}";

            var pattern = new RegExpPattern()
                .Time(3, p => p.Text("A"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Time_From_To_Pattern()
        {
            const string EXPECTED = "A{1,3}";

            var pattern = new RegExpPattern()
                .Time(1, 3, p => p.Text("A"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_TimeAtLeast_Pattern()
        {
            const string EXPECTED = "A{3,}";

            var pattern = new RegExpPattern()
                .TimeAtLeast(3, p => p.Text("A"));

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
