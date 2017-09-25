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
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplifiedTruthTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // truthTableView
            // 
            this.truthTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truthTableView.Location = new System.Drawing.Point(11, 11);
            this.truthTableView.Margin = new System.Windows.Forms.Padding(2);
            this.truthTableView.Name = "truthTableView";
            this.truthTableView.RowTemplate.Height = 24;
            this.truthTableView.Size = new System.Drawing.Size(916, 302);
            this.truthTableView.TabIndex = 4;
            // 
            // simplifiedTruthTableView
            // 
            this.simplifiedTruthTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simplifiedTruthTableView.Location = new System.Drawing.Point(11, 325);
            this.simplifiedTruthTableView.Margin = new System.Windows.Forms.Padding(2);
            this.simplifiedTruthTableView.Name = "simplifiedTruthTableView";
            this.simplifiedTruthTableView.RowTemplate.Height = 24;
            this.simplifiedTruthTableView.Size = new System.Drawing.Size(916, 302);
            this.simplifiedTruthTableView.TabIndex = 5;
            // 
            // TruthTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 638);
            this.Controls.Add(this.simplifiedTruthTableView);
            this.Controls.Add(this.truthTableView);
            this.Name = "TruthTableForm";
            this.Text = "Truth Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TruthTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplifiedTruthTableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView truthTableView;
        private System.Windows.Forms.DataGridView simplifiedTruthTableView;
    }
}