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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperSave));
            appsList = new CheckedListBox();
            saveInterval = new NumericUpDown();
            label1 = new Label();
            setBind = new Button();
            autostart = new CheckBox();
            traystart = new CheckBox();
            trayCollapse = new CheckBox();
            notifyIcon = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)saveInterval).BeginInit();
            SuspendLayout();
            // 
            // appsList
            // 
            appsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            appsList.FormattingEnabled = true;
            appsList.Location = new Point(0, 0);
            appsList.Name = "appsList";
            appsList.Size = new Size(215, 166);
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
            saveInterval.ValueChanged += saveInterval_ValueChanged;
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
            // autostart
            // 
            autostart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            autostart.AutoSize = true;
            autostart.Location = new Point(233, 72);
            autostart.Name = "autostart";
            autostart.Size = new Size(79, 19);
            autostart.TabIndex = 4;
            autostart.Text = "Auto Start";
            autostart.UseVisualStyleBackColor = true;
            autostart.CheckedChanged += autostart_CheckedChanged;
            // 
            // traystart
            // 
            traystart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            traystart.AutoSize = true;
            traystart.Location = new Point(233, 97);
            traystart.Name = "traystart";
            traystart.Size = new Size(86, 19);
            traystart.TabIndex = 5;
            traystart.Text = "Start in tray";
            traystart.UseVisualStyleBackColor = true;
            traystart.CheckedChanged += traystart_CheckedChanged;
            // 
            // trayCollapse
            // 
            trayCollapse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trayCollapse.AutoSize = true;
            trayCollapse.Location = new Point(232, 122);
            trayCollapse.Name = "trayCollapse";
            trayCollapse.Size = new Size(87, 19);
            trayCollapse.TabIndex = 6;
            trayCollapse.Text = "Hide in tray";
            trayCollapse.UseVisualStyleBackColor = true;
            trayCollapse.CheckedChanged += trayCollapse_CheckedChanged;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "SuperSave";
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // SuperSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 162);
            Controls.Add(trayCollapse);
            Controls.Add(traystart);
            Controls.Add(autostart);
            Controls.Add(setBind);
            Controls.Add(label1);
            Controls.Add(saveInterval);
            Controls.Add(appsList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(403000, 1000000);
            MinimumSize = new Size(403, 135);
            Name = "SuperSave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuperSave";
            FormClosing += SuperSave_FormClosing;
            Load += Form1_Load;
            Shown += SuperSave_Shown;
            ((System.ComponentModel.ISupportInitialize)saveInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox appsList;
        private NumericUpDown saveInterval;
        private Label label1;
        private Button setBind;
        private CheckBox autostart;
        private CheckBox traystart;
        private CheckBox trayCollapse;
        private NotifyIcon notifyIcon;
    }
}