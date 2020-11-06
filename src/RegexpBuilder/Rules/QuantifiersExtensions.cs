using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class QuantifiersExtensions
    {
        private static bool IsText(RegExpPattern ruleToExtract)
        {
            var text = ruleToExtract.ToString();

            switch (text.Length)
            {
                case 1:
                case 2 when text[0] == '\\':
                    return false;
                default: return true;
            }
        }

        public static RegExpPattern ZeroOrMoreOf(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern()
                    .GroupOf(p =>
                             {
                                 p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                                 return p;
                             },
                             false);

                pattern.AddRule(new RegExpValue($"{ruleToAdd}*{GetFewAsPossibleValue(asFewAsPossible)}"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}*{GetFewAsPossibleValue(asFewAsPossible)}"));
            }

            return pattern;
        }

        private static string GetFewAsPossibleValue(bool asFewAsPossible)
        {
            var fewAsPossibleValue = asFewAsPossible
                ? "?"
                : string.Empty;

            return fewAsPossibleValue;
        }

        public static RegExpPattern OneOrMoreOf(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern()
                    .GroupOf(p =>
                             {
                                 p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                                 return p;
                             },
                             false);

                pattern.AddRule(new RegExpValue($"{ruleToAdd}+{GetFewAsPossibleValue(asFewAsPossible)}"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}+{GetFewAsPossibleValue(asFewAsPossible)}"));
            }

            return pattern;
        }

        public static RegExpPattern ZeroOrOneOf(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            bool asFewAsPossible = false)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern()
                    .GroupOf(p =>
                             {
                                 p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                                 return p;
                             },
                             false);

                pattern.AddRule(new RegExpValue($"{ruleToAdd}?{GetFewAsPossibleValue(asFewAsPossible)}"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}?{GetFewAsPossibleValue(asFewAsPossible)}"));
            }

            return pattern;
        }

        public static RegExpPattern Time(
            this RegExpPattern pattern,
            Func<RegExpPattern,
                RegExpPattern> rule,
            int from,
            int to)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var ruleToAdd = new RegExpPattern();
            ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

            pattern.AddRule(new RegExpValue($"{ruleToAdd}{{{from},{to}}}"));

            return pattern;
        }
    }
}
