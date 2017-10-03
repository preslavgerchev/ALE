namespace AutomataLogicEngineering.UI
{
    using System.Windows.Forms;
    using Nodes;
    using PropositionalLogic;

    public partial class TruthTableForm : Form
    {
        public TruthTableForm(Node rootNode, string input)
        {
            InitializeComponent();

            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
                this.simplifiedTruthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", input);
            this.simplifiedTruthTableView.Columns.Add("Result", input);
            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }

            truthTable.Calculate(rootNode);
            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }

            var simplifiedTable = truthTable.Simplify();

            for (var i = 0; i < simplifiedTable.Rows.Count; i++)
            {
                var row = simplifiedTable.Rows[i];
                this.simplifiedTruthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.simplifiedTruthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
                this.simplifiedTruthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }

            this.hexadecimalLbl.Text = truthTable.HexadecimalResult;
            var imagePath = NodeGraphCreator.CreateNodeGraphImage(rootNode);
            new HexTreeForm(imagePath).Show();
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
            this.simplifiedTruthTableView.Dispose();
        }
    }
}
