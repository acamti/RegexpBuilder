using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class QuantifiersExtensions
    {
        private static string GetFewAsPossibleValue(bool asFewAsPossible)
        {
            var fewAsPossibleValue = asFewAsPossible
                ? "?"
                : string.Empty;

            return fewAsPossibleValue;
        }

        public static RegExpPattern ZeroOrMoreOf(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}*{GetFewAsPossibleValue(asFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern OneOrMoreOf(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}+{GetFewAsPossibleValue(asFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern ZeroOrOneOf(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}?{GetFewAsPossibleValue(asFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern Time(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            int from)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{from}}}"));

            return pattern;
        }

        public static RegExpPattern Time(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            int from,
            int to)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{from},{to}}}"));

            return pattern;
        }
    }
}
