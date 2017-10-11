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
            this.showDnfSimplifiedBtn = new System.Windows.Forms.Button();
            this.showCnfSimplifiedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1009, 22);
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
            this.showTruthTableBtn.Location = new System.Drawing.Point(137, 80);
            this.showTruthTableBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showTruthTableBtn.Name = "showTruthTableBtn";
            this.showTruthTableBtn.Size = new System.Drawing.Size(169, 23);
            this.showTruthTableBtn.TabIndex = 5;
            this.showTruthTableBtn.Text = "Show truth table";
            this.showTruthTableBtn.UseVisualStyleBackColor = true;
            this.showTruthTableBtn.Click += new System.EventHandler(this.showTruthTableBtn_Click);
            // 
            // showSimplifiedBtn
            // 
            this.showSimplifiedBtn.Location = new System.Drawing.Point(312, 80);
            this.showSimplifiedBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showSimplifiedBtn.Name = "showSimplifiedBtn";
            this.showSimplifiedBtn.Size = new System.Drawing.Size(213, 23);
            this.showSimplifiedBtn.TabIndex = 6;
            this.showSimplifiedBtn.Text = "Show simplified truth table";
            this.showSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showSimplifiedBtn.Click += new System.EventHandler(this.showSimplifiedBtn_Click);
            // 
            // showDnfBtn
            // 
            this.showDnfBtn.Location = new System.Drawing.Point(531, 80);
            this.showDnfBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showDnfBtn.Name = "showDnfBtn";
            this.showDnfBtn.Size = new System.Drawing.Size(213, 23);
            this.showDnfBtn.TabIndex = 7;
            this.showDnfBtn.Text = "Show DNF truth table";
            this.showDnfBtn.UseVisualStyleBackColor = true;
            this.showDnfBtn.Click += new System.EventHandler(this.showDnfBtn_Click);
            // 
            // showCnfBtn
            // 
            this.showCnfBtn.Location = new System.Drawing.Point(749, 80);
            this.showCnfBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showCnfBtn.Name = "showCnfBtn";
            this.showCnfBtn.Size = new System.Drawing.Size(213, 23);
            this.showCnfBtn.TabIndex = 8;
            this.showCnfBtn.Text = "Show CNF truth table";
            this.showCnfBtn.UseVisualStyleBackColor = true;
            this.showCnfBtn.Click += new System.EventHandler(this.showCnfBtn_Click);
            // 
            // showDnfSimplifiedBtn
            // 
            this.showDnfSimplifiedBtn.Location = new System.Drawing.Point(430, 112);
            this.showDnfSimplifiedBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showDnfSimplifiedBtn.Name = "showDnfSimplifiedBtn";
            this.showDnfSimplifiedBtn.Size = new System.Drawing.Size(255, 23);
            this.showDnfSimplifiedBtn.TabIndex = 9;
            this.showDnfSimplifiedBtn.Text = "Show DNF of simplified truth table";
            this.showDnfSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showDnfSimplifiedBtn.Click += new System.EventHandler(this.showDnfSimplifiedBtn_Click);
            // 
            // showCnfSimplifiedBtn
            // 
            this.showCnfSimplifiedBtn.Location = new System.Drawing.Point(707, 112);
            this.showCnfSimplifiedBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showCnfSimplifiedBtn.Name = "showCnfSimplifiedBtn";
            this.showCnfSimplifiedBtn.Size = new System.Drawing.Size(255, 23);
            this.showCnfSimplifiedBtn.TabIndex = 10;
            this.showCnfSimplifiedBtn.Text = "Show CNF of simplified truth table";
            this.showCnfSimplifiedBtn.UseVisualStyleBackColor = true;
            this.showCnfSimplifiedBtn.Click += new System.EventHandler(this.showCnfSimplifiedBtn_Click);
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 146);
            this.Controls.Add(this.showCnfSimplifiedBtn);
            this.Controls.Add(this.showDnfSimplifiedBtn);
            this.Controls.Add(this.showCnfBtn);
            this.Controls.Add(this.showDnfBtn);
            this.Controls.Add(this.showSimplifiedBtn);
            this.Controls.Add(this.showTruthTableBtn);
            this.Controls.Add(this.validInputLabel);
            this.Controls.Add(this.generateTreeBtn);
            this.Controls.Add(this.inputTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button showDnfSimplifiedBtn;
        private System.Windows.Forms.Button showCnfSimplifiedBtn;
    }
}

