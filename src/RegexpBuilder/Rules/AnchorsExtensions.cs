using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class AnchorsExtensions
    {
        public static RegExpPattern WithWordBoundary(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool beginningBoundary = true,
            bool endingBoundary = true)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var beginningBoundaryRule = beginningBoundary
                ? @"\b"
                : string.Empty;

            var endingBoundaryRule = endingBoundary
                ? @"\b"
                : string.Empty;

            pattern.AddRule(new RegExpValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}"));

            return pattern;
        }

        public static RegExpPattern WithNonWordBoundary(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool beginningBoundary = true,
            bool endingBoundary = true)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var beginningBoundaryRule = beginningBoundary
                ? @"\B"
                : string.Empty;

            var endingBoundaryRule = endingBoundary
                ? @"\B"
                : string.Empty;

            pattern.AddRule(new RegExpValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}"));

            return pattern;
        }

        public static RegExpPattern ByOnlyMatchingWherePreviousMatchEnded(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\G"));

            return pattern;
        }

        public static RegExpPattern AtEndOfStringOnly(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\z"));

            return pattern;
        }

        public static RegExpPattern AtEndOfStringOrBeforeNewLine(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"\Z"));

            return pattern;
        }
    }
}
