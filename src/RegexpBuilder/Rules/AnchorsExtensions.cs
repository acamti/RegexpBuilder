using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class AnchorsExtensions
    {
        public static RegExpPattern WithWordBoundary(
            this RegExpPattern pattern,
            bool atStart,
            bool atEnd,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var beginningBoundaryRule = atStart
                ? @"\b"
                : string.Empty;

            var endingBoundaryRule = atEnd
                ? @"\b"
                : string.Empty;

            pattern.AddRule(new RegExpValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}"));

            return pattern;
        }

        public static RegExpPattern WithWordBoundary(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule) =>
            pattern.WithWordBoundary(true, true, rule);

        public static RegExpPattern WithNonWordBoundary(
            this RegExpPattern pattern,
            bool atStart,
            bool atEnd,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var beginningBoundaryRule = atStart
                ? @"\B"
                : string.Empty;

            var endingBoundaryRule = atEnd
                ? @"\B"
                : string.Empty;

            pattern.AddRule(new RegExpValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}"));

            return pattern;
        }

        public static RegExpPattern WithNonWordBoundary(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule) =>
            pattern.WithNonWordBoundary(true, true, rule);

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

        public static RegExpPattern AtEndOfStringOrLine(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"$"));

            return pattern;
        }

        public static RegExpPattern AtStartOfStringOrLine(this RegExpPattern pattern)
        {
            pattern.AddRule(new RegExpValue(@"^"));

            return pattern;
        }
    }
}
