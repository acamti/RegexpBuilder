using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class QuantifiersExtensions
    {
        public static RegExpPattern ZeroOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var retPattern = rule.Invoke(pattern);
            retPattern.AppendToLastRule("*");

            return retPattern;
        }

        public static RegExpPattern OneOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var retPattern = rule.Invoke(pattern);
            retPattern.AppendToLastRule("+");

            return retPattern;
        }

        public static RegExpPattern ZeroOrOne(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var retPattern = rule.Invoke(pattern);
            retPattern.AppendToLastRule("?");

            return retPattern;
        }
    }
}
