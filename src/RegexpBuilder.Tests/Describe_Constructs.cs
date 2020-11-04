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

            var pattern = new RegExpPattern()
                .WithEither(
                    i => i.WithValue("him"),
                    i => i.WithValue("her")
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Conditional_Constructs_Pattern()
        {
            const string EXPECTED = @"(?(\wi\w)him|her)";

            var pattern = new RegExpPattern()
                .WithConditionalRule(
                    p => p
                        .WithAnyOneWordCharacter()
                        .WithValue("i")
                        .WithAnyOneWordCharacter(),
                    p => p.WithValue("him"),
                    p => p.WithValue("her")
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X(\d)F";

            var pattern = new RegExpPattern()
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("X")
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("F");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X\1F";

            var pattern = new RegExpPattern()
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("X")
                .WithGroupValue(0)
                .WithValue("F");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Named_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(?<One>\d)x\k<One>F";

            var pattern = new RegExpPattern()
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), "One")
                .WithValue("x")
                .WithGroupValue("One")
                .WithValue("F");

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
