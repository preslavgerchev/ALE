namespace ALEConsole.Nodes
{
    public class Parenthesis : Symbol
    {
        public ParenthesisSide Side { get; }

        public Parenthesis(char charSymbol, ParenthesisSide side)
            : base(charSymbol)
        {
            this.Side = side;
        }
    }
}
