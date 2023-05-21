using System.IO;
using System.Media;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using static RevopointScanAutomation.MainForm;
using System.IO.Ports;

namespace RevopointScanAutomation
{
    public partial class MainForm : Form
    {

        private GRBLPortScanner grblPortScanner;
        private GRBLController grblController;

        private bool grblPortIsOpen;

        private WindowManager windowListRetriever;
        private int revoScanWindowCount;

        private int countdownDuration;
        private int remainingSeconds;
        private SoundPlayer beepSoundPlayer;
        private SoundPlayer completeSoundPlayer;
        private System.Threading.Timer countdownTimer;
        private System.Threading.Timer durationTimer;

        IntPtr selectedHwnd;

        [System.Flags]
        internal enum MouseEventFlags : uint
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            RightDown = 0x00000008,
            RightUp = 0x00000010,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            XDown = 0x00000080,
            XUp = 0x00000100,
            Wheel = 0x00000800,
            VirtualDesk = 0x00001000,
            Absolute = 0x00008000
        }

        public MainForm()
        {
            InitializeComponent();

            grblPortIsOpen = false;

            grblPortScanner = new GRBLPortScanner();
            grblPortScanner.PortsChecked += GrblController_PortsChecked;
            grblPortScanner.ErrorOccurred += GrblController_ErrorOccurred;
            // _grblController.GetAvailablePorts();

            beepSoundPlayer = new SoundPlayer("beep.wav");
            completeSoundPlayer = new SoundPlayer("complete.wav");

            LoadSettings();
            revoScanWindowCount = 0;
            windowListRetriever = new WindowManager();
        }

        private void LoadSettings()
        {
            RevoScanApplicationPath.Text = SettingsManager.GetTextValue("RevoScanApplicationPath");
            PauseTime.Value = SettingsManager.GetIntValue("PauseTime");
            RevoScanWindowWidth.Value = SettingsManager.GetIntValue("RevoScanWindowWidth");
            RevoScanWindowHeight.Value = SettingsManager.GetIntValue("RevoScanWindowHeight");
            StartButtonX.Value = SettingsManager.GetIntValue("StartButtonX");
            StartButtonY.Value = SettingsManager.GetIntValue("StartButtonY");
            ScanDuration.Value = SettingsManager.GetIntValue("ScanDuration");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Populate the comboBoxBaudRate with data from BaudRateData class
            comboBoxBaudRate.DataSource = BaudRateData.GetBaudRates();
            comboBoxBaudRate.DisplayMember = "DisplayText";
            comboBoxBaudRate.ValueMember = "Value";
            comboBoxBaudRate.SelectedValue = 115200;

            grblPortScanner.GetAvailableGRBLPorts();

            validateBtnConnect();

            revoScanWindowCount = windowListRetriever.PopulateWindowList(windowListComboBox);

            OpenRevoScanButton.Enabled = true;
            RevoScanWindowCountLabel.Text = revoScanWindowCount.ToString();

            if (revoScanWindowCount > 0)
            {
                windowListComboBox.SelectedIndex = 0;
            }
        }

        private void validateBtnConnect()
        {
            Object selectedPort = comboBoxCOMPorts.SelectedItem;
            Object selectedBaudRate = comboBoxBaudRate.SelectedItem;

            if (selectedPort != null && selectedBaudRate != null)
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }

        private void GrblController_PortsChecked(List<string> arduinoPorts)
        {
            // Invoke this on UI thread
            this.Invoke((MethodInvoker)delegate
            {
                comboBoxCOMPorts.Items.Clear();
                foreach (var port in arduinoPorts)
                {
                    comboBoxCOMPorts.Items.Add(port);
                }
            });
        }

