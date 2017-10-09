﻿namespace AutomataLogicEngineering.UI
{
    using System.Windows.Forms;

    public partial class HexTreeForm : Form
    {
        public HexTreeForm(string imageFilePath)
        {
            InitializeComponent();
            this.hexTreePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.hexTreePictureBox.ImageLocation = imageFilePath;
        }
    }
}
