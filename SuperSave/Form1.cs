using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SuperSave
{
    public partial class SuperSave : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        bool refreshing = false;

        public static string GetCurrentFocusedWindowProcessName()
        {
            IntPtr hWnd = GetForegroundWindow();

            if (hWnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(hWnd, out int processId);
                Process process = Process.GetProcessById(processId);
                return process.ProcessName;
            }

            return null;
        }

        public SuperSave()
        {
            InitializeComponent();
        }

        // thank you stackoverflow and my brain for editing it
        private void appShortcutToDesktop(string linkName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                string app = Process.GetCurrentProcess().MainModule.FileName.Replace("\\", "/");
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
            }
        }

        // MAIN LOGIC
        private async void Form1_Load(object sender, EventArgs e)
        {
            string data = "v2 ;; 1 ;; True ;; False ;; True";
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\super.save"))
            {
                data = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\super.save");
            }
            string[] dataParts = data.Split(" ;; ");

            // save version, if newer or older, delete save
            if (dataParts[0] != "v2") // VER-CH
            {
                dataParts = "v2 ;; 5 ;; True ;; False ;; True".Split(" ;; "); // VER-CH
                File.Delete("super.save");
            }
            saveInterval.Value = int.Parse(dataParts[1]);

            autostart.Checked = bool.Parse(dataParts[2]);
            traystart.Checked = bool.Parse(dataParts[3]);
            trayCollapse.Checked = bool.Parse(dataParts[4]);

            if (autostart.Checked)
            {
                appShortcutToDesktop("SuperSave");
            }
            else
            {
                foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup)))
                {
                    if (file == "SuperSave.url")
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\SuperSave.url");
                    }
                }
            }

            List<string> dps = new List<string>();
            foreach (string dP in dataParts)
            {
                if (!string.IsNullOrWhiteSpace(dP))
                {
                    dps.Add(dP);
                }
            }
            dataParts = dps.ToArray();

            foreach (Process process in Process.GetProcesses())
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                    appsList.Items.Add(Text = process.ProcessName + "      (" + process.MainWindowTitle + ")");
                }
            }

            for (int i = 0; i < dataParts.Length; i++)
            {
                for (int j = 0; j < appsList.Items.Count; j++)
                {
                    string item = appsList.Items[j].ToString().Split("      (")[0];
                    if (item == dataParts[i])
                        appsList.SetItemChecked(j, true);
                }
            }

            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            // ALIVE LOOP
            while (await timer.WaitForNextTickAsync())
            {
                List<string> apps = new();
                int i = 0;
                foreach (string app in appsList.Items)
                {
                    if (appsList.GetItemChecked(i))
                    {
                        apps.Add(app.Split("      (")[0]);
                    }
                    i++;
                }

                if (apps.Contains(GetCurrentFocusedWindowProcessName()))
                {
                    SendKeys.Send("^S");
                }

                SaveSettings();

                timer = new PeriodicTimer(TimeSpan.FromSeconds((double)saveInterval.Value));
            }
        }

        // REFRESH/RESTART PROGRAM
        private void setBind_Click(object sender, EventArgs e)
        {
            //refresh
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            refreshing = true;
            Application.Exit();
        }

        private void SuperSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!trayCollapse.Checked) return;
            if (!refreshing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(10, "Hey!", "You can reopen SuperSave in the tray menu. Right click the icon to exit SuperSave.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
            else
            {
                // do some funny lying to trick the program into not closing !!! :>
                refreshing = true;
                Application.Exit();
            }
        }

        private void autostart_CheckedChanged(object sender, EventArgs e)
        {
            if (autostart.Checked)
            {
                appShortcutToDesktop("SuperSave");
            }
            else
            {
                foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup)))
                {
                    if (file == "SuperSave.url")
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\SuperSave.url");
                    }
                }
            }

            SaveSettings();
        }

        private void traystart_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SuperSave_Shown(object sender, EventArgs e)
        {
            if (traystart.Checked)
            {
                notifyIcon.Visible = true;
                Hide();
            }
        }

        void SaveSettings()
        {
            List<string> apps = new();
            int i = 0;
            foreach (string app in appsList.Items)
            {
                if (appsList.GetItemChecked(i))
                {
                    apps.Add(app.Split("      (")[0]);
                }
                i++;
            }

            // SAVE
            string contents = "v2" + " ;; " + saveInterval.Value.ToString() + " ;; " + autostart.Checked.ToString() + " ;; " + traystart.Checked.ToString() + " ;; " + trayCollapse.Checked.ToString() + " ;; "; // VER-CH

            int j = 0;
            foreach (string app in apps)
            {
                if (j - 1 < apps.Count)
                {
                    contents += app + " ;; ";
                }
                else
                {
                    contents += app;
                }
            }

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\super.save", contents);
        }

        private void trayCollapse_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void saveInterval_ValueChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}