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
                .AnyWordCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .AnyNonWordCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        [DataRow(WordCharacter.WordCharacterType.UpperCase, "Lu")]
        [DataRow(WordCharacter.WordCharacterType.TitleCase, "Lt")]
        [DataRow(WordCharacter.WordCharacterType.Other, "Lo")]
        [DataRow(WordCharacter.WordCharacterType.Modifier, "Lm")]
        [DataRow(WordCharacter.WordCharacterType.NonSpacing, "Mn")]
        [DataRow(WordCharacter.WordCharacterType.DecimalDigit, "Nd")]
        [DataRow(WordCharacter.WordCharacterType.Punctuation, "P")]
        public void Test_Word_Of_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\p{" + value + "}";

            var pattern = new RegExpPattern()
                .WordCharacter(wordType);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Non_Word_Of_Pattern()
        {
            const string EXPECTED = @"\W";

            var pattern = new RegExpPattern()
                .AnyNonWordCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        [DataRow(WordCharacter.WordCharacterType.LowerCase, "Ll")]
        public void Test_Word_Of_None_Pattern(WordCharacter.WordCharacterType wordType, string value)
        {
            var expected = @"\P{" + value + "}";

            var pattern = new RegExpPattern()
                .WordCharacterOtherThan(wordType);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Digit_Pattern()
        {
            const string EXPECTED = @"\d";

            var pattern = new RegExpPattern()
                .AnyOneDigit();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Unicode_Character_Pattern()
        {
            const string EXPECTED = @"\u0064";

            var pattern = new RegExpPattern()
                .Character('d', true);

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
        [DataRow(EscapeCharacter.EscapeCharacterType.WhiteSpace, "\\s")]
        [DataRow(EscapeCharacter.EscapeCharacterType.NonWhiteSpace, "\\S")]
        public void Test_Escaped_Character_Pattern(EscapeCharacter.EscapeCharacterType type, string expected)
        {
            var pattern = new RegExpPattern()
                .Character(type);

            pattern.ToString().Should().Be(expected);
        }

        [TestMethod]
        public void Test_Range_Pattern()
        {
            const string EXPECTED = "[A-Z]";

            var pattern = new RegExpPattern()
                .CharacterRange('A', 'Z');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Range_With_Exception_Pattern()
        {
            const string EXPECTED = "[A-Z-[N]]";

            var pattern = new RegExpPattern()
                .CharacterRange('A', 'Z', 'N');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Range_With_Range_Exception_Pattern()
        {
            const string EXPECTED = "[A-Z-[M-P]]";

            var pattern = new RegExpPattern()
                .CharacterRange('A', 'Z', 'M', 'P');

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_Pattern()
        {
            const string EXPECTED = "[ae]";

            var pattern = new RegExpPattern()
                .AnyCharacter("ae");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_2_Pattern()
        {
            const string EXPECTED = "[\\te]";

            var pattern = new RegExpPattern()
                .AnyCharacter(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('e', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_3_Pattern()
        {
            const string EXPECTED = "[\\t\\*]";

            var pattern = new RegExpPattern()
                .AnyCharacter(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Any_Of_One_Character_4_Pattern()
        {
            const string EXPECTED = "[\\t\\u002A]";

            var pattern = new RegExpPattern()
                .AnyCharacter(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', true));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_Pattern()
        {
            const string EXPECTED = "[^aei]";

            var pattern = new RegExpPattern()
                .AnyCharacterOtherThan("aei");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_3_Pattern()
        {
            const string EXPECTED = "[^\\t\\*]";

            var pattern = new RegExpPattern()
                .AnyCharacterOtherThan(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', false));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Negative_Any_Of_One_Character_4_Pattern()
        {
            const string EXPECTED = "[^\\t\\u002A]";

            var pattern = new RegExpPattern()
                .AnyCharacterOtherThan(
                    new RegExpCharacter(EscapeCharacter.EscapeCharacterType.Tab),
                    new RegExpCharacter('*', true));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Wild_Char_Pattern()
        {
            const string EXPECTED = ".";

            var pattern = new RegExpPattern()
                .AnyCharacter();

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
