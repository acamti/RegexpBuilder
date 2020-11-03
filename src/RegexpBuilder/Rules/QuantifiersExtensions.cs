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

        public static RegExpPattern WithZeroOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern().WithGroup(p =>
                {
                    p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                    return p;
                });

                pattern.AddRule(new RegExpValue($"{ruleToAdd}*"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}*"));
            }

            return pattern;
        }

        public static RegExpPattern WithOneOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern().WithGroup(p =>
                {
                    p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                    return p;
                });

                pattern.AddRule(new RegExpValue($"{ruleToAdd}+"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}+"));
            }

            return pattern;
        }

        public static RegExpPattern WithZeroOrOne(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            if ( IsText(ruleToExtract) )
            {
                var ruleToAdd = new RegExpPattern().WithGroup(p =>
                {
                    p.AddRule(new RegExpValue(ruleToExtract.ToString()));

                    return p;
                });

                pattern.AddRule(new RegExpValue($"{ruleToAdd}?"));
            }
            else
            {
                var ruleToAdd = new RegExpPattern();
                ruleToAdd.AddRule(new RegExpValue(ruleToExtract.ToString()));

                pattern.AddRule(new RegExpValue($"{ruleToAdd}?"));
            }

            return pattern;
        }
    }
}
