using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Constructs
    {
        [TestMethod]
        public void Test_Either_Constructs_Pattern()
        {
            const string EXPECTED = @"him|her";

            var pattern = RegExpPattern
                .With()
                .Either(
                    i => i.Value("him"),
                    i => i.Value("her")
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Conditional_Constructs_Pattern()
        {
            const string EXPECTED = @"(?(\wi\w)him|her)";

            var pattern = RegExpPattern
                .With()
                .ConditionallyRule(
                    p => p
                        .AnyOneWordCharacter()
                        .Value("i")
                        .AnyOneWordCharacter(),
                    p => p.Value("him"),
                    p => p.Value("her")
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X(\d)F";

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("X")
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("F");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X\1F";

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("X")
                .GroupValue(0)
                .Value("F");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Named_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(?<One>\d)x\k<One>F";

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), "One")
                .Value("x")
                .GroupValue("One")
                .Value("F");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
