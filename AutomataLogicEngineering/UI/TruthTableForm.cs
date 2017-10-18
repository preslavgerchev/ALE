namespace AutomataLogicEngineering.UI
{
    using System.Windows.Forms;
    using Nodes;
    using TruthTable;

    public partial class TruthTableForm : Form
    {
        public TruthTableForm(Node rootNode, bool simplified)
        {
            InitializeComponent();
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);

            if (simplified)
            {
                truthTable = truthTable.Simplify();
            }

            this.truthTableLbl.Text = @"Truth table";
            foreach (var header in truthTable.Header.Headers)
            {
                this.truthTableView.Columns.Add(header, header);
            }

            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
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
