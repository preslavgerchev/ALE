namespace AutomataLogicEngineering.UI
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using Exceptions;
    using Nodes;

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
            var input = this.inputTextBox.Text;
            try
            {
                this.validInputLabel.Text = string.Empty;
                var rootNode = NodeTreeCreator.Initialize(input);
                new TruthTableForm(rootNode, input).Show();
            }
            catch (InvalidInputException ex)
            {
                this.validInputLabel.Text = ex.Message;
                this.validInputLabel.ForeColor = Color.Red;
            }
        }
    }
}
