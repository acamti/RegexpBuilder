using System.Linq;

namespace Acamti.RegexpBuilder
{
    public static class Tools
    {
        public static string Escape(string value)
        {
            var mustEscape = new[] { ".", "$", "^", "{", "[", "(", "|", ")", "*", "+", "?", "\\" };

            return value.Aggregate(
                string.Empty,
                (seed, c) =>
                {
                    if ( mustEscape.Contains(c.ToString()) )
                        return seed + "\\" + c;

                    return seed + c;
                });
        }
    }
}
