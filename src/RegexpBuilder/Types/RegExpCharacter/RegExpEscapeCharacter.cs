namespace Acamti.RegexpBuilder.Types.RegExpCharacter
{
    public class RegExpEscapeCharacter : IRegExpCharacter
    {
        private readonly EscapeCharacter.EscapeCharacterType _character;

        private RegExpEscapeCharacter(EscapeCharacter.EscapeCharacterType character) =>
            _character = character;

        public override string ToString() =>
            EscapeCharacter.GetValue(_character);

        public static IRegExpCharacter Build(
            EscapeCharacter.EscapeCharacterType character) =>
            new RegExpEscapeCharacter(character);
    }
}
