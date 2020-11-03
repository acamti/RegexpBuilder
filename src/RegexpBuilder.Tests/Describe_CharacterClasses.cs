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

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .WithAnyOneNonWordCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        public void Test_Word_Of_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\p{" + value + "}";

            var pattern = new RegExpPattern()
                .WithAnyOneWordOfCharacterType(wordType);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Non_Word_Of_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .WithAnyOneNonWordCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        public void Test_Word_Of_None_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\P{" + value + "}";

            var pattern = new RegExpPattern()
                .WithAnyOneWordNotOfCharacterType(wordType);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var pattern = new RegExpPattern()
                .WithAnyOneDigitCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Unicode_Character_Pattern()
        {
            const string EXPECTED = @"\u0064";

            var pattern = new RegExpPattern()
                .WithCharacter('d');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(CharacterClass.CharacterClassType.Bell, "0007")]
        [DataRow(CharacterClass.CharacterClassType.BackSpace, "0008")]
        [DataRow(CharacterClass.CharacterClassType.Tab, "0009")]
        [DataRow(CharacterClass.CharacterClassType.CarriageReturn, "000D")]
        [DataRow(CharacterClass.CharacterClassType.VerticalTab, "000B")]
        [DataRow(CharacterClass.CharacterClassType.FormFeed, "000C")]
        [DataRow(CharacterClass.CharacterClassType.NewLine, "000A")]
        [DataRow(CharacterClass.CharacterClassType.Escape, "001B")]
        public void Test_Escaped_Character_Pattern(CharacterClass.CharacterClassType type, string value)
        {
            var expected = @"\u" + value;

            var pattern = new RegExpPattern()
                .WithCharacter(type);

            pattern.ToString().Should().Be(expected);
        }
    }
}
