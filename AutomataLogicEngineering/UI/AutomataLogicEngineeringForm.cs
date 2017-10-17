namespace AutomataLogicEngineering.UI
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using Exceptions;
    using Nodes;
    using TruthTable;

    public partial class AutomataLogicEngineeringForm : Form
    {
        public AutomataLogicEngineeringForm()
        {
            InitializeComponent();
        }

        private void generateTreeBtn_Click(object sender, EventArgs e)
        {
            var input = this.inputTextBox.Text;
            try
            {
                this.validInputLabel.Text = string.Empty;
                var rootNode = NodeTreeCreator.Initialize(input);
                var imagePath = NodeGraphCreator.CreateNodeGraphImage(rootNode);
                new HexTreeForm(imagePath).Show();
            }
            catch (InvalidInputException ex)
            {
                this.validInputLabel.Text = ex.Message;
                this.validInputLabel.ForeColor = Color.Red;
            }
        }

        private void showTruthTableBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.Normal);
        }

        private void showDnfBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.Dnf);
        }

        private void showCnfBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.Cnf);
        }

        private void showSimplifiedBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.Simplified);
        }

        private void showCnfSimplifiedBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.CnfSimplified);
        }

        private void showDnfSimplifiedBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(TruthTableType.DnfSimplified);
        }

        private void InitializeTable(TruthTableType type)
        {
            var input = this.inputTextBox.Text;
            try
            {
                this.validInputLabel.Text = string.Empty;
                var rootNode = NodeTreeCreator.Initialize(input);
                new TruthTableForm(rootNode, input, type).Show();
            }
            catch (InvalidInputException ex)
            {
                this.validInputLabel.Text = ex.Message;
                this.validInputLabel.ForeColor = Color.Red;
            }
        }
    }
}