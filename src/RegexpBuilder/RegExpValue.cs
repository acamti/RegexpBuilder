namespace Acamti.RegexpBuilder
{
    public class RegExpValue
    {
        private string _value;

        internal RegExpValue(string value) =>
            _value = value;

        public string Value() =>
            _value;

        internal void Append(string value)
        {
            _value += value;
        }
    }
}
