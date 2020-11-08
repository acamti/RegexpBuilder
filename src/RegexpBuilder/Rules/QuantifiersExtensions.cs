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
            bool isFewAsPossible,
            bool isGrouped,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            if ( isGrouped )
            {
                var groupedRuleToAdd = new RegExpPattern()
                    .GroupOf(true, p => ruleToAdd);

                pattern.AddRule(new RegExpValue($"{groupedRuleToAdd}*{GetFewAsPossibleValue(isFewAsPossible)}"));

                return pattern;
            }

            pattern.AddRule(new RegExpValue($"{ruleToAdd}*{GetFewAsPossibleValue(isFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern OneOrMoreOf(
            this RegExpPattern pattern,
            bool isFewAsPossible,
            bool isGrouped,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            if ( isGrouped )
            {
                var groupedRuleToAdd = new RegExpPattern()
                    .GroupOf(true, p => ruleToAdd);

                pattern.AddRule(new RegExpValue($"{groupedRuleToAdd}+{GetFewAsPossibleValue(isFewAsPossible)}"));

                return pattern;
            }

            pattern.AddRule(new RegExpValue($"{ruleToAdd}+{GetFewAsPossibleValue(isFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern ZeroOrOneOf(
            this RegExpPattern pattern,
            bool isFewAsPossible,
            bool isGrouped,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            if ( isGrouped )
            {
                var groupedRuleToAdd = new RegExpPattern()
                    .GroupOf(true, p => ruleToAdd);

                pattern.AddRule(new RegExpValue($"{groupedRuleToAdd}?{GetFewAsPossibleValue(isFewAsPossible)}"));

                return pattern;
            }

            pattern.AddRule(new RegExpValue($"{ruleToAdd}?{GetFewAsPossibleValue(isFewAsPossible)}"));

            return pattern;
        }

        public static RegExpPattern Time(
            this RegExpPattern pattern,
            int amount,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{amount}}}"));

            return pattern;
        }

        public static RegExpPattern Time(
            this RegExpPattern pattern,
            int from,
            int to,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{from},{to}}}"));

            return pattern;
        }

        public static RegExpPattern TimeAtLeast(
            this RegExpPattern pattern,
            int amount,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToAdd = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{amount},}}"));

            return pattern;
        }
    }
}
