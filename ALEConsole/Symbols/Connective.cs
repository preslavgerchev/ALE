namespace ALEConsole.Nodes
{
    public class Connective : Symbol
    {
        public ConnectiveType Type { get; }

        public Connective(char charSymbol, ConnectiveType type)
            : base(charSymbol)
        {
            this.Type = type;
        }
    }
}
