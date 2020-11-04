using System;
using System.Collections.Generic;
using System.Linq;

namespace Acamti.RegexpBuilder
{
    public class RegExpPattern
    {
        private readonly List<RegExpValue> _rules;
        private bool _isStopped;

        public RegExpPattern() =>
            _rules = new List<RegExpValue>();

        internal void AddRule(RegExpValue rule)
        {
            if ( _isStopped )
                throw new Exception("No more rules can be added");

            _rules.Add(rule);
        }

        public RegExpPattern MustBeginWith()
        {
            if ( _rules.Any() )
                throw new Exception("Must not have rule defined before");

            _rules.Add(new RegExpValue("^"));

            return this;
        }

        public RegExpPattern MustStopWith()
        {
            _rules.Add(new RegExpValue("$"));

            _isStopped = true;

            return this;
        }

        private string Build() =>
            _rules.Aggregate(
                "",
                (seed, rule) => $"{seed}{rule.Value()}");

        public override string ToString() =>
            Build();
    }
}
