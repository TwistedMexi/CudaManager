using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using CUDA_Manager.NVext.Hardware.Nvidia;
using CUDA_Manager.NVext.Hardware;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace CUDA_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Default Configurables
            this.OHprotect.Checked = true;
            this.OHprotect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolMinTray.Checked = false;
            this.toolMinTray.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.conShowWarnings.Checked = true;
            this.conShowWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            //Get user defaults if they exist.
            LoadSettings();
        }
        DateTime starttime;
        Process p = new Process();
        TimeSpan timerunning;
        static Mutex _m;
        static string minepath = Environment.CurrentDirectory + "\\Miners\\";
        static string datpath = Environment.CurrentDirectory + "\\Data\\";
        private delegate bool StateChecker();
        public bool idlestart = false;
        bool idlestarter = false;
        public int idletimer = -1;
        public string idleminer;
        public List<string[]> logs = new List<string[]>();
        public int unsafetmp = 80;
        public int shutdowntmp = 100;
        public List<string> miners = new List<string>();
        bool nocheck = false;
        bool isDirty = false;
        bool import = false;
        bool hasFailed = true;
        bool ghosting = false;
        bool skiphr = true;
        string maingpu;
        double hr = 0;
        double hrsum = 0;
        int hrcnt = 2;
        int failstat = 0;
        int failcnt = 0;
        int maxfail = 3;
        int yays = 0;
        int timespent = 0;
        int rowidx = 0;
        int badminers = 0;
        string source;
        string output;
        string activeminer;
        string stopReason;
        //Sensor Dealings
        List<NvidiaGPU> gpulist = new List<NvidiaGPU>();
        List<Sensor> fansensors = new List<Sensor>();
        List<Sensor> tempsensors = new List<Sensor>();
        bool ovheat = false;
        bool ohprotecting = false;
        int hightemp = 0;
        int fanspeed = 0;
        int fantarget = 0;
        string[] fansets;
        string fansetting = "[Default]";
        string fanstat;
        string tempstat;

        #region Talk to Cudaminer
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);
        // Delegate type to be used as the Handler Routine for SCCH
        delegate Boolean ConsoleCtrlDelegate(CtrlTypes CtrlType);

        // Enumerated type for the control messages sent to the handler routine
        enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);


        void SendControlC(Process proc)
        {
            try
            {
                try
                {
                    p.CancelOutputRead();
                    p.CancelErrorRead();
                }
                catch { }

                //This does not require the console window to be visible.
                Process[] localByName = Process.GetProcessesByName("cudaminer");
                if (AttachConsole((uint)proc.Id))
                {
                    SetConsoleCtrlHandler(null, true);
                    GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
                    int timer = 0;
                    while (localByName.Count() == Process.GetProcessesByName("cudaminer").Count() && localByName.Count() > 0)
                    {
                        timer++;
                        //Twiddle our thumbs for a second.
                        if (timer > 30)
                        {
                            GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
                        }
                        Thread.Sleep(20);
                    }
                    FreeConsole();

                    SetConsoleCtrlHandler(null, false);
                }
                proc.Kill();
            }
            catch
            {
                //there wasn't a process to close anyway.
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsSingleInstance())
            {
                MessageBox.Show("This CUDA Manager is already running!\r\nIf you want to run parallel miners, please make a separate Cuda Manager folder.", "CUDA Manager");
                nocheck = true;
                this.Close();
            }
            else
            {
                try
                {
                    if (!Directory.Exists(minepath))
                        Directory.CreateDirectory(minepath);
                }
                catch { MessageBox.Show("Unable to create Miner directory.\r\nIf UAC is turned on, start with \"Run as Administrator.\""); }
                try
                {
                    if (!Directory.Exists(datpath))
                        Directory.CreateDirectory(datpath);
                }
                catch { MessageBox.Show("Unable to create Miner directory.\r\nIf UAC is turned on, start with \"Run as Administrator.\""); }
                //MessageBox.Show("This is a DEBUG version of CUDA Manager.\r\n\r\nIf you have not been asked to test a copy of CUDA Manager\r\nPlease close this, and re-download from:\r\nhttp://reddit.com/r/cudamanager");
                CudaCheck();
                getSensors();
                dirtyCheck();
                //set one-time props for p
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.OutputDataReceived += ConsoleDataReceived;
                p.ErrorDataReceived += ConsoleDataReceived;

                LoadListDat();
                CBcores.SelectedIndex = 0;
                bg_idler.RunWorkerAsync();
            }
        }


        #region General Buttons
        private void buImport_Click(object sender, EventArgs e)
        {
            opFilediag.ShowDialog();
            if (opFilediag.FileName != null && opFilediag.FileName != "")
            {
                import = true;
                batLoader(opFilediag.FileName, opFilediag.SafeFileName);
            }
        }

        //Add Miner
        private void buAddMine_Click(object sender, EventArgs e)
        {
            tbnickname.Text = tbnickname.Text.Trim();
            TBstrat.Text = TBstrat.Text.Trim();
            tbWorker.Text = tbWorker.Text.Trim();
            TBpass.Text = TBpass.Text.Trim();
            tbConfig.Text = tbConfig.Text.Trim();

            if (!miners.Contains(tbnickname.Text))
            {
                string key = tbnickname.Text;
                if (import)
                {
                    import = false;
                    batBuilder(key, true, source);
                }
                else
                {
                    batBuilder(key, false, source);
                }
                miners.Add(key);
                string[] entry = new string[4];
                entry[0] = key;
                entry[1] = TBstrat.Text;
                entry[2] = tbWorker.Text;
                entry[3] = "3";
                dgView.Rows.Add(entry);
                SaveListDat();
            }
            else
                MessageBox.Show("This miner already exists!\r\nPlease pick a different nickname.");
        }


        private void buShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            TBpass.UseSystemPasswordChar = false;
        }

        private void buShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            TBpass.UseSystemPasswordChar = true;
        }

        private void buStart_Click(object sender, EventArgs e)
        {
            rowidx = 0;
            stopReason = "Reason: Manually stopped by user.\r\n";
            MinerController(false);
        }

        #endregion


        #region Config Control

        private void tsSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig(activeminer, tsConfig.Text.Replace("Config: ", ""));
        }

        private void tsConfig_TextChanged(object sender, EventArgs e)
        {
            if (!tsConfig.Text.Contains("N/A"))
                tsSaveConfig.Enabled = true;
            else
                tsSaveConfig.Enabled = false;
        }
        #endregion

        #region Grid Controls

        private void buMup_Click(object sender, EventArgs e)
        {
            DataGridView grid = dgView;
            try
            {
                int totalRows = grid.Rows.Count;
                int idx = grid.SelectedCells[0].OwningRow.Index;
                if (idx == 0)
                    return;
                int col = grid.SelectedCells[0].OwningColumn.Index;
                DataGridViewRowCollection rows = grid.Rows;
                DataGridViewRow row = rows[idx];
                rows.Remove(row);
                rows.Insert(idx - 1, row);
                grid.ClearSelection();
                grid.Rows[idx - 1].Cells[col].Selected = true;

            }
            catch { }
            SaveListDat();
        }

        private void buMdwn_Click(object sender, EventArgs e)
        {
            DataGridView grid = dgView;
            try
            {
                int totalRows = grid.Rows.Count;
                int idx = grid.SelectedCells[0].OwningRow.Index;
                if (idx == totalRows - 1)
                    return;
                int col = grid.SelectedCells[0].OwningColumn.Index;
                DataGridViewRowCollection rows = grid.Rows;
                DataGridViewRow row = rows[idx];
                rows.Remove(row);
                rows.Insert(idx + 1, row);
                grid.ClearSelection();
                grid.Rows[idx + 1].Cells[col].Selected = true;
            }
            catch { }
            SaveListDat();
        }

        private void buRemove_Click(object sender, EventArgs e)
        {
            if (dgView.SelectedRows.Count > 0)
            {
                File.Delete(minepath + dgView.SelectedRows[0].Cells[0].Value + ".bat");
                miners.Remove(dgView.SelectedRows[0].Cells[0].Value.ToString());
                dgView.Rows.Remove(dgView.SelectedRows[0]);
                SaveListDat();
            }
        }

        private void buLoadSet_Click(object sender, EventArgs e)
        {
            import = true;
            string name = dgView.SelectedRows[0].Cells[0].Value.ToString();
            batLoader(minepath + name + ".bat", name);
        }

        private void conSelMiner_Click(object sender, EventArgs e)
        {
            rowidx = dgView.SelectedRows[0].Index;
            MinerController(false);
        }

        private void conDG_Opening(object sender, CancelEventArgs e)
        {
            if (dgView.Rows.Count > 0 && buStart.Text == "Start Miner" && buStart.Enabled)
                conSelMiner.Enabled = true;
            else
                conSelMiner.Enabled = false;
        }

        #endregion


        #region File Methods

        private void batLoader(string filename, string safename)
        {
            try
            {
                bool skip = false;
                string opconfig = null;
                if (File.Exists(filename))
                {
                    source = filename;
                    string[] loadbat = File.ReadAllLines(filename);
                    bool found = false;
                    foreach (string line in loadbat)
                    {
                        string[] sepline = line.Split('\\');
                        if (sepline[sepline.Count() - 1].ToLower().Replace("@","").Trim().StartsWith("cudaminer"))
                        {
                            found = true;
                            string[] divi = sepline[sepline.Count() - 1].Split(' ');
                            int indkeep = 0;
                            foreach (string div in divi)
                            {
                                indkeep++;
                                if (div.Contains("-H"))
                                {
                                    switch (divi[indkeep])
                                    {
                                        case "0":
                                            CBcores.SelectedIndex = 1;
                                            break;
                                        case "1":
                                            CBcores.SelectedIndex = 2;
                                            break;
                                        default:
                                            CBcores.SelectedIndex = 0;
                                            break;
                                    }
                                    skip = true;
                                }
                                else if (div.Contains("-i"))
                                {
                                    switch (divi[indkeep])
                                    {
                                        case "0":
                                            chkInter.Checked = false;
                                            break;
                                        default:
                                            chkInter.Checked = true;
                                            break;
                                    }
                                    skip = true;
                                }
                                else if (div.Contains("-o"))
                                {
                                    TBstrat.Text = divi[indkeep];
                                    tbnickname.Text = safename.Replace(".bat", "");
                                    skip = true;
                                }
                                else if (div.Contains("-O"))
                                {
                                    String[] wrksplit = divi[indkeep].Split(':');
                                    tbWorker.Text = wrksplit[0];
                                    TBpass.Text = wrksplit[1];
                                    skip = true;
                                }
                                else if (div.Contains("-u"))
                                {
                                    tbWorker.Text = divi[indkeep];
                                    skip = true;
                                }
                                else if (div.Contains("-p"))
                                {
                                    TBpass.Text = divi[indkeep];
                                    skip = true;
                                }
                                else if (skip)
                                {
                                    skip = false;
                                }
                                else if (!div.ToLower().Contains("cudaminer"))
                                {
                                    opconfig += div + " ";
                                }
                            }
                            tbConfig.Text = opconfig;
                            TBstrat.ForeColor = Color.Black;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("Selected file does not have a cudaminer command!");
                    }
                }
            }
            catch { MessageBox.Show("Unable to load miner file."); }
        }

        private void batBuilder(string key, bool import, string source)
        {
            string inter = "0";
            if (chkInter.Checked)
                inter = "1";

            string core = "2";
            if (CBcores.SelectedIndex == 1)
                core = "0";
            else if (CBcores.SelectedIndex == 2)
                core = "1";

            string command = "cudaminer.exe " + tbConfig.Text + " -i " + inter + " -H " + core + " -o " + TBstrat.Text + " -O " + tbWorker.Text + ":" + TBpass.Text;

            try
            {
                if (import && File.Exists(source))
                {
                    string[] loadbat = File.ReadAllLines(source);
                    StreamWriter newbat = new StreamWriter(minepath + key + ".bat");
                    foreach (string line in loadbat)
                    {
                        string[] sepline = line.Split('\\');
                        if (sepline[sepline.Count() - 1].ToLower().StartsWith("cudaminer"))
                            newbat.WriteLine(command);
                        else
                            newbat.WriteLine(line);
                    }
                    newbat.Close();
                }
                else
                    File.WriteAllText(minepath + key + ".bat", command);
            }
            catch { MessageBox.Show("Unable to create miner.\r\nTry running as Administrator."); }

        }

        private void SaveConfig(string key, string config)
        {
            try
            {

                string[] loadbat = File.ReadAllLines(minepath + key + ".bat");
                StreamWriter newbat = new StreamWriter(minepath + key + ".bat");
                foreach (string line in loadbat)
                {
                    if (line.ToLower().StartsWith("cudaminer") && !line.Contains("-l"))
                        newbat.WriteLine(line + " -l " + config);
                    else
                        newbat.WriteLine(line);
                }
                newbat.Close();
            }
            catch { MessageBox.Show("Unable to save config to miner."); }
        }

        private void SaveSettings(bool closing)
        {
            try
            {
                string[] Pset = new string[10];
                Pset[0] = toolOnTop.Checked.ToString();
                Pset[1] = toolMinTray.Checked.ToString();
                Pset[2] = OHprotect.Checked.ToString();
                Pset[3] = conShowWarnings.Checked.ToString();
                Pset[4] = fansetting;
                Pset[5] = unsafetmp.ToString();
                Pset[6] = shutdowntmp.ToString();

                if (idletimer != -1)
                {
                    Pset[7] = idlestart.ToString();
                    Pset[8] = idletimer.ToString();
                    Pset[9] = idleminer;
                }

                File.WriteAllLines(datpath + "settings.dat", Pset);

                if (closing)
                    File.Delete(datpath + "session.dat");
            }
            catch { MessageBox.Show("Unable to save CUDA Manager settings."); }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(datpath + "settings.dat"))
                {
                    string[] Pget = null;
                    Pget = File.ReadAllLines(datpath + "settings.dat");

                    toolOnTop.Checked = Convert.ToBoolean(Pget[0]);
                    toolMinTray.Checked = Convert.ToBoolean(Pget[1]);
                    OHprotect.Checked = Convert.ToBoolean(Pget[2]);
                    conShowWarnings.Checked = Convert.ToBoolean(Pget[3]);
                    fansetting = Pget[4];
                    if (fansetting != "[Default]")
                        tsSetFan.SelectedItem = Pget[4];

                    try //V1.0 settings upgrade assistance.
                    {
                        unsafetmp = Convert.ToInt32(Pget[5]);
                        shutdowntmp = Convert.ToInt32(Pget[6]);
                        idlestart = Convert.ToBoolean(Pget[7]);
                        idletimer = Convert.ToInt32(Pget[8]);
                        idleminer = Pget[9];
                    }
                    catch { }
                }

                if (File.Exists(datpath + "session.dat"))
                {
                    fansets = File.ReadAllLines(datpath + "session.dat");
                    isDirty = true;
                }
            }
            catch { MessageBox.Show("Unable to load settings. Has the settings file been modifed manually?"); }
        }

        private void SaveListDat()
        {
            try
            {
                List<string[]> entries = new List<string[]>();
                foreach (DataGridViewRow entry in dgView.Rows)
                {
                    string[] data = new string[4];
                    data[0] = entry.Cells[0].Value.ToString();
                    data[1] = entry.Cells[1].Value.ToString();
                    data[2] = entry.Cells[2].Value.ToString();
                    data[3] = entry.Cells[3].Value.ToString();
                    entries.Add(data);
                }
                Serializer(entries, datpath + "failover.dat");
            }
            catch { MessageBox.Show("Unable to save failover database."); }
        }

        private void LoadListDat()
        {
            string dat = datpath + "failover.dat";
            try
            {
                if (File.Exists(dat))
                {
                    List<string[]> data = DeSerializer(dat);
                    foreach (string[] line in data)
                    {
                        dgView.Rows.Add(line);
                        miners.Add(line[0]);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Unable to load Failover configuration.");
                File.Move(dat, datpath + "[BAD]failover.dat");
            }
        }


        private void Serializer(List<string[]> data, string path)
        {
            using (var stream = File.Create(path))
            {
                var serializer = new XmlSerializer(typeof(List<string[]>));
                serializer.Serialize(stream, data);
            }
        }


        private List<string[]> DeSerializer(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                var serializer = new XmlSerializer(typeof(List<string[]>));
                return (List<string[]>)serializer.Deserialize(stream);
            }
        }

        #endregion

        #region Loader Methods

        static bool IsSingleInstance()
        {
            try
            {
                // Try to open existing mutex.
                Mutex.OpenExisting(minepath.Replace(Path.DirectorySeparatorChar, '_'));
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                _m = new Mutex(true, minepath.Replace(Path.DirectorySeparatorChar, '_'));

                // Only one instance.
                return true;
            }
            // More than one instance.
            return false;
        }

        private void dirtyCheck()
        {
            Process[] dirtyruns = Process.GetProcessesByName("cudaminer");
            if (dirtyruns.Count() > 0)
            {
                string content = "Instances of Cudaminer appear to be running already.\r\nThis may be caused if CUDA Manager was closed unexpectedly.\r\n\r\nWould you like to close these instances now?";
                DialogResult dialogResult = MessageBox.Show(content, "Cudaminers Active!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    Process[] cmds = Process.GetProcessesByName("cmd");
                    foreach (Process p in cmds)
                    {
                        if (p.MainWindowTitle == "")
                            SendControlC(p);
                    }

                    foreach (Process p in dirtyruns)
                    {
                        SendControlC(p);
                    }
                }
            }
        }

        private void getSensors()
        {
            try
            {
                NvidiaGroup gpus = new NvidiaGroup();
                StringBuilder fancons = new StringBuilder();
                foreach (NvidiaGPU gpu in gpus.Hardware)
                {
                    gpulist.Add(gpu);
                    foreach (Sensor sense in gpu.Sensors)
                    {
                        if (sense.SensorType == SensorType.Temperature)
                            tempsensors.Add(sense);

                        if (sense.SensorType == SensorType.Control)
                        {
                            fansensors.Add(sense);
                            fancons.AppendLine(sense.Control.DefaultPolicy + "," + sense.Control.DefaultLevel);
                        }
                    }
                }

                //Protect default fan settings.
                if (!isDirty)
                    File.WriteAllText(datpath + "session.dat", fancons.ToString());

                bg_sensors.RunWorkerAsync();
            }
            catch { }

        }

        private void CudaCheck()
        {
            if (File.Exists(minepath + "cudaminer.exe") && File.Exists(minepath + "pthreadVC2.dll") && (File.Exists(minepath + "cudart64_55.dll") || File.Exists(minepath + "cudart32_55.dll")))
            {
                buStart.Enabled = true;
                tsStart.Enabled = true;
            }
            else
                MessageBox.Show("Cudaminer not found!\r\nPlease download a bundled version of CUDA Manager or provide your own.");
        }

        #endregion

        #region Miner Methods

        private void MinerController(bool halt)
        {
            if (buStart.Text == "Start Miner" && !halt)
            {
                if (dgView.Rows.Count > 0)
                {
                    this.Icon = Properties.Resources.dminer_on;
                    trayIcon.Icon = Properties.Resources.dminer_on;
                    tsStatus.Text = "Status: Sending miner into a hole...";
                    tsTime.Text = "Time Elapsed: 0 min.";
                    bg_tray.RunWorkerAsync();
                    bg_monitor.RunWorkerAsync();
                    bg_minemgr.RunWorkerAsync();
                    buStart.Enabled = false;
                    buStart.ForeColor = Color.DarkRed;
                    buStart.Text = "Stop Miner";
                    tsStart.Enabled = false;
                    tsStart.Text = "Stop Miner";
                }
                else
                    MessageBox.Show("You have to add a miner before you can put one to work!");
            }
            else
            {
                this.Icon = Properties.Resources.dminer_off;
                trayIcon.Icon = Properties.Resources.dminer_off;
                buStart.Enabled = false;
                tsStart.Enabled = false;
                bg_tray.CancelAsync();
                bg_monitor.CancelAsync();
                bg_minemgr.CancelAsync();
                SendControlC(p);
                tsStatus.Text = "Status: Ready...";
                buStart.ForeColor = Color.DarkGreen;
                buStart.Text = "Start Miner";
                tsStart.Text = "Start Miner";
                laActive.Text = "Active Miner: N/A";
                if (!bg_idler.IsBusy)
                    bg_idler.RunWorkerAsync();
            }
        }

        private void failover(string key)
        {
            try
            {
                if (failstat > 0)
                    Logger("[Failover] Abandoned " + activeminer + ". Switched to " + key);

                starttime = DateTime.Now;
                string filename = minepath + key + ".bat";
                activeminer = key;
                p.StartInfo.FileName = filename;
                p.StartInfo.WorkingDirectory = minepath;

                if (p.Start())
                {
                    // Begin async stdout and stderr reading
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    bg_minemgr.ReportProgress(2);
                }
                else
                {
                    MessageBox.Show("Unable to start miner!");
                    bg_minemgr.ReportProgress(4);
                }
            }
            catch
            {
                bg_minemgr.ReportProgress(3);
            }
        }

        private void ConsoleDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data != "")
            {
                output = e.Data;
                try
                {
                    bg_minemgr.ReportProgress(1);
                }
                catch { }
                Thread.Sleep(50); //slow the feeds down so they don't double-talk.
            }
        }

        #endregion

        #region Sensor Methods

        private void FanSet()
        {
            fantarget = 0;
            if (fansetting != "Auto" && fansetting != "[Default]")
            {
                fantarget = Convert.ToInt32(fansetting.Replace("%", ""));
                FanController(false, fantarget);
            }
            else if (fansetting == "Auto")
                FanController(true, 0);
            else
                FanController(false, 0);
        }

        private void FanController(bool auto, int value)
        {
            foreach (Sensor fan in fansensors)
            {

                if (auto)
                    fan.Control.SetAuto();
                else if (value != 0)
                {
                    if (fan.Control.MaxSoftwareValue < value)
                        value = (int)fan.Control.MaxSoftwareValue;
                    else if (fan.Control.MinSoftwareValue > value)
                        value = (int)fan.Control.MinSoftwareValue;

                    fan.Control.SetSoftware(value);
                }
                else if (isDirty)
                {
                    string[] fanS = fansets[fan.Index].Split(',');
                    int p = Convert.ToInt32(fanS[0]);
                    int l = Convert.ToInt32(fanS[1]);
                    fan.Control.SetDirtyDefault(p, l);
                }
                else
                {
                    fan.Control.SetDefault();
                }
            }

        }

        private void heatShield()
        {
            if (ovheat && OHprotect.Checked)
            {
                if (!ohprotecting)
                {
                    FanController(false, 100);
                    ohprotecting = true;
                }
            }
            else if (ohprotecting)
            {
                if (hightemp <= unsafetmp - 5)
                {
                    ohprotecting = false;
                    FanController(true, 0);
                    Logger("[Protective Cooling] Returned to safe temperatures.");
                }
            }
            else if (fantarget > fanspeed)
                FanController(false, fantarget);
        }


        //trayIcon Handler
        public void inflateBalloon(string title, string text, ToolTipIcon ico)
        {
            if (conShowWarnings.Checked)
            {
                trayIcon.BalloonTipTitle = title;
                trayIcon.BalloonTipText = text;
                trayIcon.BalloonTipIcon = ico;
                trayIcon.ShowBalloonTip(5000);
            }
        }


        #endregion


        #region Background Work

        //Delegation
        private void bgCleaner()
        {
            if (!bg_tray.IsBusy && !bg_monitor.IsBusy && !bg_minemgr.IsBusy)
            {
                buStart.Enabled = true;
                tsStart.Enabled = true;
            }
        }


        //BG Miner
        private void bg_minemgr_DoWork(object sender, DoWorkEventArgs e)
        {
            //clear the stats
            yays = 0;
            hr = 0;
            hrcnt = 2;
            hrsum = 0;
            skiphr = true;
            failstat = 0;
            badminers = 0;
            bool first = true;
            int hour = 0;
            output = null;
            while (!bg_minemgr.CancellationPending)
            {
                if (hasFailed)
                {
                    if (!first)
                        failstat++;

                    hasFailed = false;
                    if (rowidx >= dgView.Rows.Count)
                        rowidx = 0;
                    maxfail = Convert.ToInt32(dgView.Rows[rowidx].Cells[3].Value);
                    if (idlestarter)
                    {
                        failover(idleminer);
                        idlestarter = false;
                    }
                    else
                        failover(dgView.Rows[rowidx].Cells[0].Value.ToString());
                    rowidx++;
                    first = false;
                }
                if (hour == 3600)
                {
                    Logger("[Miner Entry] " + activeminer);
                    hour = 0;
                }
                hour++;

                Thread.Sleep(1000);
            }
            hasFailed = true;
        }

        private void bg_minemgr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                try
                {
                    if (!debugbox.IsDisposed)
                    {
                        if (debugbox.Lines.Count() > 500)
                        {
                            int index = debugbox.Text.IndexOf(Environment.NewLine);
                            debugbox.Text = debugbox.Text.Remove(0, debugbox.Lines[0].Length + 2);
                        }
                        if (output != null && debugbox.Lines.Count() > 0)
                        {
                            if (output != debugbox.Lines[debugbox.Lines.Count() - 2])
                                debugbox.AppendText(output + "\r\n");
                        }
                        else if (output != null)
                            debugbox.AppendText(output + "\r\n");

                        //get hr
                        if (output.EndsWith("hash/s"))
                        {
                            string[] hrtmp = output.Split(',');
                            string[] hrtmp2 = null;
                            if (hrtmp.Count() == 2)
                                hrtmp2 = hrtmp[1].Split(' ');
                            else if (hrtmp.Count() == 3)
                                hrtmp2 = hrtmp[2].Split(' ');
                            if (hrsum == 0)
                            {
                                if (skiphr)
                                    skiphr = false;
                                else
                                {
                                    hrsum = Convert.ToDouble(hrtmp2[1], CultureInfo.InvariantCulture);
                                    hr = hrsum;
                                }
                            }
                            else
                            {
                                hrsum += Convert.ToDouble(hrtmp2[1], CultureInfo.InvariantCulture);
                                hr = hrsum / hrcnt;
                                if (output.Contains(maingpu))
                                    hrcnt++;
                            }
                        }
                        else if (output.Contains("launch configuration"))
                        {
                            string[] split = output.Split(' ');
                            tsConfig.Text = String.Format("Config: {0}", split[7]);
                        }
                        else if (output.Contains("yay"))
                        {
                            yays++;
                        }

                        if (maingpu == null && output.Contains("GPU #"))
                        {
                            string[] arr1 = output.Split(']');
                            string[] arr2 = arr1[1].Split(':');
                            maingpu = arr2[0];
                        }

                        //report to monitor
                        if ((output.Contains("failed") || output.Contains("interrupted")) && !output.Contains("HTTP"))
                            failcnt++;
                        else if (!output.Contains("retry") && !output.Contains("connection") && !output.Contains("HTTP"))
                            failcnt = 0;
                    }
                }
                catch { }
            }
            else if (e.ProgressPercentage == 2)
            {
                tsStatus.Text = "Status: Mining away!";
                buStart.Enabled = true;
                tsStart.Enabled = true;
                laActive.Text = "Active Miner: " + activeminer;
                lalfails.Text = "Failovers: " + failstat;
                if (failstat == 0)
                    Logger("[Miner Started] " + activeminer);
            }
            else if (e.ProgressPercentage == 3)
            {
                if (dgView.Rows.Count == 1 || dgView.Rows.Count <= badminers++)
                {
                    inflateBalloon("Miner not found!", "Out of viable miners. Halted.", ToolTipIcon.Error);
                    stopReason = "Reason: Miner not found.";
                    MinerController(true);
                }
                else
                {
                    inflateBalloon("Miner not found!", "Miner file could not be found. Trying next miner.", ToolTipIcon.Error);
                    debugbox.AppendText("[!]Miner not found. Sending next miner in...\r\n");
                    hasFailed = true;
                }
            }
            else
            {
                inflateBalloon("Unable to start miner!", "cudaminer could not be started.", ToolTipIcon.Error);
                stopReason = "Reason: Unable to start miner.";
                MinerController(true);
            }
        }

        //This hits only when the miner is stopped.
        private void bg_minemgr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgCleaner();
            debugbox.AppendText("Miner returned after " + Math.Round((double)timespent / 60, 2) + " hours of work.\r\n" + stopReason);
            Logger("Miner Stopped. Reason: User Requested.");
        }

        private void bg_all_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgCleaner();
        }

        private void bg_sensors_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bg_sensors.CancellationPending)
            {
                foreach (NvidiaGPU gpu in gpulist)
                    gpu.Update();

                ovheat = false;
                tempstat = "GPU: ";
                int tmpcnt = 0;
                foreach (Sensor temps in tempsensors)
                {
                    if (temps.Index == 0 || (hightemp < temps.Value))
                        hightemp = (int)temps.Value;
                    if (temps.Value >= unsafetmp)
                        ovheat = true;
                    tempstat += temps.Value + "°C";
                    if (tempsensors.Count > 1 && tmpcnt++ < (tempsensors.Count - 1))
                        tempstat += " | ";
                }
                fanstat = "Fan: ";
                int fancnt = 0;
                foreach (Sensor fans in fansensors)
                {
                    if (fans.Index == 0 || (fanspeed > fans.Value))
                        fanspeed = (int)fans.Value;
                    fanstat += fans.Value + "%";
                    if (fansensors.Count > 1 && fancnt++ < (fansensors.Count - 1))
                        fanstat += " | ";
                }
                bg_sensors.ReportProgress(1);


                //save GPU from overheat
                heatShield();

                Thread.Sleep(500);
            }
        }

        private void bg_sensors_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ovheat)
                tsTemps.ForeColor = Color.DarkRed;
            else if (hightemp > unsafetmp - 5)
                tsTemps.ForeColor = Color.DarkOrange;
            else
                tsTemps.ForeColor = Color.Blue;

            tsTemps.Text = tempstat;
            tsFanstat.Text = fanstat;
            trayIcon.Text = "CUDA Manager\r\n" + TrayTipper() + "\r\n" + tsHR.Text.Replace("Avg. Hashrate: ", "") + "\r\n" + hightemp + "°C";
        }

        public string TrayTipper()
        {
            if (activeminer != null && buStart.Text == "Stop Miner")
            {
                string threshold = "CUDA Manager\r\n" + "\r\n" + tsHR.Text.Replace("Avg. Hashrate: ", "") + "\r\n" + hightemp + "°C";
                int limiter = (63 - threshold.Length) - 3;
                if (activeminer.Length > limiter)
                    return activeminer.Substring(0, limiter) + "...";
                return activeminer;
            }
            return "Idle";
        }

        //Monitor
        private void bg_monitor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bg_monitor.CancellationPending)
            {
                if (maxfail <= failcnt)
                {
                    SendControlC(p);
                    bg_monitor.ReportProgress(1);
                    hasFailed = true;
                    failcnt = 0;
                }
                bg_monitor.ReportProgress(2);
                Thread.Sleep(1000);
            }
        }

        private void bg_monitor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                debugbox.AppendText("[!]Retry limit reached. Miner abandoned. Sending next miner in...\r\n");
                inflateBalloon("[!]Retry Limit Reached", "Miner abandoned. Sending next miner in...", ToolTipIcon.Info);
            }
            else if (e.ProgressPercentage == 2)
            {
                timerunning = DateTime.Now.Subtract(starttime);
                timespent = (int)timerunning.TotalMinutes;

                if (timerunning.TotalHours >= 1)
                    tsTime.Text = "Time Elapsed: " + ((int)timerunning.TotalHours).ToString() + " hr. " + timerunning.Minutes.ToString() + " min.";
                else
                    tsTime.Text = "Time Elapsed: " + timespent.ToString() + " min.";

                tsHR.Text = "Avg. Hashrate: " + ((int)hr).ToString() + "kh/s";

                if (timespent > 0)
                    tsYay.Text = "Yays: " + (yays / timespent) + "/min";
                else
                    tsYay.Text = "Yays: " + yays.ToString() + "/min";
            }
        }


        //Tray Handler
        private void bg_tray_DoWork(object sender, DoWorkEventArgs e)
        {
            bool HasShown = false;
            bool unstable = false;
            int shutdown = 30;
            int showtimer = 30;
            while (!bg_tray.CancellationPending)
            {
                if (unstable)
                {
                    if (hightemp >= shutdowntmp)
                    {
                        if (shutdown == 0)
                        {
                            Logger("[Miner Halt] Reason: Unstable GPU Temperatures.");
                            inflateBalloon("[!] Miner has been stopped.", "Mining halted due to unstable GPU temperatures.(100°C)\r\nPlease consider checking GPU fans for dust build-up.", ToolTipIcon.Info);
                            stopReason = "Reason: Unstable GPU temperatures.";
                            bg_tray.ReportProgress(1);
                            shutdown = 30;
                        }
                        else
                            shutdown--;
                    }
                    else
                    {
                        shutdown = 30;
                        unstable = false;
                    }
                }
                else if (hightemp >= shutdowntmp)
                {
                    Logger("[Unstable GPU Temperature] Miner will halt in 30 sec.");
                    inflateBalloon("[!] Unstable GPU Temperatures!", "Mining will cease automatically if temperatures\r\ndo not decrease within 30 seconds.", ToolTipIcon.Error);
                    unstable = true;
                }
                else if (!HasShown && ovheat)
                {
                    if (OHprotect.Checked)
                    {
                        Logger("[Protective Cooling Activated] High GPU temperatures.");
                        inflateBalloon("Protective Cooling Activated", "GPU reached unsafe temperatures.\r\nIncreasing fan speed.", ToolTipIcon.Warning);
                    }
                    else
                    {
                        Logger("[GPU Running Hot] High GPU Temperatures. Protective Cooling is disabled.");
                        inflateBalloon("GPU Operating at High Temperatures", "Continuing may result in shortened GPU lifespan.\r\nProtective Cooling is recommended.", ToolTipIcon.Warning);
                    }
                    HasShown = true;
                }
                else if (!ovheat)
                {
                    if (showtimer == 0)
                        HasShown = false;
                    else
                        showtimer--;
                }
                else
                    showtimer = 30;

                Thread.Sleep(1000);
            }
        }

        private void bg_tray_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MinerController(true);
        }

        #endregion


        #region input validations

        private void Validator()
        {
            if (TBstrat.Text != "" && TBpass.Text != "" && tbWorker.Text != "" && tbnickname.Text != "")
            {
                buAddMine.Enabled = true;
            }
            else
                buAddMine.Enabled = false;
        }

        private void TBstrat_Click(object sender, EventArgs e)
        {
            if (TBstrat.Text == "stratum+tcp://pool.of.choice:0000")
            {
                TBstrat.Text = "";
                TBstrat.ForeColor = Color.Black;
            }
        }

        private void TBstrat_TextChanged(object sender, EventArgs e)
        {
            Validator();
        }

        private void tbnickname_TextChanged(object sender, EventArgs e)
        {
            Validator();
        }

        private void tbWorker_TextChanged(object sender, EventArgs e)
        {
            Validator();
        }

        private void TBpass_TextChanged(object sender, EventArgs e)
        {
            Validator();
        }

        private void tbnickname_KeyPress(object sender, KeyPressEventArgs e)
        {
            string illegal = "\\/:*?\"<>|,";
            if (illegal.Contains(e.KeyChar))
                e.KeyChar = '_';
        }

        #endregion


        #region general Toolstrip

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizeConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tsMaxCon.Checked)
            {
                tsGhost.Enabled = true;
                debugbox.Top = 25;
                debugbox.Height = debugbox.Parent.Height - 92;
            }
            else
            {
                tsGhost.Enabled = false;
                debugbox.Top = 314;
                debugbox.Height = debugbox.Parent.Height - 381;
            }
        }

        private void toolOnTop_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolOnTop.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void tsGhost_CheckStateChanged(object sender, EventArgs e)
        {
            if (tsGhost.Checked)
            {
                string content = "Ghosting makes your window transparent when it's not in focus.\r\nThis may cause lag when interacting with the window.\r\n\r\nDo you want to continue?";
                DialogResult dialogResult = MessageBox.Show(content, "Enable Ghosting", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                    ghosting = true;
                else
                    ghosting = false;
            }
            else
            {
                ghosting = false;
                this.Opacity = 1;
            }
        }

        private void tsSetFan_SelectedIndexChanged(object sender, EventArgs e)
        {
            fansetting = tsSetFan.Text;
            FanSet();
            ohprotecting = false;
            Logger("[Fan Controller] Fan speeds set to " + fansetting);
            SaveSettings(false);
        }

        #endregion

        #region Logger
        private void Logger(string ev)
        {
            int yaycnt = yays;
            if (timespent > 0)
                yaycnt = yays / timespent;

            string[] entry = new string[8];
            entry[0] = DateTime.Now.ToString();
            entry[1] = ev;
            entry[2] = Math.Round(hr, 2).ToString() + "kh/s";
            entry[3] = yaycnt.ToString() + "/min.";
            entry[4] = yays.ToString();
            entry[5] = ((int)timerunning.TotalHours).ToString() + " hr. " + timerunning.Minutes.ToString() + " min.";
            entry[6] = hightemp.ToString() + "°C";
            entry[7] = fanspeed.ToString() + "%";

            logs.Add(entry);
        }

        private void viewMinerLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logs.Count() > 0)
            {
                Form f = new Logs(this);
                f.ShowDialog(this);
            }
            else
                MessageBox.Show("No entries to show.");
        }

        private void tsClearLog_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will completely clear the miner log.\r\n\r\nAre you sure?", "Clear Miner Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                logs.Clear();
                Logger("[Log Cleared] User cleared log");
            }
        }

        private void tsSaveLog_Click(object sender, EventArgs e)
        {

            saFilediag.FileName = "Miner Log " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
            saFilediag.ShowDialog();
        }

        private void saFilediag_FileOk(object sender, CancelEventArgs e)
        {
            StringBuilder logtmp = new StringBuilder();
            logtmp.AppendLine("Time,Event,Average Hashrate,Average Yays,Total Yays,Mining Time, GPU Temp., Fan Speed");
            foreach (string[] line in logs)
            {
                logtmp.AppendLine(String.Join(",", line));
            }
            try
            {
                File.WriteAllText(saFilediag.FileName, logtmp.ToString());
            }
            catch { MessageBox.Show("Unable to save to this folder. Permission denied."); }
        }

        #endregion

        #region about toolbar

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Donor(this);
            f.ShowDialog(this);
        }

        private void tsGuide_Click(object sender, EventArgs e)
        {
            Form f = new Guide();
            f.Show(this);
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            Form f = new Info();
            f.ShowDialog(this);
        }

        #endregion

        #region TrayIcon

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();

            debugbox.SelectionStart = debugbox.TextLength;
            debugbox.ScrollToCaret();
        }

        private void conExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (toolMinTray.Checked && FormWindowState.Minimized == this.WindowState)
                this.Hide();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (ghosting && tsMaxCon.Checked)
                this.Opacity = 1;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (ghosting && tsMaxCon.Checked)
                this.Opacity = 0.20;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!nocheck)
            {
                DialogResult dialogResult = MessageBox.Show("Closing CUDA Manager will halt mining and clear the miner log.\r\n\r\nDo you want to exit?", "Exit CUDA Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SendControlC(p);
                    SaveListDat();
                    ovheat = false;
                    FanController(false, 0);
                    trayIcon.Visible = false;
                    SaveSettings(true);
                }
                else
                    e.Cancel = true;
            }
        }

        private void tsAdvance_Click(object sender, EventArgs e)
        {
            Form f = new adv(this);
            f.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry Host = Dns.GetHostEntry("stratum.doge.hashfaster.com");
            

                Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

                try
                {
                    s.Connect(Host.AddressList[0], 3339);
                    MessageBox.Show(s.Connected.ToString());
                    s.Disconnect(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    // something went wrong
                }
        }

        private void bg_idler_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bg_idler.CancellationPending)
            {
                if (idlestart)
                {
                    int idletime = SysDetect.GetLastInputTime();
                    if (idletime > idletimer)
                    {
                        bg_idler.CancelAsync();
                    }
                }
            }
        }

        private void bg_idler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (buStart.Text == "Start Miner")
            {
                idlestarter = true;
                MinerController(false);
            }
        }

    }
}
