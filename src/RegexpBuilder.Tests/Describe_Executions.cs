using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Executions
    {
        [TestMethod]
        public void Test_Split_Execution()
        {
            var expected = new[] { "012", "6789" };
            const string TRUE_MATCH_INPUT = "012-345-6789";
            const string FALSE_MATCH_INPUT = "(555)-555-5555";

            var pattern = RegExpPattern
                .With()
                .Value("-")
                .Repeat(p => p.AnyOneDigitCharacter(), 3)
                .Value("-");

            pattern.Split(TRUE_MATCH_INPUT).Should().BeEquivalentTo(expected);
            pattern.Split(FALSE_MATCH_INPUT).Should().NotBeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "1", "0" ),
                ( 2, "2", "1" )
            };

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("X")
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("F");

            pattern.Groups("0X1F").Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Named_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "One", "0" ),
                ( 2, "Two", "1" )
            };

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), "One")
                .Value("X")
                .Group(p => p.AnyOneDigitCharacter(), "Two")
                .Value("F");

            pattern.Groups("0X1F").Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_BackReference_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "1", "0" )
            };

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), true)
                .Value("X")
                .GroupValue(0)
                .Value("F");

            pattern.Groups("0X0F").Should().BeEquivalentTo(expected);
            pattern.Groups("0X1F").Should().NotBeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_BackReference_Named_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "One", "0" )
            };

            var pattern = RegExpPattern
                .With()
                .Group(p => p.AnyOneDigitCharacter(), "One")
                .Value("X")
                .GroupValue("One")
                .Value("F");

            pattern.Groups("0X0F").Should().BeEquivalentTo(expected);
            pattern.Groups("0X1F").Should().NotBeEquivalentTo(expected);
        }
    }
}
