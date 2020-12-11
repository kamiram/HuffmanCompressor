namespace HuffmanCompressor
{
    partial class FormPackTo
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
            this.TextBoxDirectory = new System.Windows.Forms.TextBox();
            this.ButtonFolderBrowser = new System.Windows.Forms.Button();
            this.FolderBrowserDialogDest = new System.Windows.Forms.FolderBrowserDialog();
            this.TextBoxFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxDirectory
            // 
            this.TextBoxDirectory.Location = new System.Drawing.Point(105, 13);
            this.TextBoxDirectory.Name = "TextBoxDirectory";
            this.TextBoxDirectory.Size = new System.Drawing.Size(408, 22);
            this.TextBoxDirectory.TabIndex = 0;
            // 
            // ButtonFolderBrowser
            // 
            this.ButtonFolderBrowser.Location = new System.Drawing.Point(520, 11);
            this.ButtonFolderBrowser.Name = "ButtonFolderBrowser";
            this.ButtonFolderBrowser.Size = new System.Drawing.Size(75, 23);
            this.ButtonFolderBrowser.TabIndex = 1;
            this.ButtonFolderBrowser.Text = "Обзор...";
            this.ButtonFolderBrowser.UseVisualStyleBackColor = true;
            this.ButtonFolderBrowser.Click += new System.EventHandler(this.ButtonFolderBrowser_Click);
            // 
            // FolderBrowserDialogDest
            // 
            this.FolderBrowserDialogDest.Description = "Выберите путь";
            this.FolderBrowserDialogDest.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // TextBoxFileName
            // 
            this.TextBoxFileName.Location = new System.Drawing.Point(105, 41);
            this.TextBoxFileName.Name = "TextBoxFileName";
            this.TextBoxFileName.Size = new System.Drawing.Size(408, 22);
            this.TextBoxFileName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Директория";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя Файла";
            // 
            // ButtonOk
            // 
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(105, 84);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 5;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(438, 84);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FormPackTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 119);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxFileName);
            this.Controls.Add(this.ButtonFolderBrowser);
            this.Controls.Add(this.TextBoxDirectory);
            this.Name = "FormPackTo";
            this.Text = "Сохранить результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxDirectory;
        private System.Windows.Forms.Button ButtonFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogDest;
        private System.Windows.Forms.TextBox TextBoxFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}