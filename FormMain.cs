using System;
using System.Collections;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonOpenInputFile_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogInput.ShowDialog() == DialogResult.OK)
            {
                TextBoxInputFileName.Text = OpenFileDialogInput.FileName;
            }
        }

        private void PackFile(string inputFileName, string outputFileName)
        {
            if (inputFileName.Trim().Length == 0)
            {
                MessageBox.Show("Укажите имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(inputFileName))
            {
                MessageBox.Show($"Файл '{inputFileName}' не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                var inputFileData = File.ReadAllBytes(inputFileName);
              //  inputFileData = Encoding.Default.GetBytes("aaaaaaaaa bb");
                byte[] compressedData = new byte[inputFileData.Length * (101 / 100) + 320];
                int compressedDataSize = Huffman.Compress(inputFileData, compressedData, (uint)inputFileData.Length);
                int eff = 100 * compressedDataSize / inputFileData.Length;
                MessageBox.Show($"Файл '{inputFileName}' сжат {eff}%", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                File.WriteAllBytes(outputFileName, compressedData);
            }
            catch (IOException e)
            {
                MessageBox.Show($"Файл {outputFileName} не может быть записан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void ButtonPack_Click(object sender, EventArgs e)
        {
            PackFile(TextBoxInputFileName.Text, $"{TextBoxInputFileName.Text}.compressed");
        }
        private void ButtonPackTo_Click(object sender, EventArgs e)
        {
            FormPackTo formPackTo = new FormPackTo();
            if (formPackTo.ShowDialog(this) == DialogResult.OK)
            {
                PackFile(TextBoxInputFileName.Text, $"");
            }
            formPackTo.Dispose();
        }
        private void ButtonUnpack_Click(object sender, EventArgs e)
        {
            var fileName = TextBoxInputFileName.Text;
            if (fileName.Trim().Length == 0)
            {
                MessageBox.Show("Укажите имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(fileName))
            {
                MessageBox.Show($"Файл '{fileName}' не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MessageBox.Show($"Файл '{fileName}' сжат", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;

        }
    }
}
