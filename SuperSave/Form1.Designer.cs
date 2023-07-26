namespace SuperSave
{
    partial class SuperSave
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appsList = new CheckedListBox();
            saveInterval = new NumericUpDown();
            label1 = new Label();
            setBind = new Button();
            ((System.ComponentModel.ISupportInitialize)saveInterval).BeginInit();
            SuspendLayout();
            // 
            // appsList
            // 
            appsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            appsList.FormattingEnabled = true;
            appsList.Location = new Point(0, 0);
            appsList.Name = "appsList";
            appsList.Size = new Size(215, 94);
            appsList.TabIndex = 0;
            // 
            // saveInterval
            // 
            saveInterval.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveInterval.Location = new Point(328, 14);
            saveInterval.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            saveInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            saveInterval.Name = "saveInterval";
            saveInterval.Size = new Size(48, 23);
            saveInterval.TabIndex = 1;
            saveInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(233, 17);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "Save interval (s)";
            // 
            // setBind
            // 
            setBind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            setBind.Location = new Point(233, 43);
            setBind.Name = "setBind";
            setBind.Size = new Size(143, 23);
            setBind.TabIndex = 3;
            setBind.Text = "Refresh";
            setBind.UseVisualStyleBackColor = true;
            setBind.Click += setBind_Click;
            // 
            // SuperSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 96);
            Controls.Add(setBind);
            Controls.Add(label1);
            Controls.Add(saveInterval);
            Controls.Add(appsList);
            MaximumSize = new Size(403000, 1000000);
            MinimumSize = new Size(403, 135);
            Name = "SuperSave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuperSave";
            FormClosing += SuperSave_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)saveInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox appsList;
        private NumericUpDown saveInterval;
        private Label label1;
        private Button setBind;
    }
}