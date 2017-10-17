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
            this.InitializeTable(simplified: false);
        }

        private void InitializeTable(bool simplified)
        {
            var input = this.inputTextBox.Text;
            try
            {
                this.validInputLabel.Text = string.Empty;
                var rootNode = NodeTreeCreator.Initialize(input);
                new TruthTableForm(rootNode, input, simplified).Show();
            }
            catch (InvalidInputException ex)
            {
                this.validInputLabel.Text = ex.Message;
                this.validInputLabel.ForeColor = Color.Red;
            }
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            var input = this.inputTextBox.Text;
            try
            {
                this.validInputLabel.Text = string.Empty;
                var rootNode = NodeTreeCreator.Initialize(input);
                var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
                this.hcTextLbl.Text = truthTable.HexadecimalResult;
                var infix = rootNode.GetInfixNotation();
                this.infixTextLbl.Text = infix;
                if (truthTable.CanBeConvertedToDnf)
                {
                    var dnfInput = truthTable.ToDnfForm();
                    var dnfNode = NodeTreeCreator.Initialize(dnfInput);
                    var dnfTable = TruthTableGenerator.GenerateTruthTable(dnfNode);
                    this.dnfHcTxtLbl.Text = dnfTable.HexadecimalResult;
                    this.textBox1.Text = dnfInput;
                }
                else
                {
                    this.dnfHcTxtLbl.Text = @"Cannot be converted to DNF!";
                    this.textBox1.Text = @"Cannot be converted to DNF!";
                }
                if (truthTable.CanBeConvertedToCnf)
                {
                    var cnfInput = truthTable.ToCnfForm();
                    var cnfNode = NodeTreeCreator.Initialize(cnfInput);
                    var cnfTable = TruthTableGenerator.GenerateTruthTable(cnfNode);
                    this.cnfHcTxtLbl.Text = cnfTable.HexadecimalResult;
                    this.cnfTb.Text = cnfInput;
                }
                else
                {
                    this.cnfHcTxtLbl.Text = @"Cannot be converted to DNF!";
                    this.cnfTb.Text = @"Cannot be converted to DNF!";
                }
            }
            catch (InvalidInputException ex)
            {
                this.validInputLabel.Text = ex.Message;
                this.validInputLabel.ForeColor = Color.Red;
            }
        }

        private void showSimplifiedBtn_Click(object sender, EventArgs e)
        {
            this.InitializeTable(simplified: true);
        }

        private void AutomataLogicEngineeringForm_Load(object sender, EventArgs e)
        {

        }
    }
}