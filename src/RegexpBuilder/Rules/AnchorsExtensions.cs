using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class AnchorsExtensions
    {
        public static RegExpPattern WithWord(
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

            pattern.WithValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}");

            return pattern;
        }

        public static RegExpPattern WithNonWord(
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

            pattern.WithValue($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}");

            return pattern;
        }
    }
}
