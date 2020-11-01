using Acamti.RegexpBuilder.Types;

namespace Acamti.RegexpBuilder.Rules
{
    public static class CharacterClassesExtensions
    {
        public static RegExpPattern WithAnyOneWordCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\w");

            return pattern;
        }

        public static RegExpPattern WithAnyOneWordOfCharacterType(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.WithValue(@"\p{" + $"{WordCharacter.GetValue(wordCharType)}" + "}");

            return pattern;
        }

        public static RegExpPattern WithAnyOneNonWordCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\W");

            return pattern;
        }

        public static RegExpPattern WithAnyOneWordNotOfCharacterType(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.WithValue(@"\P{" + $"{WordCharacter.GetValue(wordCharType)}" + "}");

            return pattern;
        }

        public static RegExpPattern WithAnyOneDigitCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\d");

            return pattern;
        }

        public static RegExpPattern WithCharacter(this RegExpPattern pattern, char character)
        {
            pattern.WithValue($"\\u{char.ConvertToUtf32(character.ToString(), 0):X4}");

            return pattern;
        }
    }
}
