namespace AutomataLogicEngineering.UI
{
    partial class HexTreeForm
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
            this.hexTreePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hexTreePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // hexTreePictureBox
            // 
            this.hexTreePictureBox.Location = new System.Drawing.Point(2, 0);
            this.hexTreePictureBox.Name = "hexTreePictureBox";
            this.hexTreePictureBox.Size = new System.Drawing.Size(897, 615);
            this.hexTreePictureBox.TabIndex = 0;
            this.hexTreePictureBox.TabStop = false;
            // 
            // HexTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 617);
            this.Controls.Add(this.hexTreePictureBox);
            this.Name = "HexTreeForm";
            this.Text = "HexTreeForm";
            ((System.ComponentModel.ISupportInitialize)(this.hexTreePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox hexTreePictureBox;
    }
}