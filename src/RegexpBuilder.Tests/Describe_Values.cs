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
            const string EXPECTED = "(winter)";
            const string TRUE_MATCH_INPUT = "The winter season is coming";
            const string FALSE_MATCH_INPUT = "The summer season is coming";

            var pattern = RegExpPattern
                .With()
                .Value("winter");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            pattern.IsMatch(TRUE_MATCH_INPUT).Should().BeTrue();
            pattern.IsMatch(FALSE_MATCH_INPUT).Should().BeFalse();
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
            pattern.IsMatch(TRUE_MATCH_INPUT).Should().BeTrue();
            pattern.IsMatch(FALSE_MATCH_INPUT).Should().BeFalse();
        }

        [TestMethod]
        public void Test_Repeat_Pattern()
        {
            const string EXPECTED = "^(6?6?6?)";

            var pattern = RegExpPattern
                .StartWith()
                .Repeat(p => p.ZeroOrOne(p2 => p2.Value("6")), 3, true);

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
