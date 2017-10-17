namespace AutomataLogicEngineering.UI
{
    using System.Windows.Forms;
    using Nodes;
    using TruthTable;

    public partial class TruthTableForm : Form
    {
        public TruthTableForm(Node rootNode, string input, bool simplified)
        {
            InitializeComponent();

            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);

            this.truthTableLbl.Text = @"Truth table";
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", input);
            if (simplified)
            {
                truthTable = truthTable.Simplify();
            }
            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
        }
    }
}
