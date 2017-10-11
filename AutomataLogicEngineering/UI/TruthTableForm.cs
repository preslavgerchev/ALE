namespace AutomataLogicEngineering.UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Nodes;
    using TruthTable;

    public partial class TruthTableForm : Form
    {
        public TruthTableForm(Node rootNode, string input, TruthTableType type)
        {
            InitializeComponent();

            switch (type)
            {
                case TruthTableType.Normal:
                    this.InitializeNormalTable(rootNode, input);
                    break;
                case TruthTableType.Simplified:
                    this.InitializeSimplifiedTable(rootNode, input);
                    break;
                case TruthTableType.Dnf:
                    this.InitializeDnfTable(rootNode);
                    break;
                case TruthTableType.Cnf:
                    this.InitializeCnfTable(rootNode);
                    break;
                case TruthTableType.DnfSimplified:
                    this.InitializeDnfSimplifiedTable(rootNode);
                    break;
                case TruthTableType.CnfSimplified:
                    this.InitializeCnfSimplifiedTable(rootNode);
                    break;
                default:
                    throw new Exception($"Invalid truth table type value '{type}' found.");
            }
        }

        private void TruthTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truthTableView.Dispose();
        }

        private void InitializeNormalTable(Node rootNode, string input)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);

            this.truthTableLbl.Text = @"Truth table";
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", input);
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

            this.hexadecimalLbl.Text = truthTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeSimplifiedTable(Node rootNode, string input)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);

            this.truthTableLbl.Text = @"Simplified truth table";
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            truthTable.Calculate(rootNode);
            var simplified = truthTable.Simplify();
            this.truthTableView.Columns.Add("Result", input);
            for (var i = 0; i < simplified.Rows.Count; i++)
            {
                var row = simplified.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            for (var i = 0; i < simplified.Rows.Count; i++)
            {
                var row = simplified.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }

            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeDnfTable(Node rootNode)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            truthTable.Calculate(rootNode);
            if (!truthTable.CanBeConvertedToDnf)
            {
                this.truthTableLbl.Text = @"Cannot convert the input to DNF!";
                this.truthTableLbl.ForeColor = Color.Red;
                return;
            }

            this.truthTableLbl.Text = @"DNF truth table";
            var dnfString = truthTable.ToDnfForm();
            var dnfRoot = NodeTreeCreator.Initialize(dnfString);
            var dnfTable = TruthTableGenerator.GenerateTruthTable(dnfRoot);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", dnfString);
            for (var i = 0; i < dnfTable.Rows.Count; i++)
            {
                var row = dnfTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            dnfTable.Calculate(rootNode);
            for (var i = 0; i < dnfTable.Rows.Count; i++)
            {
                var row = dnfTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.hexadecimalLbl.Text = dnfTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeCnfTable(Node rootNode)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            truthTable.Calculate(rootNode);
            if (!truthTable.CanBeConvertedToCnf)
            {
                this.truthTableLbl.Text = @"Cannot convert the input to CNF!";
                this.truthTableLbl.ForeColor = Color.Red;
                return;
            }

            this.truthTableLbl.Text = @"CNF truth table";
            var cnfString = truthTable.ToCnfForm();
            var cnfRoot = NodeTreeCreator.Initialize(cnfString);
            var cnfTable = TruthTableGenerator.GenerateTruthTable(cnfRoot);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", cnfString);
            for (var i = 0; i < cnfTable.Rows.Count; i++)
            {
                var row = cnfTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            cnfTable.Calculate(rootNode);
            for (var i = 0; i < cnfTable.Rows.Count; i++)
            {
                var row = cnfTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.hexadecimalLbl.Text = cnfTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeCnfSimplifiedTable(Node rootNode)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            truthTable.Calculate(rootNode);
            truthTable = truthTable.Simplify();
            if (!truthTable.CanBeConvertedToCnf)
            {
                this.truthTableLbl.Text = @"Cannot convert the input to CNF!";
                this.truthTableLbl.ForeColor = Color.Red;
                return;
            }

            this.truthTableLbl.Text = @"CNF truth table";
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
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
            var cnfString = truthTable.ToCnfForm();
            var cnfRoot = NodeTreeCreator.Initialize(cnfString);
            var cnfTable = TruthTableGenerator.GenerateTruthTable(cnfRoot);
            cnfTable.Calculate(rootNode);
            this.truthTableView.Columns.Add("Result", cnfString);
            for (var i = 0; i < cnfTable.Rows.Count; i++)
            {
                var row = cnfTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.hexadecimalLbl.Text = cnfTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitializeDnfSimplifiedTable(Node rootNode)
        {
            var truthTable = TruthTableGenerator.GenerateTruthTable(rootNode);
            truthTable.Calculate(rootNode);
            truthTable = truthTable.Simplify();
            if (!truthTable.CanBeConvertedToDnf)
            {
                this.truthTableLbl.Text = @"Cannot convert the input to DNF!";
                this.truthTableLbl.ForeColor = Color.Red;
                return;
            }

            this.truthTableLbl.Text = @"DNF truth table";
            var dnfString = truthTable.ToDnfForm();
            var dnfRoot = NodeTreeCreator.Initialize(dnfString);
            var dnfTable = TruthTableGenerator.GenerateTruthTable(dnfRoot);
            var allPredicates = TruthTableGenerator.GetAllPredicates(rootNode);
            foreach (var predicate in allPredicates)
            {
                this.truthTableView.Columns.Add(predicate.ToString(), predicate.ToString());
            }
            this.truthTableView.Columns.Add("Result", dnfString);
            for (var i = 0; i < dnfTable.Rows.Count; i++)
            {
                var row = dnfTable.Rows[i];
                this.truthTableView.Rows.Add();
                for (var j = 0; j < row.Cells.Count; j++)
                {
                    this.truthTableView.Rows[i].Cells[j].Value = row.Cells[j].SymbolInCell;
                }
            }
            dnfTable.Calculate(rootNode);
            for (var i = 0; i < dnfTable.Rows.Count; i++)
            {
                var row = dnfTable.Rows[i];
                this.truthTableView.Rows[i].Cells["Result"].Value = row.ResultRepresentation;
            }
            this.hexadecimalLbl.Text = dnfTable.HexadecimalResult;
            this.truthTableView.Columns["Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
