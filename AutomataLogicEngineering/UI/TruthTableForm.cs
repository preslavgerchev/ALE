namespace AutomataLogicEngineering.UI
{
    using System.Windows.Forms;
    using Nodes;
    using TruthTable;

    public partial class TruthTableForm : Form
    {
        private readonly TruthTable truthTable;
        private readonly TruthTable simplifiedTruthTable;
        private readonly TruthTable dnfTruthTable;

        public TruthTableForm(Node rootNode, string input)
        {
            InitializeComponent();

            this.truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
                this.simplifiedTruthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
                this.dnfTruthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", input);
            this.simplifiedTruthTableView.Columns.Add("Result", input);
            for (var i = 0; i < this.truthTable.Rows.Count; i++)
            {
                var row = this.truthTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            this.truthTable.Calculate(rootNode);
            for (var i = 0; i < truthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }

            this.simplifiedTruthTable = this.truthTable.Simplify();

            for (var i = 0; i < this.simplifiedTruthTable.Rows.Count; i++)
            {
                var row = this.simplifiedTruthTable.Rows[i];
                this.simplifiedTruthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.simplifiedTruthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
                this.simplifiedTruthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }

            this.hexadecimalLbl.Text = this.truthTable.HexadecimalResult;

            var dnfString = this.truthTable.ToDnfForm();
            var dnfNode = NodeTreeCreator.Initialize(dnfString);
            this.dnfTruthTableView.Columns.Add("Result", dnfString);
            this.dnfTruthTable = TruthTableGenerator.GenerateTruthTable(dnfNode);
            for (var i = 0; i < this.dnfTruthTable.Rows.Count; i++)
            {
                var row = this.dnfTruthTable.Rows[i];
                this.dnfTruthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.dnfTruthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            this.dnfTruthTable.Calculate(dnfNode);
            for (var i = 0; i < this.dnfTruthTable.Rows.Count; i++)
            {
                var row = truthTable.Rows[i];
                this.dnfTruthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.dnfHexValueLbl.Text = this.dnfTruthTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.simplifiedTruthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dnfTruthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (var i = 0; i < this.truthTableView.Columns.Count; i++)
            {
                this.truthTableView.Columns[i].Frozen = false;
                this.dnfTruthTableView.Columns[i].Frozen = false;
                this.simplifiedTruthTableView.Columns[i].Frozen = false;
            }
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
            this.simplifiedTruthTableView.Dispose();
            this.dnfTruthTableView.Dispose();
        }
    }
}
