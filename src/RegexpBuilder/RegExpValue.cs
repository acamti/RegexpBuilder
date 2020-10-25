namespace Acamti.RegexpBuilder
{
    public class RegExpValue
    {
        private readonly string _value;

        internal RegExpValue(string value) =>
            _value = value;

        public string Value() =>
            _value;
    }
}
