namespace lab_14
{
    partial class Form1
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chooseFileForExtract = new System.Windows.Forms.Button();
            this.fileForExtract = new System.Windows.Forms.Label();
            this.extract = new System.Windows.Forms.Button();
            this.extractedMessage = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseFileForHide = new System.Windows.Forms.Button();
            this.hiddenMessage = new System.Windows.Forms.RichTextBox();
            this.fileForHide = new System.Windows.Forms.Label();
            this.hide = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images (*.bmp)|*.bmp|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Images (*.bmp)|*.bmp|All files (*.*)|*.*";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.extractedMessage);
            this.tabPage2.Controls.Add(this.extract);
            this.tabPage2.Controls.Add(this.fileForExtract);
            this.tabPage2.Controls.Add(this.chooseFileForExtract);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(816, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Extract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chooseFileForExtract
            // 
            this.chooseFileForExtract.Location = new System.Drawing.Point(12, 26);
            this.chooseFileForExtract.Margin = new System.Windows.Forms.Padding(4);
            this.chooseFileForExtract.Name = "chooseFileForExtract";
            this.chooseFileForExtract.Size = new System.Drawing.Size(138, 44);
            this.chooseFileForExtract.TabIndex = 0;
            this.chooseFileForExtract.Text = "Choose file";
            this.chooseFileForExtract.UseVisualStyleBackColor = true;
            this.chooseFileForExtract.Click += new System.EventHandler(this.chooseFileForExtract_Click);
            // 
            // fileForExtract
            // 
            this.fileForExtract.AutoSize = true;
            this.fileForExtract.Location = new System.Drawing.Point(158, 34);
            this.fileForExtract.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileForExtract.Name = "fileForExtract";
            this.fileForExtract.Size = new System.Drawing.Size(0, 25);
            this.fileForExtract.TabIndex = 1;
            // 
            // extract
            // 
            this.extract.Location = new System.Drawing.Point(10, 92);
            this.extract.Margin = new System.Windows.Forms.Padding(4);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(784, 68);
            this.extract.TabIndex = 2;
            this.extract.Text = "Extract message";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // extractedMessage
            // 
            this.extractedMessage.Location = new System.Drawing.Point(10, 194);
            this.extractedMessage.Margin = new System.Windows.Forms.Padding(4);
            this.extractedMessage.Name = "extractedMessage";
            this.extractedMessage.ReadOnly = true;
            this.extractedMessage.Size = new System.Drawing.Size(786, 361);
            this.extractedMessage.TabIndex = 3;
            this.extractedMessage.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Extracted message";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hide);
            this.tabPage1.Controls.Add(this.fileForHide);
            this.tabPage1.Controls.Add(this.hiddenMessage);
            this.tabPage1.Controls.Add(this.chooseFileForHide);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(816, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hide";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter message";
            // 
            // chooseFileForHide
            // 
            this.chooseFileForHide.Location = new System.Drawing.Point(12, 429);
            this.chooseFileForHide.Margin = new System.Windows.Forms.Padding(4);
            this.chooseFileForHide.Name = "chooseFileForHide";
            this.chooseFileForHide.Size = new System.Drawing.Size(138, 44);
            this.chooseFileForHide.TabIndex = 0;
            this.chooseFileForHide.Text = "Choose file";
            this.chooseFileForHide.UseVisualStyleBackColor = true;
            this.chooseFileForHide.Click += new System.EventHandler(this.chooseFileForHide_Click);
            // 
            // hiddenMessage
            // 
            this.hiddenMessage.Location = new System.Drawing.Point(12, 48);
            this.hiddenMessage.Margin = new System.Windows.Forms.Padding(4);
            this.hiddenMessage.Name = "hiddenMessage";
            this.hiddenMessage.Size = new System.Drawing.Size(786, 361);
            this.hiddenMessage.TabIndex = 2;
            this.hiddenMessage.Text = "";
            // 
            // fileForHide
            // 
            this.fileForHide.AutoSize = true;
            this.fileForHide.Location = new System.Drawing.Point(158, 438);
            this.fileForHide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileForHide.Name = "fileForHide";
            this.fileForHide.Size = new System.Drawing.Size(0, 25);
            this.fileForHide.TabIndex = 3;
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(12, 482);
            this.hide.Margin = new System.Windows.Forms.Padding(4);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(784, 68);
            this.hide.TabIndex = 4;
            this.hide.Text = "Hide message";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 615);
            this.tabControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 652);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "LSB";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox extractedMessage;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.Label fileForExtract;
        private System.Windows.Forms.Button chooseFileForExtract;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Label fileForHide;
        private System.Windows.Forms.RichTextBox hiddenMessage;
        private System.Windows.Forms.Button chooseFileForHide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

