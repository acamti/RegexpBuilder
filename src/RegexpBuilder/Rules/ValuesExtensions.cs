using System;
using System.Linq;

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

        public static RegExpPattern Repeat(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            int time,
            bool withParentheses)
        {
            var rules = Enumerable.Range(0, time).Select(_ => rule.Invoke(RegExpPattern.With()));

            pattern.Value($"{rules.Aggregate("", (seed, r) => $"{seed}{r}")}", withParentheses);

            return pattern;
        }
    }
}
