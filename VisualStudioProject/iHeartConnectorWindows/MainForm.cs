using iHeartConnectorWindows.Data;
using iHeartConnectorWindows.Exporters;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace OximeterServer
{
    public partial class MainForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        #region Interop
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region Keyboard Hook
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private LowLevelKeyboardProc proc;
        private IntPtr hookID = IntPtr.Zero;

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if ((Keys)vkCode == Keys.F12)
                {
                    if (recording)
                        stop();
                    else if (exporter == null)
                        startRecording();
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        private readonly BLECommunicator communicator;

        private readonly OximeterControls.OximeterPanel oximeterPanel;

        private OximeterRawData? currentData;
        private readonly DataStorage<OximeterStreamData> recordedData = new (10000000);
        private OximeterStreamData? prevStreamData = null;
        private bool recording;
        private string status = "";
        private float progress = 0.0f;
        private string macAddress = "–";

        private Exporter? exporter;

        private TcpServer server = new TcpServer(IPAddress.Any, 6000);
        private readonly char serverSeparator = ',';
        private readonly char csvSeparator = ',';

        private string lastExportFileName = "";
        private string lastExportFileNameCandidate = "";

        public MainForm()
        {
            InitializeComponent();

            oximeterPanel = new OximeterControls.OximeterPanel();
            oxiListPanel.Controls.Add(oximeterPanel);

            proc = HookCallback;
            hookID = SetHook(proc);

            server.Start();

            redrawTimer.Start();

            communicator = new();
            communicator.NewDataReceived += Communicator_NewDataReceived;
            communicator.NewDeviceConnected += Communicator_NewDeviceConnected;
            communicator.Start();
        }

        private void Communicator_NewDeviceConnected(object? sender, BLECommunicator.NewDeviceConncectedEventArgs e)
        {
            macAddress = e.MacAddress;
        }

        private void Communicator_NewDataReceived(object? sender, BLECommunicator.NewDataReceivedEventArgs e)
        {
            OximeterRawData? rd = e.Data;

            if (rd != null)
            {
                OximeterStreamData[]? sd;
                if (prevStreamData == null)
                    sd = DataUtils.OximeterStreamDataFromRaw(rd);
                else
                    sd = DataUtils.OximeterStreamDataFromRaw(prevStreamData, rd);

                prevStreamData = sd[1];

                if (recording)
                {
                    if (sd != null)

                        recordedData.AddRange(sd);
                    status = $"{recordedData.Count} points";
                }

                currentData = rd;

                server.Send(sd[0].GetBytes(serverSeparator));
                server.Send(sd[1].GetBytes(serverSeparator));
            }


        }

        private delegate void UpdateOximeterPanelDelegate();

        private void UpdateUi()
        {
            switch (oximeterPanel.Mode)
            {
                case OximeterControls.OximeterPanel.ModeEnum.Pulse:
                    if (currentData != null)
                    {
                        oximeterPanel.SpO2 = currentData.SpO2;
                        oximeterPanel.PulseRate = currentData.PulseRate;
                        oximeterPanel.MacAddress = macAddress;
                        oximeterPanel.AddPulseValue(currentData.IR1);
                    }
                    break;
                case OximeterControls.OximeterPanel.ModeEnum.Progress:
                    oximeterPanel.Progress = progress;
                    break;
            }

            statusLabel.Text = status;
        }

        private void redrawTimer_Tick(object sender, EventArgs e)
        {
            UpdateUi();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            communicator.Stop();
            server.Stop();
            UnhookWindowsHookEx(hookID);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mimimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportMenu.Show(new Point(Left + exportButton.Left + exportButton.Width, Top + exportButton.Top));
        }

        private void statusLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            startRecording();
        }

        private void startRecording()
        {
            recordedData.Clear();

            recording = true;
            recordButton.Enabled = false;
            stopButton.Enabled = true;
            exportButton.Enabled = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void stop()
        {
            if (exporter != null)
            {
                exporter.Stop();
                exporter = null;
            }

            recording = false;
            recordButton.Enabled = true;
            stopButton.Enabled = false;
            exportButton.Enabled = recordedData.Length > 0;
        }

        private void exportToExcelMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Save to Excel";
            sd.CheckPathExists = true;
            sd.DefaultExt = "xlsx";
            sd.Filter = "Excel files (*.xlsx)|*.xlsx";
            sd.FilterIndex = 0;
            sd.RestoreDirectory = true;
            sd.FileName = generateFileName() + ".xlsx";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sd.FileName;
                exportStartButtonsEnable();

                communicator.NewDataReceived -= Communicator_NewDataReceived;
                oximeterPanel.Mode = OximeterControls.OximeterPanel.ModeEnum.Progress;

                lastExportFileNameCandidate = fileName;

                exporter = new ExcelExporter(fileName, recordedData);
                exporter.OnProgressChanged += Exporter_OnProgressChanged;
                exporter.OnCompleted += Exporter_OnCompleted;
                exporter.Start();
            }
            sd.Dispose();
        }

        private void Exporter_OnCompleted(object? sender, EventArgs e)
        {
            lastExportFileName = lastExportFileNameCandidate;

            BeginInvoke(delegate
            {
                lastExportMenuItem.Text = lastExportFileName;
                lastExportMenuItem.Enabled = true;

                recordButton.Enabled = true;
                stopButton.Enabled = false;
                exportButton.Enabled = true;
            });

            exporter = null;
            oximeterPanel.Mode = OximeterControls.OximeterPanel.ModeEnum.Pulse;
            communicator.NewDataReceived += Communicator_NewDataReceived;
        }

        private void Exporter_OnProgressChanged(object? sender, Exporter.ExporterEventArgs e)
        {
            if (e.Status != null)
            {
                progress = e.Progress;
                status = e.Status;
            }
        }

        private void exportToCSVMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Save to CSV";
            sd.CheckPathExists = true;
            sd.DefaultExt = "csv";
            sd.Filter = "CSV files (*.csv)|*.csv";
            sd.FilterIndex = 0;
            sd.RestoreDirectory = true;
            sd.FileName = generateFileName() + ".csv";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sd.FileName;
                exportStartButtonsEnable();

                communicator.NewDataReceived -= Communicator_NewDataReceived;
                oximeterPanel.Mode = OximeterControls.OximeterPanel.ModeEnum.Progress;

                lastExportFileNameCandidate = fileName;

                exporter = new CsvExporter(fileName, recordedData, csvSeparator);
                exporter.OnProgressChanged += Exporter_OnProgressChanged;
                exporter.OnCompleted += Exporter_OnCompleted;
                exporter.Start();
            }
            sd.Dispose();
        }

        private string generateFileName()
        {
            return DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        }

        private void exportStartButtonsEnable()
        {
            recordButton.Enabled = false;
            stopButton.Enabled = true;
            exportButton.Enabled = false;
        }

        private void lastExportMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo(lastExportFileName)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            catch { }
        }
    }
}