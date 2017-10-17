namespace AutomataLogicEngineering.UI
{
    partial class AutomataLogicEngineeringForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.generateTreeBtn = new System.Windows.Forms.Button();
            this.validInputLabel = new System.Windows.Forms.Label();
            this.showTruthTableBtn = new System.Windows.Forms.Button();
            this.hcLbl = new System.Windows.Forms.Label();
            this.dnfHcLbl = new System.Windows.Forms.Label();
            this.cnfHcLbl = new System.Windows.Forms.Label();
            this.dnfLbl = new System.Windows.Forms.Label();
            this.cnfLbl = new System.Windows.Forms.Label();
            this.nandifyLbl = new System.Windows.Forms.Label();
            this.hcTextLbl = new System.Windows.Forms.Label();
            this.showAllBtn = new System.Windows.Forms.Button();
            this.dnfTb = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cnfTb = new System.Windows.Forms.TextBox();
            this.nandifyTb = new System.Windows.Forms.TextBox();
            this.infixLbl = new System.Windows.Forms.Label();
            this.infixTextLbl = new System.Windows.Forms.Label();
            this.cnfHcTxtLbl = new System.Windows.Forms.Label();
            this.dnfHcTxtLbl = new System.Windows.Forms.Label();
            this.hcTxtLbl = new System.Windows.Forms.Label();
            this.showSimplifiedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1834, 22);
            this.inputTextBox.TabIndex = 0;
            // 
            // generateTreeBtn
            // 
            this.generateTreeBtn.Location = new System.Drawing.Point(15, 80);
            this.generateTreeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateTreeBtn.Name = "generateTreeBtn";
            this.generateTreeBtn.Size = new System.Drawing.Size(117, 23);
            this.generateTreeBtn.TabIndex = 1;
            this.generateTreeBtn.Text = "Generate tree";
            this.generateTreeBtn.UseVisualStyleBackColor = true;
            this.generateTreeBtn.Click += new System.EventHandler(this.generateTreeBtn_Click);
            // 
            // validInputLabel
            // 
            this.validInputLabel.AutoSize = true;
            this.validInputLabel.Location = new System.Drawing.Point(17, 44);
            this.validInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.validInputLabel.Name = "validInputLabel";
            this.validInputLabel.Size = new System.Drawing.Size(0, 17);
            this.validInputLabel.TabIndex = 4;
            // 
            // showTruthTableBtn
            // 
            this.showTruthTableBtn.Location = new System.Drawing.Point(405, 80);
            this.showTruthTableBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showTruthTableBtn.Name = "showTruthTableBtn";
            this.showTruthTableBtn.Size = new System.Drawing.Size(169, 23);
            this.showTruthTableBtn.TabIndex = 5;
            this.showTruthTableBtn.Text = "Show truth table";
            this.showTruthTableBtn.UseVisualStyleBackColor = true;
            this.showTruthTableBtn.Click += new System.EventHandler(this.showTruthTableBtn_Click);
            // 
            // hcLbl
            // 
            this.hcLbl.AutoSize = true;
            this.hcLbl.Location = new System.Drawing.Point(22, 121);
            this.hcLbl.Name = "hcLbl";
            this.hcLbl.Size = new System.Drawing.Size(76, 17);
            this.hcLbl.TabIndex = 6;
            this.hcLbl.Text = "Hashcode:";
            this.hcLbl.UseMnemonic = false;
            // 
            // dnfHcLbl
            // 
            this.dnfHcLbl.AutoSize = true;
            this.dnfHcLbl.Location = new System.Drawing.Point(21, 146);
            this.dnfHcLbl.Name = "dnfHcLbl";
            this.dnfHcLbl.Size = new System.Drawing.Size(108, 17);
            this.dnfHcLbl.TabIndex = 7;
            this.dnfHcLbl.Text = "DNF Hashcode:";
            this.dnfHcLbl.UseMnemonic = false;
            // 
            // cnfHcLbl
            // 
            this.cnfHcLbl.AutoSize = true;
            this.cnfHcLbl.Location = new System.Drawing.Point(21, 171);
            this.cnfHcLbl.Name = "cnfHcLbl";
            this.cnfHcLbl.Size = new System.Drawing.Size(107, 17);
            this.cnfHcLbl.TabIndex = 8;
            this.cnfHcLbl.Text = "CNF Hashcode:";
            this.cnfHcLbl.UseMnemonic = false;
            // 
            // dnfLbl
            // 
            this.dnfLbl.AutoSize = true;
            this.dnfLbl.Location = new System.Drawing.Point(21, 198);
            this.dnfLbl.Name = "dnfLbl";
            this.dnfLbl.Size = new System.Drawing.Size(40, 17);
            this.dnfLbl.TabIndex = 9;
            this.dnfLbl.Text = "DNF:";
            this.dnfLbl.UseMnemonic = false;
            // 
            // cnfLbl
            // 
            this.cnfLbl.AutoSize = true;
            this.cnfLbl.Location = new System.Drawing.Point(22, 230);
            this.cnfLbl.Name = "cnfLbl";
            this.cnfLbl.Size = new System.Drawing.Size(39, 17);
            this.cnfLbl.TabIndex = 10;
            this.cnfLbl.Text = "CNF:";
            this.cnfLbl.UseMnemonic = false;
            // 
            // nandifyLbl
            // 
            this.nandifyLbl.AutoSize = true;
            this.nandifyLbl.Location = new System.Drawing.Point(22, 258);
            this.nandifyLbl.Name = "nandifyLbl";
            this.nandifyLbl.Size = new System.Drawing.Size(60, 17);
            this.nandifyLbl.TabIndex = 11;
            this.nandifyLbl.Text = "Nandify:";
            this.nandifyLbl.UseMnemonic = false;
            // 
            // hcTextLbl
            // 
            this.hcTextLbl.AutoSize = true;
            this.hcTextLbl.Location = new System.Drawing.Point(128, 121);
            this.hcTextLbl.Name = "hcTextLbl";
            this.hcTextLbl.Size = new System.Drawing.Size(0, 17);
            this.hcTextLbl.TabIndex = 12;
            // 
            // showAllBtn
            // 
            this.showAllBtn.Location = new System.Drawing.Point(138, 80);
            this.showAllBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(261, 23);
            this.showAllBtn.TabIndex = 18;
            this.showAllBtn.Text = "Show DNF,CNF, hashcodes";
            this.showAllBtn.UseVisualStyleBackColor = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // dnfTb
            // 
            this.dnfTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dnfTb.Location = new System.Drawing.Point(67, 198);
            this.dnfTb.MaximumSize = new System.Drawing.Size(250, 0);
            this.dnfTb.Multiline = true;
            this.dnfTb.Name = "dnfTb";
            this.dnfTb.ReadOnly = true;
            this.dnfTb.Size = new System.Drawing.Size(25, 0);
            this.dnfTb.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(1779, 22);
            this.textBox1.TabIndex = 20;
            // 
            // cnfTb
            // 
            this.cnfTb.Location = new System.Drawing.Point(67, 230);
            this.cnfTb.Name = "cnfTb";
            this.cnfTb.ReadOnly = true;
            this.cnfTb.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.cnfTb.Size = new System.Drawing.Size(1779, 22);
            this.cnfTb.TabIndex = 21;
            // 
            // nandifyTb
            // 
            this.nandifyTb.Location = new System.Drawing.Point(88, 258);
            this.nandifyTb.Name = "nandifyTb";
            this.nandifyTb.ReadOnly = true;
            this.nandifyTb.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.nandifyTb.Size = new System.Drawing.Size(1758, 22);
            this.nandifyTb.TabIndex = 22;
            // 
            // infixLbl
            // 
            this.infixLbl.AutoSize = true;
            this.infixLbl.Location = new System.Drawing.Point(22, 299);
            this.infixLbl.Name = "infixLbl";
            this.infixLbl.Size = new System.Drawing.Size(91, 17);
            this.infixLbl.TabIndex = 23;
            this.infixLbl.Text = "Infix notation:";
            this.infixLbl.UseMnemonic = false;
            // 
            // infixTextLbl
            // 
            this.infixTextLbl.AutoSize = true;
            this.infixTextLbl.Location = new System.Drawing.Point(119, 299);
            this.infixTextLbl.Name = "infixTextLbl";
            this.infixTextLbl.Size = new System.Drawing.Size(0, 17);
            this.infixTextLbl.TabIndex = 24;
            this.infixTextLbl.UseMnemonic = false;
            // 
            // cnfHcTxtLbl
            // 
            this.cnfHcTxtLbl.AutoSize = true;
            this.cnfHcTxtLbl.Location = new System.Drawing.Point(134, 171);
            this.cnfHcTxtLbl.Name = "cnfHcTxtLbl";
            this.cnfHcTxtLbl.Size = new System.Drawing.Size(0, 17);
            this.cnfHcTxtLbl.TabIndex = 25;
            this.cnfHcTxtLbl.UseMnemonic = false;
            // 
            // dnfHcTxtLbl
            // 
            this.dnfHcTxtLbl.AutoSize = true;
            this.dnfHcTxtLbl.Location = new System.Drawing.Point(135, 146);
            this.dnfHcTxtLbl.Name = "dnfHcTxtLbl";
            this.dnfHcTxtLbl.Size = new System.Drawing.Size(0, 17);
            this.dnfHcTxtLbl.TabIndex = 26;
            this.dnfHcTxtLbl.UseMnemonic = false;
            // 
            // hcTxtLbl
            // 
            this.hcTxtLbl.AutoSize = true;
            this.hcTxtLbl.Location = new System.Drawing.Point(134, 121);
            this.hcTxtLbl.Name = "hcTxtLbl";
            this.hcTxtLbl.Size = new System.Drawing.Size(0, 17);
            this.hcTxtLbl.TabIndex = 27;
            this.hcTxtLbl.UseMnemonic = false;
            // 
            // showSimplifiedBtn
            // 
            this.showSimplifiedBtn.Location = new System.Drawing.Point(580, 80);
            this.showSimplifiedBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showSimplifiedBtn.Name = "showSimplifiedBtn";
            this.showSimplifiedBtn.Size = new System.Drawing.Size(210, 23);
            this.showSimplifiedBtn.TabIndex = 28;
            this.showSimplifiedBtn.Text = "Show simplified truth table";
            this.showSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showSimplifiedBtn.Click += new System.EventHandler(this.showSimplifiedBtn_Click);
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1858, 582);
            this.Controls.Add(this.showSimplifiedBtn);
            this.Controls.Add(this.hcTxtLbl);
            this.Controls.Add(this.dnfHcTxtLbl);
            this.Controls.Add(this.cnfHcTxtLbl);
            this.Controls.Add(this.infixTextLbl);
            this.Controls.Add(this.infixLbl);
            this.Controls.Add(this.nandifyTb);
            this.Controls.Add(this.cnfTb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dnfTb);
            this.Controls.Add(this.showAllBtn);
            this.Controls.Add(this.hcTextLbl);
            this.Controls.Add(this.nandifyLbl);
            this.Controls.Add(this.cnfLbl);
            this.Controls.Add(this.dnfLbl);
            this.Controls.Add(this.cnfHcLbl);
            this.Controls.Add(this.dnfHcLbl);
            this.Controls.Add(this.hcLbl);
            this.Controls.Add(this.showTruthTableBtn);
            this.Controls.Add(this.validInputLabel);
            this.Controls.Add(this.generateTreeBtn);
            this.Controls.Add(this.inputTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AutomataLogicEngineeringForm";
            this.Text = "Automata Logic Engineering";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AutomataLogicEngineeringForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button generateTreeBtn;
        private System.Windows.Forms.Label validInputLabel;
        private System.Windows.Forms.Button showTruthTableBtn;
        private System.Windows.Forms.Label hcLbl;
        private System.Windows.Forms.Label dnfHcLbl;
        private System.Windows.Forms.Label cnfHcLbl;
        private System.Windows.Forms.Label dnfLbl;
        private System.Windows.Forms.Label cnfLbl;
        private System.Windows.Forms.Label nandifyLbl;
        private System.Windows.Forms.Label hcTextLbl;
        private System.Windows.Forms.Button showAllBtn;
        private System.Windows.Forms.TextBox dnfTb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox cnfTb;
        private System.Windows.Forms.TextBox nandifyTb;
        private System.Windows.Forms.Label infixLbl;
        private System.Windows.Forms.Label infixTextLbl;
        private System.Windows.Forms.Label cnfHcTxtLbl;
        private System.Windows.Forms.Label dnfHcTxtLbl;
        private System.Windows.Forms.Label hcTxtLbl;
        private System.Windows.Forms.Button showSimplifiedBtn;
    }
}

