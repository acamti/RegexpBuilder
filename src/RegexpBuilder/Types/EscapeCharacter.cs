using System;

namespace Acamti.RegexpBuilder.Types
{
    public static class EscapeCharacter
    {
        public enum EscapeCharacterType
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

        public static string GetValue(EscapeCharacterType type)
        {
            return type switch
            {
                EscapeCharacterType.Bell           => "\\a",
                EscapeCharacterType.BackSpace      => "\\b",
                EscapeCharacterType.Tab            => "\\t",
                EscapeCharacterType.CarriageReturn => "\\r",
                EscapeCharacterType.VerticalTab    => "\\v",
                EscapeCharacterType.FormFeed       => "\\f",
                EscapeCharacterType.NewLine        => "\\n",
                EscapeCharacterType.Escape         => "\\e",
                _                                  => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
