using System.Linq;
using Acamti.RegexpBuilder.Types;
using Acamti.RegexpBuilder.Types.RegExpCharacter;

namespace Acamti.RegexpBuilder.Rules
{
    public static class CharacterClassesExtensions
    {
        public static RegExpPattern AnyWordCharacter(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\w"));

            return pattern;
        }

        public static RegExpPattern WordCharacter(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.AddRule(new RegExpValue($"{new RegExpCharacter(wordCharType, true)}"));

            return pattern;
        }

        public static RegExpPattern AnyNonWordCharacter(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\W"));

            return pattern;
        }

        public static RegExpPattern WordCharacterOtherThan(
            this RegExpPattern pattern,
            WordCharacter.WordCharacterType wordCharType)
        {
            pattern.AddRule(new RegExpValue($"{new RegExpCharacter(wordCharType, false)}"));

            return pattern;
        }

        public static RegExpPattern AnyOneDigit(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\d"));

            return pattern;
        }

        public static RegExpPattern AnyCharacter(
            this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue("."));

            return pattern;
        }

        public static RegExpPattern Character(
            this RegExpPattern pattern,
            char character,
            bool asUnicodeValue
        )
        {
            pattern.AddRule(new RegExpValue($"{new RegExpCharacter(character, asUnicodeValue)}"));

            return pattern;
        }

        public static RegExpPattern Character(
            this RegExpPattern pattern,
            EscapeCharacter.EscapeCharacterType character)
        {
            pattern.AddRule(new RegExpValue($"{new RegExpCharacter(character)}"));

            return pattern;
        }

        public static RegExpPattern AnyCharacter(
            this RegExpPattern pattern,
            params RegExpCharacter[] characters)
        {
            var concatChars = characters
                .Aggregate(string.Empty,
                           (seed, character) => seed + character
                );

            pattern.AddRule(new RegExpValue($"[{concatChars}]"));

            return pattern;
        }

        public static RegExpPattern AnyCharacter(
            this RegExpPattern pattern,
            string characters)
        {
            var concatChars = characters
                .Aggregate(string.Empty,
                           (seed, character) =>
                               seed + new RegExpCharacter(character, false)
                );

            pattern.AddRule(new RegExpValue($"[{concatChars}]"));

            return pattern;
        }

        public static RegExpPattern AnyCharacterOtherThan(
            this RegExpPattern pattern,
            params RegExpCharacter[] characters)
        {
            var concatChars = characters
                .Aggregate(string.Empty,
                           (seed, character) => seed + character
                );

            pattern.AddRule(new RegExpValue($"[^{concatChars}]"));

            return pattern;
        }

        public static RegExpPattern AnyCharacterOtherThan(
            this RegExpPattern pattern,
            string characters)
        {
            var concatChars = characters
                .Aggregate(string.Empty,
                           (seed, character) =>
                               seed + new RegExpCharacter(character, false)
                );

            pattern.AddRule(new RegExpValue($"[^{concatChars}]"));

            return pattern;
        }

        public static RegExpPattern CharacterRange(
            this RegExpPattern pattern,
            char from,
            char to)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}]"));

            return pattern;
        }

        public static RegExpPattern CharacterRange(
            this RegExpPattern pattern,
            char from,
            char to,
            char exception)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}-[{exception}]]"));

            return pattern;
        }

        public static RegExpPattern CharacterRange(
            this RegExpPattern pattern,
            char from,
            char to,
            char exceptionFrom,
            char exceptionTo)
        {
            pattern.AddRule(new RegExpValue($"[{from}-{to}-[{exceptionFrom}-{exceptionTo}]]"));

            return pattern;
        }
    }
}
