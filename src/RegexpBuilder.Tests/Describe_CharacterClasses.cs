using Acamti.RegexpBuilder.Rules;
using Acamti.RegexpBuilder.Types;
using Acamti.RegexpBuilder.Types.RegExpCharacter;
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
        [DataRow(EscapeCharacter.EscapeCharacterType.Bell, "\\a")]
        [DataRow(EscapeCharacter.EscapeCharacterType.BackSpace, "\\b")]
        [DataRow(EscapeCharacter.EscapeCharacterType.Tab, "\\t")]
        [DataRow(EscapeCharacter.EscapeCharacterType.CarriageReturn, "\\r")]
        [DataRow(EscapeCharacter.EscapeCharacterType.VerticalTab, "\\v")]
        [DataRow(EscapeCharacter.EscapeCharacterType.FormFeed, "\\f")]
        [DataRow(EscapeCharacter.EscapeCharacterType.NewLine, "\\n")]
        [DataRow(EscapeCharacter.EscapeCharacterType.Escape, "\\e")]
        public void Test_Escaped_Character_Pattern(EscapeCharacter.EscapeCharacterType type, string expected)
        {
            var pattern = new RegExpPattern()
                .WithCharacter(type);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Range_Pattern()
        {
            const string EXPECTED = "[A-Z]";

            var pattern = new RegExpPattern()
                .WithCharacterRange('A', 'Z');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Range_With_Exception_Pattern()
        {
            const string EXPECTED = "[A-Z-[N]]";

            var pattern = new RegExpPattern()
                .WithCharacterRangeWithException('A', 'Z', 'N');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Range_With_Range_Exception_Pattern()
        {
            const string EXPECTED = "[A-Z-[M-P]]";

            var pattern = new RegExpPattern()
                .WithCharacterRangeWithException('A', 'Z', 'M', 'P');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_Pattern()
        {
            const string EXPECTED = "[ae]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfTheseCharacters("ae");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_2_Pattern()
        {
            const string EXPECTED = "[\\te]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('e', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_3_Pattern()
        {
            const string EXPECTED = "[\\t\\*]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_4_Pattern()
        {
            const string EXPECTED = "[\\t\\u002A]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', true));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_Pattern()
        {
            const string EXPECTED = "[^aei]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfNotTheseCharacters("aei");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_3_Pattern()
        {
            const string EXPECTED = "[^\\t\\*]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfNotTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_4_Pattern()
        {
            const string EXPECTED = "[^\\t\\u002A]";

            var pattern = new RegExpPattern()
                .WithAnyOneOfNotTheseCharacters(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', true));

            pattern.ToString().Should().Be(EXPECTED);
        }
        
        [TestMethod]
        public void Test_Wild_Char_Pattern()
        {
            const string EXPECTED = ".";

            var pattern = new RegExpPattern()
                .WithAnyOneCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
