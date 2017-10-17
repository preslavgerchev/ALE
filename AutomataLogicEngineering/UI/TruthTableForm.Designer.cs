namespace AutomataLogicEngineering.UI
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
            this.truthTableLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // truthTableView
            // 
            this.truthTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truthTableView.Location = new System.Drawing.Point(15, 36);
            this.truthTableView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.truthTableView.Name = "truthTableView";
            this.truthTableView.RowTemplate.Height = 24;
            this.truthTableView.Size = new System.Drawing.Size(1581, 713);
            this.truthTableView.TabIndex = 4;
            // 
            // truthTableLbl
            // 
            this.truthTableLbl.AutoSize = true;
            this.truthTableLbl.Location = new System.Drawing.Point(17, 14);
            this.truthTableLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.truthTableLbl.Name = "truthTableLbl";
            this.truthTableLbl.Size = new System.Drawing.Size(0, 17);
            this.truthTableLbl.TabIndex = 6;
            // 
            // TruthTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1611, 758);
            this.Controls.Add(this.truthTableLbl);
            this.Controls.Add(this.truthTableView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TruthTableForm";
            this.Text = "Truth Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TruthTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.truthTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView truthTableView;
        private System.Windows.Forms.Label truthTableLbl;
    }
}