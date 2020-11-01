namespace Acamti.RegexpBuilder.Rules
{
    public static class CharacterClassesExtensions
    {
        public static RegExpPattern WithAnyOneWordCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\w");

            return pattern;
        }

        public static RegExpPattern WithAnyOneNonWordCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\W");

            return pattern;
        }

        public static RegExpPattern WithAnyOneDigitCharacter(this RegExpPattern pattern)
        {
            pattern.WithValue(@"\d");

            return pattern;
        }
    }
}