        private void GrblController_ErrorOccurred(Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RefreshWindowList()
        {
            windowListRetriever.PopulateWindowList(windowListComboBox);
        }

        private void refreshWindowListButton_Click(object sender, EventArgs e)
        {
            RefreshWindowList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string revoScanApplicationPath = RevoScanApplicationPath.Text;
            SettingsManager.SaveTextValue("RevoScanApplicationPath", revoScanApplicationPath);

            int pauseTime = (int)PauseTime.Value;
            SettingsManager.SaveIntValue("PauseTime", pauseTime);

            int revoScanWindowWidth = (int)RevoScanWindowWidth.Value;
            SettingsManager.SaveIntValue("RevoScanWindowWidth", revoScanWindowWidth);

            int revoScanWindowHeight = (int)RevoScanWindowHeight.Value;
            SettingsManager.SaveIntValue("RevoScanWindowHeight", revoScanWindowHeight);

            int startButtonXValue = (int)StartButtonX.Value;
            SettingsManager.SaveIntValue("StartButtonX", startButtonXValue);

            int startButtonYValue = (int)StartButtonY.Value;
            SettingsManager.SaveIntValue("StartButtonY", startButtonYValue);

            int scanDuration = (int)ScanDuration.Value;
            SettingsManager.SaveIntValue("ScanDuration", scanDuration);

            if (grblController.GetSerialPortIsOpen())
            {
                grblController.ClosePort();
            }

        }

        private void browseScanningApplication_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
            openFileDialog.Title = "Select an Application";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedAppPath = openFileDialog.FileName;
                RevoScanApplicationPath.Text = selectedAppPath;
            }
        }

        private void connectToRevoScanWindowButton_Click(object sender, EventArgs e)
        {
            string selectedWindow = windowListComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedWindow))
            {
                MessageBox.Show("Please select a Revo Scan window.");
                return;
            }

            selectedHwnd = WindowFinder.FindWindowByCaption(selectedWindow);
            if (selectedHwnd == IntPtr.Zero)
            {
                MessageBox.Show("Failed to find the selected window.");
                return;
            }

            hwndLabel.Text = selectedHwnd.ToString();
            WindowManager.BringWindowToFront(selectedHwnd);
            WindowManager.ResizeWindow(selectedHwnd, 1600, 900);
            WindowManager.MoveWindow(selectedHwnd, 0, 0);
        }

        private void OpenRevoScanButton_Click(object sender, EventArgs e)
        {
            // string appPath = @"C:\Path\to\your\application.exe"; // Replace with the actual path to your application
            string appPath = RevoScanApplicationPath.Text;

            try
            {
                Process.Start(appPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while launching the application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void windowListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenRevoScanButton.Enabled = (windowListComboBox.Items.Count == 0);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            countdownDuration = (int)PauseTime.Value;
            remainingSeconds = countdownDuration;

            countdownTimer = new System.Threading.Timer(CountdownTimerCallback, null, 0, 1000); // 1 second
        }
        private void CountdownTimerCallback(object state)
        {
            remainingSeconds--;

            if (remainingSeconds > 0)
            {
                beepSoundPlayer.Play();
            }
            else
            {
                countdownTimer.Dispose();
                completeSoundPlayer.Play();

                MoveMouseAndClick();
            }
        }

        private void MoveMouseAndClick()
        {
            int mouseXPosition = (int)StartButtonX.Value;
            int mouseYPosition = (int)StartButtonY.Value;

            NativeImports.SetCursorPos(mouseXPosition, mouseYPosition);

            var mouseEventFlags = MouseEventFlags.LeftDown | MouseEventFlags.LeftUp;
            NativeImports.mouse_event((int)mouseEventFlags, 0, 0, 0, 0);

            if (UseScanDuration.Checked)
            {
                PauseScanWithClickAfterDuration();
            }
        }

        private void PauseScanWithClickAfterDuration()
        {
            WindowManager.BringWindowToFront(selectedHwnd);

            int scanDuration = (int)ScanDuration.Value;

            Thread.Sleep(scanDuration * 1000);

            var mouseEventFlags = MouseEventFlags.LeftDown | MouseEventFlags.LeftUp;
            NativeImports.mouse_event((int)mouseEventFlags, 0, 0, 0, 0);

            completeSoundPlayer.Play();
            Thread.Sleep(500);
            completeSoundPlayer.Play();
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            grblPortScanner.GetAvailableGRBLPorts();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (grblPortIsOpen)
            {
                // Call close method on GRBLController
                grblPortIsOpen = grblController.ClosePort();
                btnConnect.Text = "Connect";
            }
            else
            {
                // Get the selected COM port and baud rate from the combo boxes
                string selectedPort = comboBoxCOMPorts.SelectedItem.ToString();
                int selectedBaudRate = (int)comboBoxBaudRate.SelectedValue;

                // Create a new instance of GRBLController and assign it to grblController
                grblController = new GRBLController(selectedPort, selectedBaudRate);
                grblController.DataReceived += GRBLController_DataReceived;

                // Call the OpenPort method with the selected port and baud rate
                grblPortIsOpen = grblController.OpenPort();
                btnConnect.Text = "Disconnect";

            }

            btnConnect.Enabled = grblPortIsOpen;



            // Retrieve the SerialPort instance from the GRBLController class
            // SerialPort serialPort = grblController.GetSerialPort();
        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateBtnConnect();
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            string grblCommand = textBoxGRBLCommand.Text;
            grblController.SendCommand(grblCommand);


        }

        private void GRBLController_DataReceived(object sender, string response)
        {
            // Log the response (you can modify this to suit your needs)
            Invoke((MethodInvoker)delegate
            {
                textBoxLog.AppendText(response);   
            });
        }
    }

}
