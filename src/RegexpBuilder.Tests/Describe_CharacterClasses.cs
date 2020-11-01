using Acamti.RegexpBuilder.Rules;
using Acamti.RegexpBuilder.Types;
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

            var pattern = new RegExpPattern()
                .WithAnyOneWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .WithAnyOneNonWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        public void Test_Word_Of_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\p{" + value + "}";

            var pattern = new RegExpPattern()
                .WithAnyOneWordOfCharacterType(wordType);

            pattern.ToString().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Non_Word_Of_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .WithAnyOneNonWordCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        public void Test_Word_Of_None_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\P{" + value + "}";

            var pattern = new RegExpPattern()
                .WithAnyOneWordNotOfCharacterType(wordType);

            pattern.ToString().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var pattern = new RegExpPattern()
                .WithAnyOneDigitCharacter();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
