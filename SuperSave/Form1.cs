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

        bool isBinding = false;

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

        // MAIN LOGIC
        private async void Form1_Load(object sender, EventArgs e)
        {
            string data = "5 ;; ";
            if (File.Exists("super.save"))
            {
                data = File.ReadAllText("super.save");
            }
            string[] dataParts = data.Split(" ;; ");
            saveInterval.Value = int.Parse(dataParts[0]);

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

            for(int i = 0; i < dataParts.Length; i++)
            {
                for(int j = 0; j < appsList.Items.Count; j++)
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

                // SAVE
                string contents = saveInterval.Value.ToString() + " ;; ";

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

                File.WriteAllText("super.save", contents);

                timer = new PeriodicTimer(TimeSpan.FromSeconds((double)saveInterval.Value));
            }
        }

        // REFRESH/RESTART PROGRAM
        private void setBind_Click(object sender, EventArgs e)
        {
            //refresh
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Application.Exit();
        }

        private void SuperSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}