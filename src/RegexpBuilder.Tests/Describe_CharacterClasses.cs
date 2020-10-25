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

            var pattern = RegExpPattern
                .With()
                .AnyOneWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = RegExpPattern
                .With()
                .AnyOneNonWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var pattern = RegExpPattern
                .With()
                .AnyOneDigitCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
