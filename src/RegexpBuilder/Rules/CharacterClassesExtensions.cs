using Acamti.RegexpBuilder.Types;

namespace Acamti.RegexpBuilder.Rules
{
    public static class CharacterClassesExtensions
    {
        public static RegExpPattern WithAnyOneWordCharacter(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\w"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneWordOfCharacterType(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.AddRule(new RegExpValue(@"\p{" + $"{WordCharacter.GetValue(wordCharType)}" + "}"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneNonWordCharacter(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\W"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneWordNotOfCharacterType(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.AddRule(new RegExpValue(@"\P{" + $"{WordCharacter.GetValue(wordCharType)}" + "}"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneDigitCharacter(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\d"));

            return pattern;
        }

        public static RegExpPattern WithCharacter(this RegExpPattern pattern, char character)
        {
            pattern.AddRule(new RegExpValue($"\\u{char.ConvertToUtf32(character.ToString(), 0):X4}"));

            return pattern;
        }

        public static RegExpPattern WithCharacter(
            this RegExpPattern pattern,
            CharacterClass.CharacterClassType character)
        {
            pattern.AddRule(new RegExpValue($"\\u{CharacterClass.GetValue(character)}"));

            return pattern;
        }

        public static RegExpPattern WithCharacterRange(
            this RegExpPattern pattern,
            char from,
            char to)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}]"));

            return pattern;
        }

        public static RegExpPattern WithCharacterRangeWithException(
            this RegExpPattern pattern,
            char from,
            char to,
            char exception)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}-[{exception}]]"));

            return pattern;
        }

        public static RegExpPattern WithCharacterRangeWithException(
            this RegExpPattern pattern,
            char from,
            char to,
            char exceptionFrom,
            char exceptionTo)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}-[{exceptionFrom}-{exceptionTo}]]"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneOfTheseCharacters(
            this RegExpPattern pattern,
            string characters)
        {
            pattern.AddRule(new RegExpValue($"[{Tools.Escape(characters)}]"));

            return pattern;
        }

        public static RegExpPattern WithAnyOneOfNotTheseCharacters(
            this RegExpPattern pattern,
            string characters)
        {
            pattern.AddRule(new RegExpValue($"[^{Tools.Escape(characters)}]"));

            return pattern;
        }
    }
}
