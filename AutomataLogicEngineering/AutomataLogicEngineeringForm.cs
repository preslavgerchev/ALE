using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutomataLogicEngineering.Symbols;

namespace AutomataLogicEngineering
{
    using System;
    using System.Windows.Forms;
    using Nodes;
    using PropositionalLogic;

    public partial class AutomataLogicEngineeringForm : Form
    {
        public AutomataLogicEngineeringForm()
        {
            InitializeComponent();
        }

        private void generateTreeBtn_Click(object sender, EventArgs e)
        {
            var input = this.inputTextBox.Text;
            var node = NodeTreeCreator.Initialize(input);
            var truthTable = TruthTableGenerator.GenerateTruthTable(node);
            var allPredicates = TruthTableGenerator.GetAllPredicates(node);
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Refresh();
            foreach (var predicate in allPredicates)
            {
                this.dataGridView1.Columns.Add(
                    predicate.Symbol.CharSymbol.ToString(),
                    predicate.Symbol.CharSymbol.ToString());
            }
            this.dataGridView1.Columns.Add("Result", input);
            for (var index = 0; index < truthTable.Count; index++)
            {
                var row = truthTable[index];
                this.dataGridView1.Rows.Add();
                for (int i = 0; i < row.Predicates.Count; i++)
                {
                    this.dataGridView1.Rows[index].Cells[i].Value = row.Predicates[i].ValueRepresentation;
                }
                foreach (var predicate in row.Predicates)
                {
                    FindNode(node, predicate);
                }

                var value = node.Apply();
                this.dataGridView1.Rows[index].Cells["Result"].Value = value ? '1' : '0';
            }
        }

        private void FindNode(Node node, Predicate p)
        {
            if (node.Symbol.Id == p.Id)
            {
                (node.Symbol as Predicate).Value = p.Value;
            }
            else
            {
                if (node.Children.Any())
                {
                    foreach (var child in node.Children)
                    {
                        FindNode(child, p);
                    }
                }
            }
        }
    }
}
