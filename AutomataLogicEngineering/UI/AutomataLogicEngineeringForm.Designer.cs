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
            this.showTruthTableBtn.Location = new System.Drawing.Point(120, 65);
            this.showTruthTableBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showTruthTableBtn.Name = "showTruthTableBtn";
            this.showTruthTableBtn.Size = new System.Drawing.Size(127, 19);
            this.showTruthTableBtn.TabIndex = 5;
            this.showTruthTableBtn.Text = "Show truth table";
            this.showTruthTableBtn.UseVisualStyleBackColor = true;
            this.showTruthTableBtn.Click += new System.EventHandler(this.showTruthTableBtn_Click);
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 98);
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
    }
}

