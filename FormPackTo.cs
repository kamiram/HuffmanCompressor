using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCompressor
{
    public partial class FormPackTo : Form
    {
        public FormPackTo()
        {
            InitializeComponent();
        }

        private void ButtonFolderBrowser_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialogDest.ShowDialog() == DialogResult.OK)
            {
                TextBoxDirectory.Text = FolderBrowserDialogDest.SelectedPath;
            }
        }

        public string SelectedFileName => Path.Combine(TextBoxDirectory.Text, TextBoxFileName.Text);
    }
}
