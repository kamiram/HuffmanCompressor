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
            if (inputFileName.Trim().Length == 0 || inputFileName.Trim().Length == 0)
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
                byte[] compressedData = new byte[inputFileData.Length * (101 / 100) + 320];
                int compressedDataSize = Huffman.Compress(inputFileData, compressedData, (uint)inputFileData.Length);
                int eff = 100 * compressedDataSize / inputFileData.Length;
                using (var outputFile = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                {
                    outputFile.Write(BitConverter.GetBytes(inputFileData.Length), 0, 4);
                    outputFile.Write(compressedData, 0, compressedDataSize);
                }
                MessageBox.Show($"Файл '{inputFileName}' сжат {eff}%", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBoxHistory.Text = $"Файл '{inputFileName}' сжат {eff}%\n{TextBoxHistory.Text}";
            }
            catch (IOException ex)
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
            formPackTo.SelectedFileName = TextBoxInputFileName.Text;
            if (formPackTo.ShowDialog(this) == DialogResult.OK)
            {
                PackFile(TextBoxInputFileName.Text, $"{formPackTo.SelectedFileName}");
            }
            formPackTo.Dispose();
        }
        private void ButtonUnpack_Click(object sender, EventArgs e)
        {
            var inputFileName = TextBoxOutputFileName.Text;
            var outputFileName = $"{inputFileName}.restored";

            if (inputFileName.Trim().Length == 0)
            {
                MessageBox.Show("Укажите имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(inputFileName))
            {
                MessageBox.Show($"Файл '{inputFileName }' не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                byte[] inputFileData = new byte[new System.IO.FileInfo(inputFileName).Length - 4];
                int originalSize;
                using (FileStream inputFile = File.OpenRead(inputFileName))
                {
                    byte[] sizeBuff = new byte[4];
                    inputFile.Read(sizeBuff, 0, 4);
                    originalSize = BitConverter.ToInt32(sizeBuff, 0);
                    inputFile.Read(inputFileData, 0, inputFileData.Length);
                }

                byte[] decompressedData = new byte[originalSize];
                uint decompressedDataSize = Huffman.Decompress(inputFileData, decompressedData, (uint)(inputFileData.Length - 4), (uint)originalSize);
                using (var outputFile = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                {
                    outputFile.Write(decompressedData, 0, (int)decompressedDataSize);
                }
                MessageBox.Show($"Файл распакован в '{outputFileName}'.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBoxHistory.Text = $"Файл распакован в '{outputFileName}'.\n{TextBoxHistory.Text}";
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Файл {outputFileName} не может быть записан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ButtonOpenOutputFile_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogOutput.ShowDialog() == DialogResult.OK)
            {
                TextBoxOutputFileName.Text = OpenFileDialogOutput.FileName;
            }
        }
    }
}
