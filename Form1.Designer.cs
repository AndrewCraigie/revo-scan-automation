namespace RevopointScanAutomation
{
    partial class MainForm
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
            windowListComboBox = new ComboBox();
            label1 = new Label();
            refreshWindowListButton = new Button();
            label2 = new Label();
            RevoScanApplicationPath = new TextBox();
            label3 = new Label();
            PauseTime = new NumericUpDown();
            browseScanningApplication = new Button();
            hwndLabel = new Label();
            connectToRevoScanWindowButton = new Button();
            label4 = new Label();
            StartButtonXLabel = new Label();
            StartButtonX = new NumericUpDown();
            label5 = new Label();
            StartButtonY = new NumericUpDown();
            OpenRevoScanButton = new Button();
            RevoScanWindowCountLabel = new Label();
            groupBox1 = new GroupBox();
            RevoScanWindowHeight = new NumericUpDown();
            label7 = new Label();
            RevoScanWindowWidth = new NumericUpDown();
            label6 = new Label();
            StartButton = new Button();
            label8 = new Label();
            ScanDuration = new NumericUpDown();
            UseScanDuration = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)PauseTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartButtonX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartButtonY).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RevoScanWindowHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RevoScanWindowWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScanDuration).BeginInit();
            SuspendLayout();
            // 
            // windowListComboBox
            // 
            windowListComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            windowListComboBox.FormattingEnabled = true;
            windowListComboBox.Location = new Point(107, 54);
            windowListComboBox.Name = "windowListComboBox";
            windowListComboBox.Size = new Size(299, 28);
            windowListComboBox.TabIndex = 0;
            windowListComboBox.SelectedIndexChanged += windowListComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 58);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 1;
            label1.Text = "Window List";
            // 
            // refreshWindowListButton
            // 
            refreshWindowListButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshWindowListButton.Location = new Point(413, 54);
            refreshWindowListButton.Name = "refreshWindowListButton";
            refreshWindowListButton.Size = new Size(94, 29);
            refreshWindowListButton.TabIndex = 2;
            refreshWindowListButton.Text = "Refresh";
            refreshWindowListButton.UseVisualStyleBackColor = true;
            refreshWindowListButton.Click += refreshWindowListButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(211, 20);
            label2.TabIndex = 3;
            label2.Text = "Default Revo Scan Application";
            // 
            // RevoScanApplicationPath
            // 
            RevoScanApplicationPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RevoScanApplicationPath.Location = new Point(6, 46);
            RevoScanApplicationPath.Name = "RevoScanApplicationPath";
            RevoScanApplicationPath.Size = new Size(383, 27);
            RevoScanApplicationPath.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 340);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 5;
            label3.Text = "Delay Time Seconds";
            // 
            // PauseTime
            // 
            PauseTime.Location = new Point(166, 338);
            PauseTime.Name = "PauseTime";
            PauseTime.Size = new Size(89, 27);
            PauseTime.TabIndex = 6;
            // 
            // browseScanningApplication
            // 
            browseScanningApplication.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseScanningApplication.Location = new Point(395, 45);
            browseScanningApplication.Name = "browseScanningApplication";
            browseScanningApplication.Size = new Size(94, 29);
            browseScanningApplication.TabIndex = 7;
            browseScanningApplication.Text = "Browse";
            browseScanningApplication.UseVisualStyleBackColor = true;
            browseScanningApplication.Click += browseScanningApplication_Click;
            // 
            // hwndLabel
            // 
            hwndLabel.AutoSize = true;
            hwndLabel.Location = new Point(246, 128);
            hwndLabel.Name = "hwndLabel";
            hwndLabel.Size = new Size(197, 20);
            hwndLabel.TabIndex = 8;
            hwndLabel.Text = "Selected Revo Scan Window";
            // 
            // connectToRevoScanWindowButton
            // 
            connectToRevoScanWindowButton.Location = new Point(11, 124);
            connectToRevoScanWindowButton.Name = "connectToRevoScanWindowButton";
            connectToRevoScanWindowButton.Size = new Size(229, 29);
            connectToRevoScanWindowButton.TabIndex = 9;
            connectToRevoScanWindowButton.Text = "Connect to Revo Scan Window";
            connectToRevoScanWindowButton.UseVisualStyleBackColor = true;
            connectToRevoScanWindowButton.Click += connectToRevoScanWindowButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 96);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 10;
            label4.Text = "hwnd of Revo Scan window";
            // 
            // StartButtonXLabel
            // 
            StartButtonXLabel.AutoSize = true;
            StartButtonXLabel.Location = new Point(6, 124);
            StartButtonXLabel.Name = "StartButtonXLabel";
            StartButtonXLabel.Size = new Size(101, 20);
            StartButtonXLabel.TabIndex = 11;
            StartButtonXLabel.Text = "Start Button X";
            // 
            // StartButtonX
            // 
            StartButtonX.Location = new Point(153, 122);
            StartButtonX.Margin = new Padding(3, 4, 3, 4);
            StartButtonX.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            StartButtonX.Name = "StartButtonX";
            StartButtonX.Size = new Size(89, 27);
            StartButtonX.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(248, 124);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 13;
            label5.Text = "Start Button Y";
            // 
            // StartButtonY
            // 
            StartButtonY.Location = new Point(367, 122);
            StartButtonY.Margin = new Padding(3, 4, 3, 4);
            StartButtonY.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            StartButtonY.Name = "StartButtonY";
            StartButtonY.Size = new Size(76, 27);
            StartButtonY.TabIndex = 14;
            // 
            // OpenRevoScanButton
            // 
            OpenRevoScanButton.Location = new Point(11, 12);
            OpenRevoScanButton.Name = "OpenRevoScanButton";
            OpenRevoScanButton.Size = new Size(142, 29);
            OpenRevoScanButton.TabIndex = 15;
            OpenRevoScanButton.Text = "Open Revo Scan";
            OpenRevoScanButton.UseVisualStyleBackColor = true;
            OpenRevoScanButton.Click += OpenRevoScanButton_Click;
            // 
            // RevoScanWindowCountLabel
            // 
            RevoScanWindowCountLabel.AutoSize = true;
            RevoScanWindowCountLabel.Location = new Point(160, 16);
            RevoScanWindowCountLabel.Name = "RevoScanWindowCountLabel";
            RevoScanWindowCountLabel.Size = new Size(17, 20);
            RevoScanWindowCountLabel.TabIndex = 16;
            RevoScanWindowCountLabel.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(RevoScanWindowHeight);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(RevoScanWindowWidth);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(RevoScanApplicationPath);
            groupBox1.Controls.Add(StartButtonY);
            groupBox1.Controls.Add(browseScanningApplication);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(StartButtonX);
            groupBox1.Controls.Add(StartButtonXLabel);
            groupBox1.Location = new Point(12, 170);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(495, 160);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // RevoScanWindowHeight
            // 
            RevoScanWindowHeight.Location = new Point(368, 86);
            RevoScanWindowHeight.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            RevoScanWindowHeight.Name = "RevoScanWindowHeight";
            RevoScanWindowHeight.Size = new Size(76, 27);
            RevoScanWindowHeight.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(249, 88);
            label7.Name = "label7";
            label7.Size = new Size(113, 20);
            label7.TabIndex = 17;
            label7.Text = "Window Height";
            // 
            // RevoScanWindowWidth
            // 
            RevoScanWindowWidth.Location = new Point(154, 86);
            RevoScanWindowWidth.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            RevoScanWindowWidth.Name = "RevoScanWindowWidth";
            RevoScanWindowWidth.Size = new Size(89, 27);
            RevoScanWindowWidth.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 88);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 15;
            label6.Text = "Window Width";
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StartButton.BackColor = Color.FromArgb(255, 128, 128);
            StartButton.Location = new Point(261, 336);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(246, 114);
            StartButton.TabIndex = 18;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 379);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 19;
            label8.Text = "Scan Duration";
            // 
            // ScanDuration
            // 
            ScanDuration.Location = new Point(166, 377);
            ScanDuration.Name = "ScanDuration";
            ScanDuration.Size = new Size(89, 27);
            ScanDuration.TabIndex = 20;
            // 
            // UseScanDuration
            // 
            UseScanDuration.AutoSize = true;
            UseScanDuration.Location = new Point(18, 413);
            UseScanDuration.Name = "UseScanDuration";
            UseScanDuration.Size = new Size(152, 24);
            UseScanDuration.TabIndex = 22;
            UseScanDuration.Text = "Use Scan Duration";
            UseScanDuration.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 461);
            Controls.Add(UseScanDuration);
            Controls.Add(ScanDuration);
            Controls.Add(label8);
            Controls.Add(StartButton);
            Controls.Add(RevoScanWindowCountLabel);
            Controls.Add(OpenRevoScanButton);
            Controls.Add(label4);
            Controls.Add(connectToRevoScanWindowButton);
            Controls.Add(hwndLabel);
            Controls.Add(refreshWindowListButton);
            Controls.Add(label1);
            Controls.Add(windowListComboBox);
            Controls.Add(groupBox1);
            Controls.Add(PauseTime);
            Controls.Add(label3);
            Name = "MainForm";
            Text = "Revopoint Scan Automator";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PauseTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartButtonX).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartButtonY).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RevoScanWindowHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)RevoScanWindowWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScanDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox windowListComboBox;
        private Label label1;
        private Button refreshWindowListButton;
        private Label label2;
        private TextBox RevoScanApplicationPath;
        private Label label3;
        private NumericUpDown PauseTime;
        private Button browseScanningApplication;
        private Label hwndLabel;
        private Button connectToRevoScanWindowButton;
        private Label label4;
        private Label StartButtonXLabel;
        private NumericUpDown StartButtonX;
        private Label label5;
        private NumericUpDown StartButtonY;
        private Button OpenRevoScanButton;
        private Label RevoScanWindowCountLabel;
        private GroupBox groupBox1;
        private NumericUpDown RevoScanWindowHeight;
        private Label label7;
        private NumericUpDown RevoScanWindowWidth;
        private Label label6;
        private Button StartButton;
        private Label label8;
        private NumericUpDown ScanDuration;
        private CheckBox UseScanDuration;
    }
}