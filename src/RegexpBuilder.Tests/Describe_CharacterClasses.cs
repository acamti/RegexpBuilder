using System.Collections.Generic;
using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_CharacterClasses
    {
        [TestMethod]
        public void Test_Word_Pattern()
        {
            const string EXPECTED = @"\w";

            var trueMatchInputs = new List<string>(new[] { "a", "1" });
            var falseMatchInputs = new List<string>(new[] { ".", " " });

            var pattern = RegExpPattern
                .With()
                .AnyOneWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var trueMatchInputs = new List<string>(new[] { ".", " " });
            var falseMatchInputs = new List<string>(new[] { "a", "1" });

            var pattern = RegExpPattern
                .With()
                .AnyOneNonWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeFalse());
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var trueMatchInputs = new List<string>(new[] { "1" });
            var falseMatchInputs = new List<string>(new[] { "a", ".", " " });

            var pattern = RegExpPattern
                .With()
                .AnyOneDigitCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.IsMatch(t).Should().BeFalse());
        }
    }
}
