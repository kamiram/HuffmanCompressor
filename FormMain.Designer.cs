namespace HuffmanCompressor
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPagePack = new System.Windows.Forms.TabPage();
            this.ButtonPackTo = new System.Windows.Forms.Button();
            this.ButtonPack = new System.Windows.Forms.Button();
            this.TextBoxInputFileName = new System.Windows.Forms.TextBox();
            this.ButtonOpenInputFile = new System.Windows.Forms.Button();
            this.TabPageUnpack = new System.Windows.Forms.TabPage();
            this.ButtonUnpack = new System.Windows.Forms.Button();
            this.TextBoxOutputFileName = new System.Windows.Forms.TextBox();
            this.ButtonOpenOutputFile = new System.Windows.Forms.Button();
            this.TabPageHistory = new System.Windows.Forms.TabPage();
            this.TextBoxHistory = new System.Windows.Forms.TextBox();
            this.OpenFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileDialogOutput = new System.Windows.Forms.OpenFileDialog();
            this.TabControlMain.SuspendLayout();
            this.TabPagePack.SuspendLayout();
            this.TabPageUnpack.SuspendLayout();
            this.TabPageHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControlMain.Controls.Add(this.TabPagePack);
            this.TabControlMain.Controls.Add(this.TabPageUnpack);
            this.TabControlMain.Controls.Add(this.TabPageHistory);
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(0, 0);
            this.TabControlMain.Multiline = true;
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(443, 138);
            this.TabControlMain.TabIndex = 0;
            // 
            // TabPagePack
            // 
            this.TabPagePack.Controls.Add(this.ButtonPackTo);
            this.TabPagePack.Controls.Add(this.ButtonPack);
            this.TabPagePack.Controls.Add(this.TextBoxInputFileName);
            this.TabPagePack.Controls.Add(this.ButtonOpenInputFile);
            this.TabPagePack.Location = new System.Drawing.Point(4, 28);
            this.TabPagePack.Name = "TabPagePack";
            this.TabPagePack.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePack.Size = new System.Drawing.Size(435, 106);
            this.TabPagePack.TabIndex = 0;
            this.TabPagePack.Text = "Архивировать";
            this.TabPagePack.UseVisualStyleBackColor = true;
            // 
            // ButtonPackTo
            // 
            this.ButtonPackTo.Location = new System.Drawing.Point(181, 62);
            this.ButtonPackTo.Name = "ButtonPackTo";
            this.ButtonPackTo.Size = new System.Drawing.Size(244, 23);
            this.ButtonPackTo.TabIndex = 3;
            this.ButtonPackTo.Text = "Сжать и сохранитьт как";
            this.ButtonPackTo.UseVisualStyleBackColor = true;
            this.ButtonPackTo.Click += new System.EventHandler(this.ButtonPackTo_Click);
            // 
            // ButtonPack
            // 
            this.ButtonPack.Location = new System.Drawing.Point(8, 62);
            this.ButtonPack.Name = "ButtonPack";
            this.ButtonPack.Size = new System.Drawing.Size(167, 23);
            this.ButtonPack.TabIndex = 2;
            this.ButtonPack.Text = "Сжать";
            this.ButtonPack.UseVisualStyleBackColor = true;
            this.ButtonPack.Click += new System.EventHandler(this.ButtonPack_Click);
            // 
            // TextBoxInputFileName
            // 
            this.TextBoxInputFileName.Location = new System.Drawing.Point(8, 23);
            this.TextBoxInputFileName.Name = "TextBoxInputFileName";
            this.TextBoxInputFileName.Size = new System.Drawing.Size(338, 22);
            this.TextBoxInputFileName.TabIndex = 1;
            // 
            // ButtonOpenInputFile
            // 
            this.ButtonOpenInputFile.Location = new System.Drawing.Point(352, 22);
            this.ButtonOpenInputFile.Name = "ButtonOpenInputFile";
            this.ButtonOpenInputFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenInputFile.TabIndex = 0;
            this.ButtonOpenInputFile.Text = "Обзор...";
            this.ButtonOpenInputFile.UseVisualStyleBackColor = true;
            this.ButtonOpenInputFile.Click += new System.EventHandler(this.ButtonOpenInputFile_Click);
            // 
            // TabPageUnpack
            // 
            this.TabPageUnpack.Controls.Add(this.ButtonUnpack);
            this.TabPageUnpack.Controls.Add(this.TextBoxOutputFileName);
            this.TabPageUnpack.Controls.Add(this.ButtonOpenOutputFile);
            this.TabPageUnpack.Location = new System.Drawing.Point(4, 28);
            this.TabPageUnpack.Name = "TabPageUnpack";
            this.TabPageUnpack.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageUnpack.Size = new System.Drawing.Size(433, 100);
            this.TabPageUnpack.TabIndex = 1;
            this.TabPageUnpack.Text = "Распаковать";
            this.TabPageUnpack.UseVisualStyleBackColor = true;
            // 
            // ButtonUnpack
            // 
            this.ButtonUnpack.Location = new System.Drawing.Point(9, 62);
            this.ButtonUnpack.Name = "ButtonUnpack";
            this.ButtonUnpack.Size = new System.Drawing.Size(167, 23);
            this.ButtonUnpack.TabIndex = 5;
            this.ButtonUnpack.Text = "Распаковать";
            this.ButtonUnpack.UseVisualStyleBackColor = true;
            this.ButtonUnpack.Click += new System.EventHandler(this.ButtonUnpack_Click);
            // 
            // TextBoxOutputFileName
            // 
            this.TextBoxOutputFileName.Location = new System.Drawing.Point(9, 23);
            this.TextBoxOutputFileName.Name = "TextBoxOutputFileName";
            this.TextBoxOutputFileName.Size = new System.Drawing.Size(338, 22);
            this.TextBoxOutputFileName.TabIndex = 4;
            // 
            // ButtonOpenOutputFile
            // 
            this.ButtonOpenOutputFile.Location = new System.Drawing.Point(353, 22);
            this.ButtonOpenOutputFile.Name = "ButtonOpenOutputFile";
            this.ButtonOpenOutputFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenOutputFile.TabIndex = 3;
            this.ButtonOpenOutputFile.Text = "Обзор...";
            this.ButtonOpenOutputFile.UseVisualStyleBackColor = true;
            // 
            // TabPageHistory
            // 
            this.TabPageHistory.AutoScroll = true;
            this.TabPageHistory.Controls.Add(this.TextBoxHistory);
            this.TabPageHistory.Location = new System.Drawing.Point(4, 28);
            this.TabPageHistory.Name = "TabPageHistory";
            this.TabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageHistory.Size = new System.Drawing.Size(435, 106);
            this.TabPageHistory.TabIndex = 2;
            this.TabPageHistory.Text = "История операций";
            this.TabPageHistory.UseVisualStyleBackColor = true;
            // 
            // TextBoxHistory
            // 
            this.TextBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxHistory.Location = new System.Drawing.Point(3, 3);
            this.TextBoxHistory.Multiline = true;
            this.TextBoxHistory.Name = "TextBoxHistory";
            this.TextBoxHistory.ReadOnly = true;
            this.TextBoxHistory.Size = new System.Drawing.Size(429, 100);
            this.TextBoxHistory.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 138);
            this.Controls.Add(this.TabControlMain);
            this.Name = "FormMain";
            this.Text = "Huffman Compressor";
            this.TabControlMain.ResumeLayout(false);
            this.TabPagePack.ResumeLayout(false);
            this.TabPagePack.PerformLayout();
            this.TabPageUnpack.ResumeLayout(false);
            this.TabPageUnpack.PerformLayout();
            this.TabPageHistory.ResumeLayout(false);
            this.TabPageHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPagePack;
        private System.Windows.Forms.TabPage TabPageUnpack;
        private System.Windows.Forms.TabPage TabPageHistory;
        private System.Windows.Forms.TextBox TextBoxHistory;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogInput;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogOutput;
        private System.Windows.Forms.Button ButtonOpenInputFile;
        private System.Windows.Forms.TextBox TextBoxInputFileName;
        private System.Windows.Forms.Button ButtonPack;
        private System.Windows.Forms.Button ButtonPackTo;
        private System.Windows.Forms.Button ButtonUnpack;
        private System.Windows.Forms.TextBox TextBoxOutputFileName;
        private System.Windows.Forms.Button ButtonOpenOutputFile;
    }
}

