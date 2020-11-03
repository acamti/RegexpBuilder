using System;

namespace Acamti.RegexpBuilder.Types
{
    public static class CharacterClass
    {
        public enum CharacterClassType
        {
            Bell,
            BackSpace,
            Tab,
            CarriageReturn,
            VerticalTab,
            FormFeed,
            NewLine,
            Escape
        }

        public static string GetValue(CharacterClassType type)
        {
            return type switch
            {
                CharacterClassType.Bell           => "0007",
                CharacterClassType.BackSpace      => "0008",
                CharacterClassType.Tab            => "0009",
                CharacterClassType.CarriageReturn => "000D",
                CharacterClassType.VerticalTab    => "000B",
                CharacterClassType.FormFeed       => "000C",
                CharacterClassType.NewLine        => "000A",
                CharacterClassType.Escape         => "001B",
                _                                 => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
