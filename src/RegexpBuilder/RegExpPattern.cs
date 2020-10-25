using System.Collections.Generic;
using System.Linq;
using Acamti.RegexpBuilder.Rules;

namespace Acamti.RegexpBuilder
{
    public class RegExpPattern
    {
        private readonly List<RegExpValue> _rules;

        private RegExpPattern() =>
            _rules = new List<RegExpValue>();

        internal void AddRule(RegExpValue rule)
        {
            _rules.Add(rule);
        }

        public static RegExpPattern With() =>
            new RegExpPattern();

        public static RegExpPattern StartWith()
        {
            var pattern = new RegExpPattern();

            pattern.Value("^");

            return pattern;
        }

        private string Build() =>
            _rules.Aggregate(
                "",
                (seed, rule) => $"{seed}{rule.Value()}");

        public override string ToString() =>
            Build();
    }
}
