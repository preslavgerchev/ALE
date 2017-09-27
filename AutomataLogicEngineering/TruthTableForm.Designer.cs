namespace AutomataLogicEngineering
{
    partial class TruthTableForm
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
            this.truthTableView = new System.Windows.Forms.DataGridView();
            this.simplifiedTruthTableView = new System.Windows.Forms.DataGridView();
            this.truthTableLbl = new System.Windows.Forms.Label();
            this.simplifiedTruthTableLbl = new System.Windows.Forms.Label();
            this.hexadecimalLbl = new System.Windows.Forms.Label();
            this.hexadecimalValueLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplifiedTruthTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // truthTableView
            // 
            this.truthTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truthTableView.Location = new System.Drawing.Point(11, 29);
            this.truthTableView.Margin = new System.Windows.Forms.Padding(2);
            this.truthTableView.Name = "truthTableView";
            this.truthTableView.RowTemplate.Height = 24;
            this.truthTableView.Size = new System.Drawing.Size(916, 284);
            this.truthTableView.TabIndex = 4;
            // 
            // simplifiedTruthTableView
            // 
            this.simplifiedTruthTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simplifiedTruthTableView.Location = new System.Drawing.Point(11, 332);
            this.simplifiedTruthTableView.Margin = new System.Windows.Forms.Padding(2);
            this.simplifiedTruthTableView.Name = "simplifiedTruthTableView";
            this.simplifiedTruthTableView.RowTemplate.Height = 24;
            this.simplifiedTruthTableView.Size = new System.Drawing.Size(916, 295);
            this.simplifiedTruthTableView.TabIndex = 5;
            // 
            // truthTableLbl
            // 
            this.truthTableLbl.AutoSize = true;
            this.truthTableLbl.Location = new System.Drawing.Point(13, 11);
            this.truthTableLbl.Name = "truthTableLbl";
            this.truthTableLbl.Size = new System.Drawing.Size(58, 13);
            this.truthTableLbl.TabIndex = 6;
            this.truthTableLbl.Text = "Truth table";
            // 
            // simplifiedTruthTableLbl
            // 
            this.simplifiedTruthTableLbl.AutoSize = true;
            this.simplifiedTruthTableLbl.Location = new System.Drawing.Point(13, 317);
            this.simplifiedTruthTableLbl.Name = "simplifiedTruthTableLbl";
            this.simplifiedTruthTableLbl.Size = new System.Drawing.Size(101, 13);
            this.simplifiedTruthTableLbl.TabIndex = 7;
            this.simplifiedTruthTableLbl.Text = "Simplified truth table";
            // 
            // hexadecimalLbl
            // 
            this.hexadecimalLbl.AutoSize = true;
            this.hexadecimalLbl.Location = new System.Drawing.Point(422, 9);
            this.hexadecimalLbl.Name = "hexadecimalLbl";
            this.hexadecimalLbl.Size = new System.Drawing.Size(0, 13);
            this.hexadecimalLbl.TabIndex = 8;
            // 
            // hexadecimalValueLbl
            // 
            this.hexadecimalValueLbl.AutoSize = true;
            this.hexadecimalValueLbl.Location = new System.Drawing.Point(348, 9);
            this.hexadecimalValueLbl.Name = "hexadecimalValueLbl";
            this.hexadecimalValueLbl.Size = new System.Drawing.Size(58, 13);
            this.hexadecimalValueLbl.TabIndex = 9;
            this.hexadecimalValueLbl.Text = "Hex value:";
            // 
            // TruthTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 638);
            this.Controls.Add(this.hexadecimalValueLbl);
            this.Controls.Add(this.hexadecimalLbl);
            this.Controls.Add(this.simplifiedTruthTableLbl);
            this.Controls.Add(this.truthTableLbl);
            this.Controls.Add(this.simplifiedTruthTableView);
            this.Controls.Add(this.truthTableView);
            this.Name = "TruthTableForm";
            this.Text = "Truth Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TruthTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplifiedTruthTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView truthTableView;
        private System.Windows.Forms.DataGridView simplifiedTruthTableView;
        private System.Windows.Forms.Label truthTableLbl;
        private System.Windows.Forms.Label simplifiedTruthTableLbl;
        private System.Windows.Forms.Label hexadecimalLbl;
        private System.Windows.Forms.Label hexadecimalValueLbl;
    }
}