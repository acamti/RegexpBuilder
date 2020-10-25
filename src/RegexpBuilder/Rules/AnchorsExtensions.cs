using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class AnchorsExtensions
    {
        public static RegExpPattern Word(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool beginningBoundary = true,
            bool endingBoundary = true)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var beginningBoundaryRule = beginningBoundary
                ? @"\b"
                : string.Empty;

            var endingBoundaryRule = endingBoundary
                ? @"\b"
                : string.Empty;

            pattern.Value($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}");

            return pattern;
        }

        public static RegExpPattern NonWord(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool beginningBoundary = true,
            bool endingBoundary = true)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var beginningBoundaryRule = beginningBoundary
                ? @"\B"
                : string.Empty;

            var endingBoundaryRule = endingBoundary
                ? @"\B"
                : string.Empty;

            pattern.Value($"{beginningBoundaryRule}{ruleToExtract}{endingBoundaryRule}");

            return pattern;
        }
    }
}
