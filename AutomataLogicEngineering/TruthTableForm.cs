namespace AutomataLogicEngineering
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
            }
            this.truthTableView.Columns.Add("Result", input);
            for (var index = 0; index < truthTable.Rows.Count; index++)
            {
                var row = truthTable.Rows[index];
                this.truthTableView.Rows.Add();
                for (var i = 0; i < row.Predicates.Count; i++)
                {
                    this.truthTableView.Rows[index].Cells[i].Value = row.Predicates[i].ValueRepresentation;
                }
                TruthTableGenerator.AssignValues(rootNode, row);
                var finalValue = rootNode.Apply();
                this.truthTableView.Rows[index].Cells["Result"].Value = finalValue ? '1' : '0';
            }

            var sim = truthTable.Simplify();
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
        }
    }
}
