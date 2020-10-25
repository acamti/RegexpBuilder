namespace Acamti.RegexpBuilder.Rules
{
    public static class CharacterClassesExtensions
    {
        public static RegExpPattern AnyOneWordCharacter(this RegExpPattern pattern)
        {
            pattern.Value(@"\w", false);

            return pattern;
        }

        public static RegExpPattern AnyOneNonWordCharacter(this RegExpPattern pattern)
        {
            pattern.Value(@"\W", false);

            return pattern;
        }

        public static RegExpPattern AnyOneDigitCharacter(this RegExpPattern pattern)
        {
            pattern.Value(@"\d", false);

            return pattern;
        }
    }
}
