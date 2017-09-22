namespace AutomataLogicEngineering
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1009, 22);
            this.inputTextBox.TabIndex = 0;
            // 
            // generateTreeBtn
            // 
            this.generateTreeBtn.Location = new System.Drawing.Point(449, 40);
            this.generateTreeBtn.Name = "generateTreeBtn";
            this.generateTreeBtn.Size = new System.Drawing.Size(117, 23);
            this.generateTreeBtn.TabIndex = 1;
            this.generateTreeBtn.Text = "Generate tree";
            this.generateTreeBtn.UseVisualStyleBackColor = true;
            this.generateTreeBtn.Click += new System.EventHandler(this.generateTreeBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(999, 378);
            this.dataGridView1.TabIndex = 3;
            // 
            // AutomataLogicEngineeringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 498);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.generateTreeBtn);
            this.Controls.Add(this.inputTextBox);
            this.Name = "AutomataLogicEngineeringForm";
            this.Text = "Automata Logic Engineering";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button generateTreeBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

