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
            this.label1 = new System.Windows.Forms.Label();
            this.nandifyTextLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(9, 10);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1376, 20);
            this.inputTextBox.TabIndex = 0;
            // 
            // generateTreeBtn
            // 
            this.generateTreeBtn.Location = new System.Drawing.Point(11, 65);
            this.generateTreeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.generateTreeBtn.Name = "generateTreeBtn";
            this.generateTreeBtn.Size = new System.Drawing.Size(88, 19);
            this.generateTreeBtn.TabIndex = 1;
            this.generateTreeBtn.Text = "Generate tree";
            this.generateTreeBtn.UseVisualStyleBackColor = true;
            this.generateTreeBtn.Click += new System.EventHandler(this.generateTreeBtn_Click);
            // 
            // validInputLabel
            // 
            this.validInputLabel.AutoSize = true;
            this.validInputLabel.Location = new System.Drawing.Point(13, 36);
            this.validInputLabel.Name = "validInputLabel";
            this.validInputLabel.Size = new System.Drawing.Size(0, 13);
            this.validInputLabel.TabIndex = 4;
            // 
            // showTruthTableBtn
            // 
            this.showTruthTableBtn.Location = new System.Drawing.Point(304, 65);
            this.showTruthTableBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showTruthTableBtn.Name = "showTruthTableBtn";
            this.showTruthTableBtn.Size = new System.Drawing.Size(127, 19);
            this.showTruthTableBtn.TabIndex = 5;
            this.showTruthTableBtn.Text = "Show truth table";
            this.showTruthTableBtn.UseVisualStyleBackColor = true;
            this.showTruthTableBtn.Click += new System.EventHandler(this.showTruthTableBtn_Click);
            // 
            // hcLbl
            // 
            this.hcLbl.AutoSize = true;
            this.hcLbl.Location = new System.Drawing.Point(16, 98);
            this.hcLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hcLbl.Name = "hcLbl";
            this.hcLbl.Size = new System.Drawing.Size(59, 13);
            this.hcLbl.TabIndex = 6;
            this.hcLbl.Text = "Hashcode:";
            this.hcLbl.UseMnemonic = false;
            // 
            // dnfHcLbl
            // 
            this.dnfHcLbl.AutoSize = true;
            this.dnfHcLbl.Location = new System.Drawing.Point(16, 119);
            this.dnfHcLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dnfHcLbl.Name = "dnfHcLbl";
            this.dnfHcLbl.Size = new System.Drawing.Size(84, 13);
            this.dnfHcLbl.TabIndex = 7;
            this.dnfHcLbl.Text = "DNF Hashcode:";
            this.dnfHcLbl.UseMnemonic = false;
            // 
            // cnfHcLbl
            // 
            this.cnfHcLbl.AutoSize = true;
            this.cnfHcLbl.Location = new System.Drawing.Point(16, 139);
            this.cnfHcLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cnfHcLbl.Name = "cnfHcLbl";
            this.cnfHcLbl.Size = new System.Drawing.Size(83, 13);
            this.cnfHcLbl.TabIndex = 8;
            this.cnfHcLbl.Text = "CNF Hashcode:";
            this.cnfHcLbl.UseMnemonic = false;
            // 
            // dnfLbl
            // 
            this.dnfLbl.AutoSize = true;
            this.dnfLbl.Location = new System.Drawing.Point(16, 194);
            this.dnfLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dnfLbl.Name = "dnfLbl";
            this.dnfLbl.Size = new System.Drawing.Size(32, 13);
            this.dnfLbl.TabIndex = 9;
            this.dnfLbl.Text = "DNF:";
            this.dnfLbl.UseMnemonic = false;
            // 
            // cnfLbl
            // 
            this.cnfLbl.AutoSize = true;
            this.cnfLbl.Location = new System.Drawing.Point(17, 257);
            this.cnfLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cnfLbl.Name = "cnfLbl";
            this.cnfLbl.Size = new System.Drawing.Size(31, 13);
            this.cnfLbl.TabIndex = 10;
            this.cnfLbl.Text = "CNF:";
            this.cnfLbl.UseMnemonic = false;
            // 
            // nandifyLbl
            // 
            this.nandifyLbl.AutoSize = true;
            this.nandifyLbl.Location = new System.Drawing.Point(13, 326);
            this.nandifyLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nandifyLbl.Name = "nandifyLbl";
            this.nandifyLbl.Size = new System.Drawing.Size(46, 13);
            this.nandifyLbl.TabIndex = 11;
            this.nandifyLbl.Text = "Nandify:";
            this.nandifyLbl.UseMnemonic = false;
            // 
            // hcTextLbl
            // 
            this.hcTextLbl.AutoSize = true;
            this.hcTextLbl.Location = new System.Drawing.Point(96, 98);
            this.hcTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hcTextLbl.Name = "hcTextLbl";
            this.hcTextLbl.Size = new System.Drawing.Size(0, 13);
            this.hcTextLbl.TabIndex = 12;
            // 
            // showAllBtn
            // 
            this.showAllBtn.Location = new System.Drawing.Point(104, 65);
            this.showAllBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(196, 19);
            this.showAllBtn.TabIndex = 18;
            this.showAllBtn.Text = "Show DNF,CNF, hashcodes";
            this.showAllBtn.UseVisualStyleBackColor = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // dnfTb
            // 
            this.dnfTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dnfTb.Location = new System.Drawing.Point(50, 178);
            this.dnfTb.Margin = new System.Windows.Forms.Padding(2);
            this.dnfTb.MaximumSize = new System.Drawing.Size(188, 0);
            this.dnfTb.Multiline = true;
            this.dnfTb.Name = "dnfTb";
            this.dnfTb.ReadOnly = true;
            this.dnfTb.Size = new System.Drawing.Size(19, 0);
            this.dnfTb.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 194);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(1335, 59);
            this.textBox1.TabIndex = 20;
            // 
            // cnfTb
            // 
            this.cnfTb.Location = new System.Drawing.Point(52, 257);
            this.cnfTb.Margin = new System.Windows.Forms.Padding(2);
            this.cnfTb.Multiline = true;
            this.cnfTb.Name = "cnfTb";
            this.cnfTb.ReadOnly = true;
            this.cnfTb.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.cnfTb.Size = new System.Drawing.Size(1335, 49);
            this.cnfTb.TabIndex = 21;
            // 
            // nandifyTb
            // 
            this.nandifyTb.Location = new System.Drawing.Point(63, 323);
            this.nandifyTb.Margin = new System.Windows.Forms.Padding(2);
            this.nandifyTb.Multiline = true;
            this.nandifyTb.Name = "nandifyTb";
            this.nandifyTb.ReadOnly = true;
            this.nandifyTb.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.nandifyTb.Size = new System.Drawing.Size(1320, 73);
            this.nandifyTb.TabIndex = 22;
            // 
            // infixLbl
            // 
            this.infixLbl.AutoSize = true;
            this.infixLbl.Location = new System.Drawing.Point(17, 415);
            this.infixLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infixLbl.Name = "infixLbl";
            this.infixLbl.Size = new System.Drawing.Size(70, 13);
            this.infixLbl.TabIndex = 23;
            this.infixLbl.Text = "Infix notation:";
            this.infixLbl.UseMnemonic = false;
            // 
            // infixTextLbl
            // 
            this.infixTextLbl.AutoSize = true;
            this.infixTextLbl.Location = new System.Drawing.Point(91, 415);
            this.infixTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infixTextLbl.Name = "infixTextLbl";
            this.infixTextLbl.Size = new System.Drawing.Size(0, 13);
            this.infixTextLbl.TabIndex = 24;
            this.infixTextLbl.UseMnemonic = false;
            // 
            // cnfHcTxtLbl
            // 
            this.cnfHcTxtLbl.AutoSize = true;
            this.cnfHcTxtLbl.Location = new System.Drawing.Point(100, 139);
            this.cnfHcTxtLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cnfHcTxtLbl.Name = "cnfHcTxtLbl";
            this.cnfHcTxtLbl.Size = new System.Drawing.Size(0, 13);
            this.cnfHcTxtLbl.TabIndex = 25;
            this.cnfHcTxtLbl.UseMnemonic = false;
            // 
            // dnfHcTxtLbl
            // 
            this.dnfHcTxtLbl.AutoSize = true;
            this.dnfHcTxtLbl.Location = new System.Drawing.Point(101, 119);
            this.dnfHcTxtLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dnfHcTxtLbl.Name = "dnfHcTxtLbl";
            this.dnfHcTxtLbl.Size = new System.Drawing.Size(0, 13);
            this.dnfHcTxtLbl.TabIndex = 26;
            this.dnfHcTxtLbl.UseMnemonic = false;
            // 
            // hcTxtLbl
            // 
            this.hcTxtLbl.AutoSize = true;
            this.hcTxtLbl.Location = new System.Drawing.Point(100, 98);
            this.hcTxtLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hcTxtLbl.Name = "hcTxtLbl";
            this.hcTxtLbl.Size = new System.Drawing.Size(0, 13);
            this.hcTxtLbl.TabIndex = 27;
            this.hcTxtLbl.UseMnemonic = false;
            // 
            // showSimplifiedBtn
            // 
            this.showSimplifiedBtn.Location = new System.Drawing.Point(435, 65);
            this.showSimplifiedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showSimplifiedBtn.Name = "showSimplifiedBtn";
            this.showSimplifiedBtn.Size = new System.Drawing.Size(158, 19);
            this.showSimplifiedBtn.TabIndex = 28;
            this.showSimplifiedBtn.Text = "Show simplified truth table";
            this.showSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showSimplifiedBtn.Click += new System.EventHandler(this.showSimplifiedBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nandify Hashcode:";
            this.label1.UseMnemonic = false;
            // 
            // nandifyTextLbl
            // 
            this.nandifyTextLbl.AutoSize = true;
            this.nandifyTextLbl.Location = new System.Drawing.Point(117, 162);
            this.nandifyTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nandifyTextLbl.Name = "nandifyTextLbl";
            this.nandifyTextLbl.Size = new System.Drawing.Size(0, 13);
            this.nandifyTextLbl.TabIndex = 30;
            this.nandifyTextLbl.UseMnemonic = false;
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1394, 473);
            this.Controls.Add(this.nandifyTextLbl);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AutomataLogicEngineeringForm";
            this.Text = "Automata Logic Engineering";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nandifyTextLbl;
    }
}

