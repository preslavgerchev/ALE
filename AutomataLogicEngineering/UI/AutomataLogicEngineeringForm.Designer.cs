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
            this.showSimplifiedBtn = new System.Windows.Forms.Button();
            this.showDnfBtn = new System.Windows.Forms.Button();
            this.showCnfBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(9, 10);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(758, 20);
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
            this.showTruthTableBtn.Location = new System.Drawing.Point(103, 65);
            this.showTruthTableBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showTruthTableBtn.Name = "showTruthTableBtn";
            this.showTruthTableBtn.Size = new System.Drawing.Size(127, 19);
            this.showTruthTableBtn.TabIndex = 5;
            this.showTruthTableBtn.Text = "Show truth table";
            this.showTruthTableBtn.UseVisualStyleBackColor = true;
            this.showTruthTableBtn.Click += new System.EventHandler(this.showTruthTableBtn_Click);
            // 
            // showSimplifiedBtn
            // 
            this.showSimplifiedBtn.Location = new System.Drawing.Point(234, 65);
            this.showSimplifiedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showSimplifiedBtn.Name = "showSimplifiedBtn";
            this.showSimplifiedBtn.Size = new System.Drawing.Size(160, 19);
            this.showSimplifiedBtn.TabIndex = 6;
            this.showSimplifiedBtn.Text = "Show simplified truth table";
            this.showSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showSimplifiedBtn.Click += new System.EventHandler(this.showSimplifiedBtn_Click);
            // 
            // showDnfBtn
            // 
            this.showDnfBtn.Location = new System.Drawing.Point(398, 65);
            this.showDnfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showDnfBtn.Name = "showDnfBtn";
            this.showDnfBtn.Size = new System.Drawing.Size(160, 19);
            this.showDnfBtn.TabIndex = 7;
            this.showDnfBtn.Text = "Show DNF truth table";
            this.showDnfBtn.UseVisualStyleBackColor = true;
            this.showDnfBtn.Click += new System.EventHandler(this.showDnfBtn_Click);
            // 
            // showCnfBtn
            // 
            this.showCnfBtn.Location = new System.Drawing.Point(562, 65);
            this.showCnfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showCnfBtn.Name = "showCnfBtn";
            this.showCnfBtn.Size = new System.Drawing.Size(160, 19);
            this.showCnfBtn.TabIndex = 8;
            this.showCnfBtn.Text = "Show CNF truth table";
            this.showCnfBtn.UseVisualStyleBackColor = true;
            this.showCnfBtn.Click += new System.EventHandler(this.showCnfBtn_Click);
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 98);
            this.Controls.Add(this.showCnfBtn);
            this.Controls.Add(this.showDnfBtn);
            this.Controls.Add(this.showSimplifiedBtn);
            this.Controls.Add(this.showTruthTableBtn);
            this.Controls.Add(this.validInputLabel);
            this.Controls.Add(this.generateTreeBtn);
            this.Controls.Add(this.inputTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AutomataLogicEngineeringForm";
            this.Text = "Automata Logic Engineering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button generateTreeBtn;
        private System.Windows.Forms.Label validInputLabel;
        private System.Windows.Forms.Button showTruthTableBtn;
        private System.Windows.Forms.Button showSimplifiedBtn;
        private System.Windows.Forms.Button showDnfBtn;
        private System.Windows.Forms.Button showCnfBtn;
    }
}

