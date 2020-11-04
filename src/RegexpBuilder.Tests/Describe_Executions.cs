using System;
using System.Text.RegularExpressions;
using Acamti.RegexpBuilder.Rules;
using Acamti.RegexpBuilder.Types;
using Acamti.RegexpBuilder.Types.RegExpCharacter;
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
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
                .WithValue("X")
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
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
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), "One")
                .WithValue("X")
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), "Two")
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
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), true)
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
                .WithGroupOf(p => p.WithAnyOneDigitCharacter(), "One")
                .WithValue("X")
                .WithGroupValue("One")
                .WithValue("F");

            pattern.Groups("0X0F").Should().BeEquivalentTo(expected);
            pattern.Groups("0X1F").Should().NotBeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Character_Escape_Matching_And_Grouping()
        {
            const string EXPECTED_REGEX_PATTERN = @"\G(.+)[\t\u007C](.+)\r?\n";

            var pattern = new RegExpPattern()
                .ByOnlyMatchingWherePreviousMatchEnded()
                .WithGroupOf(
                    p1 => p1.WithOneOrMoreOf(p2 => p2.WithAnyOneCharacter()),
                    true)
                .WithAnyOneOfTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('|', true))
                .WithGroupOf(
                    p1 => p1.WithOneOrMoreOf(p2 => p2.WithAnyOneCharacter()),
                    true)
                .WithZeroOrOneOf(p => p.WithCharacter(EscapeCharacter.EscapeCharacterType.CarriageReturn))
                .WithCharacter(EscapeCharacter.EscapeCharacterType.NewLine);

            pattern.ToString().Should().Be(EXPECTED_REGEX_PATTERN);

            const string INPUT = "Mumbai, India|13,922,125\t\n" +
                "Shanghai, China\t13,831,900\n" +
                "Karachi, Pakistan|12,991,000\n" +
                "Delhi, India\t12,259,230\n" +
                "Istanbul, Turkey|11,372,613\n";

            Console.WriteLine("Population of the World's Largest Cities, 2009");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,10}", "City", "Population");
            Console.WriteLine();

            foreach (Match match in pattern.Matches(INPUT))
            {
                Console.WriteLine("{0,-20} {1,10}",
                                  match.Groups[1].Value,
                                  match.Groups[2].Value);
            }
        }
    }
}
