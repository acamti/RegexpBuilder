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

            var pattern = new RegExpPattern()
                .WithValue("-")
                .Repeat(p => p.WithAnyOneDigitCharacter(), 3)
                .WithValue("-");

            pattern.Split("012-345-6789").Should().BeEquivalentTo(expected);
            pattern.Split("(555)-555-5555").Should().NotBeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "1", "0" ),
                ( 2, "2", "1" )
            };

            var pattern = new RegExpPattern()
                .WithGroup(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("X")
                .WithGroup(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("F");

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

            var pattern = new RegExpPattern()
                .WithGroup(p => p.WithAnyOneDigitCharacter(), "One")
                .WithValue("X")
                .WithGroup(p => p.WithAnyOneDigitCharacter(), "Two")
                .WithValue("F");

            pattern.Groups("0X1F").Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_BackReference_Grouping_Execution()
        {
            var expected = new[]
            {
                ( 0, "1", "0" )
            };

            var pattern = new RegExpPattern()
                .WithGroup(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("X")
                .WithGroupValue(0)
                .WithValue("F");

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

            var pattern = new RegExpPattern()
                .WithGroup(p => p.WithAnyOneDigitCharacter(), "One")
                .WithValue("X")
                .WithGroupValue("One")
                .WithValue("F");

            pattern.Groups("0X0F").Should().BeEquivalentTo(expected);
            pattern.Groups("0X1F").Should().NotBeEquivalentTo(expected);
        }
    }
}
