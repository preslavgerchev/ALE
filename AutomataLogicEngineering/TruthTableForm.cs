namespace AutomataLogicEngineering
{
    using System.Linq;
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
            for (var index = 0; index < truthTable.Rows.Count; index++)
            {
                var row = truthTable.Rows[index];
                this.truthTableView.Rows.Add();
                for (var i = 0; i < row.Cells.Count; i++)
                {
                    this.truthTableView.Rows[index].Cells[i].Value = row.Cells[i].SymbolInCell;
                }
                TruthTableGenerator.AssignValues(rootNode, row);
                var finalValue = rootNode.Apply();
                row.Result = finalValue;
                this.truthTableView.Rows[index].Cells["Result"].Value = finalValue ? '1' : '0';
            }

            var simplifiedTable = truthTable.Simplify();
            while (simplifiedTable.CanBeSimplified)
            {
                simplifiedTable = simplifiedTable.Simplify();
            }
            
            for (var index = 0; index < simplifiedTable.Rows.Count; index++)
            {
                var row = simplifiedTable.Rows[index];
                this.simplifiedTruthTableView.Rows.Add();
                for (var i = 0; i < row.Cells.Count; i++)
                {
                    this.simplifiedTruthTableView.Rows[index].Cells[i].Value = row.Cells[i].SymbolInCell;
                    this.simplifiedTruthTableView.Rows[index].Cells["Result"].Value = row.Result ? '1' : '0';
                }
            }
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
            this.simplifiedTruthTableView.Dispose();
        }
    }
}
