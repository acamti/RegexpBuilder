using System.Collections.Generic;
using System.Linq;

namespace Acamti.RegexpBuilder
{
    public class RegExpPattern
    {
        private readonly List<RegExpValue> _rules;

        public RegExpPattern() =>
            _rules = new List<RegExpValue>();

        internal void AddRule(RegExpValue rule)
        {
            _rules.Add(rule);
        }

        private string Build() =>
            _rules.Aggregate(
                "",
                (seed, rule) => $"{seed}{rule.Value()}");

        public override string ToString() =>
            Build();
    }
}
