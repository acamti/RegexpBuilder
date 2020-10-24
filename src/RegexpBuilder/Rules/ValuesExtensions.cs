namespace Acamti.RegexpBuilder.Rules
{
    public static class ValuesExtensions
    {
        public static RegExpPattern Value(this RegExpPattern pattern, string value, bool withParentheses = true)
        {
            if ( string.IsNullOrEmpty(value) ) return pattern;

            pattern.AddRule(
                value.Length == 1
                    ? new RegExpValue(value)
                    : new RegExpValue(
                        withParentheses
                            ? $"({value})"
                            : value));

            return pattern;
        }
    }
}
