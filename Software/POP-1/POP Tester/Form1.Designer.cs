namespace POP_Tester
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.PortList = new System.Windows.Forms.ComboBox();
            this.Connect = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.EnterCommand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Incoming = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.DelayTimer = new System.Windows.Forms.Timer(this.components);
            this.DateTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CloseApp = new System.Windows.Forms.Button();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.OffPeakRate = new System.Windows.Forms.Label();
            this.PeakRate = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.BattDischrgAmp = new System.Windows.Forms.Label();
            this.BattFullChrgAmp = new System.Windows.Forms.Label();
            this.BattDischrgVolt = new System.Windows.Forms.Label();
            this.BattFullChrgVolt = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OffPeakTimeStop = new System.Windows.Forms.Label();
            this.OffPeakTimeStart = new System.Windows.Forms.Label();
            this.PeakTimeStop = new System.Windows.Forms.Label();
            this.PeakTimeStart = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.EnergyCost = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.TotalWattHr = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.LoadConnection = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InverterStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RectifierStatus = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.BatteryStatus = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.WattHr = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BatteryCurrent = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.BatteryVoltage = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Period = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.StatusBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AutoEnable = new System.Windows.Forms.CheckBox();
            this.TotalWattHr2 = new System.Windows.Forms.Label();
            this.EnergyCost2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SettingsGroupBox.SuspendLayout();
            this.StatusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerialPort
            // 
            this.SerialPort.ReadBufferSize = 6000;
            // 
            // Timer
            // 
            this.Timer.Interval = 2000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // PortList
            // 
            this.PortList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PortList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PortList.FormattingEnabled = true;
            this.PortList.Location = new System.Drawing.Point(112, 67);
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(183, 21);
            this.PortList.TabIndex = 0;
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Connect.Location = new System.Drawing.Point(20, 65);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(86, 23);
            this.Connect.TabIndex = 1;
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Send.Enabled = false;
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Send.Location = new System.Drawing.Point(20, 120);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(86, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // EnterCommand
            // 
            this.EnterCommand.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EnterCommand.Enabled = false;
            this.EnterCommand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnterCommand.FormattingEnabled = true;
            this.EnterCommand.Items.AddRange(new object[] {
            "---Read Commands---",
            "HB",
            "HB2",
            "RBATLVL",
            "RBATAMP",
            "RBATCHAR",
            "RBATDISC",
            "RBATHIAMP",
            "RBATLOAMP",
            "RWATTHR",
            "RPTSTART",
            "RPTSTOP",
            "RNPTSTART",
            "RNPTSTOP",
            "RTOTWATTHR",
            "RPEAKRATE",
            "RNPEAKRATE",
            "RTOTCOST",
            "RCLOCK",
            "---Write Commands---",
            "WBATCHAR|##.##",
            "WBATDISC|##.##",
            "WBATHIAMP|##.##",
            "WBATLOAMP|##.##",
            "WPTSTART|HH:MM AM/PM",
            "WPTSTOP|HH:MM AM/PM",
            "WNPTSTART|HH:MM AM/PM",
            "WNPTSTOP|HH:MM AM/PM",
            "WPEAKRATE|#######",
            "WNPEAKRATE|#######",
            "RST-WATTHR",
            "RST-TOTWATTHR",
            "WCLOCK|MM-DD-YY-HH-MM-SS",
            "AUTO",
            "MANUAL",
            "RESET",
            "---Manual Mode Commands---",
            "OFFRECT",
            "ONRECT",
            "BATTOCHARGER",
            "BATTOINVERTER",
            "TRANSTOUTIL",
            "TRANSTOLOCAL"});
            this.EnterCommand.Location = new System.Drawing.Point(112, 122);
            this.EnterCommand.Name = "EnterCommand";
            this.EnterCommand.Size = new System.Drawing.Size(183, 21);
            this.EnterCommand.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(109, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Command";
            // 
            // Incoming
            // 
            this.Incoming.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Incoming.Location = new System.Drawing.Point(20, 167);
            this.Incoming.Multiline = true;
            this.Incoming.Name = "Incoming";
            this.Incoming.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Incoming.Size = new System.Drawing.Size(275, 65);
            this.Incoming.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(17, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Incoming";
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Clear.Location = new System.Drawing.Point(20, 238);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(55, 23);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear Incoming";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // DelayTimer
            // 
            this.DelayTimer.Tick += new System.EventHandler(this.DelayTimer_Tick);
            // 
            // DateTime
            // 
            this.DateTime.AutoSize = true;
            this.DateTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DateTime.Location = new System.Drawing.Point(829, 9);
            this.DateTime.Name = "DateTime";
            this.DateTime.Size = new System.Drawing.Size(90, 13);
            this.DateTime.TabIndex = 28;
            this.DateTime.Text = "Date and Time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 37;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 389);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 38;
            this.dateTimePicker1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(101, 420);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 5);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(972, 24);
            this.MainMenu.TabIndex = 40;
            this.MainMenu.Text = "About";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::POP_Tester.Properties.Resources.Battery;
            this.pictureBox2.Location = new System.Drawing.Point(445, 400);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(585, 449);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 65);
            this.progressBar1.TabIndex = 42;
            this.progressBar1.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(251, 478);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Charger";
            this.label17.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::POP_Tester.Properties.Resources.Battery_Charger;
            this.pictureBox3.Location = new System.Drawing.Point(254, 389);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CloseApp
            // 
            this.CloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseApp.Location = new System.Drawing.Point(885, 433);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(75, 23);
            this.CloseApp.TabIndex = 51;
            this.CloseApp.Text = "Close";
            this.CloseApp.UseVisualStyleBackColor = true;
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.BackColor = System.Drawing.Color.Black;
            this.SettingsGroupBox.Controls.Add(this.OffPeakRate);
            this.SettingsGroupBox.Controls.Add(this.PeakRate);
            this.SettingsGroupBox.Controls.Add(this.label24);
            this.SettingsGroupBox.Controls.Add(this.label23);
            this.SettingsGroupBox.Controls.Add(this.BattDischrgAmp);
            this.SettingsGroupBox.Controls.Add(this.BattFullChrgAmp);
            this.SettingsGroupBox.Controls.Add(this.BattDischrgVolt);
            this.SettingsGroupBox.Controls.Add(this.BattFullChrgVolt);
            this.SettingsGroupBox.Controls.Add(this.label12);
            this.SettingsGroupBox.Controls.Add(this.label13);
            this.SettingsGroupBox.Controls.Add(this.label11);
            this.SettingsGroupBox.Controls.Add(this.label10);
            this.SettingsGroupBox.Controls.Add(this.OffPeakTimeStop);
            this.SettingsGroupBox.Controls.Add(this.OffPeakTimeStart);
            this.SettingsGroupBox.Controls.Add(this.PeakTimeStop);
            this.SettingsGroupBox.Controls.Add(this.PeakTimeStart);
            this.SettingsGroupBox.Controls.Add(this.label9);
            this.SettingsGroupBox.Controls.Add(this.label8);
            this.SettingsGroupBox.Controls.Add(this.label7);
            this.SettingsGroupBox.Controls.Add(this.label6);
            this.SettingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SettingsGroupBox.Location = new System.Drawing.Point(343, 67);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(282, 314);
            this.SettingsGroupBox.TabIndex = 52;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "SETTINGS";
            // 
            // OffPeakRate
            // 
            this.OffPeakRate.AutoSize = true;
            this.OffPeakRate.BackColor = System.Drawing.Color.Transparent;
            this.OffPeakRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.OffPeakRate.Location = new System.Drawing.Point(150, 220);
            this.OffPeakRate.Name = "OffPeakRate";
            this.OffPeakRate.Size = new System.Drawing.Size(79, 13);
            this.OffPeakRate.TabIndex = 43;
            this.OffPeakRate.Text = "P/KwHr       ";
            // 
            // PeakRate
            // 
            this.PeakRate.AutoSize = true;
            this.PeakRate.BackColor = System.Drawing.Color.Transparent;
            this.PeakRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PeakRate.Location = new System.Drawing.Point(149, 201);
            this.PeakRate.Name = "PeakRate";
            this.PeakRate.Size = new System.Drawing.Size(83, 13);
            this.PeakRate.TabIndex = 42;
            this.PeakRate.Text = "P/KwHr        ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label24.Location = new System.Drawing.Point(56, 220);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Off-Peak Rate:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label23.Location = new System.Drawing.Point(77, 201);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 13);
            this.label23.TabIndex = 40;
            this.label23.Text = "Peak Rate:";
            // 
            // BattDischrgAmp
            // 
            this.BattDischrgAmp.AutoSize = true;
            this.BattDischrgAmp.BackColor = System.Drawing.Color.Transparent;
            this.BattDischrgAmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BattDischrgAmp.Location = new System.Drawing.Point(150, 181);
            this.BattDischrgAmp.Name = "BattDischrgAmp";
            this.BattDischrgAmp.Size = new System.Drawing.Size(77, 13);
            this.BattDischrgAmp.TabIndex = 39;
            this.BattDischrgAmp.Text = "Amps          ";
            // 
            // BattFullChrgAmp
            // 
            this.BattFullChrgAmp.AutoSize = true;
            this.BattFullChrgAmp.BackColor = System.Drawing.Color.Transparent;
            this.BattFullChrgAmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BattFullChrgAmp.Location = new System.Drawing.Point(150, 161);
            this.BattFullChrgAmp.Name = "BattFullChrgAmp";
            this.BattFullChrgAmp.Size = new System.Drawing.Size(77, 13);
            this.BattFullChrgAmp.TabIndex = 38;
            this.BattFullChrgAmp.Text = "Amps          ";
            // 
            // BattDischrgVolt
            // 
            this.BattDischrgVolt.AutoSize = true;
            this.BattDischrgVolt.BackColor = System.Drawing.Color.Transparent;
            this.BattDischrgVolt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BattDischrgVolt.Location = new System.Drawing.Point(150, 139);
            this.BattDischrgVolt.Name = "BattDischrgVolt";
            this.BattDischrgVolt.Size = new System.Drawing.Size(75, 13);
            this.BattDischrgVolt.TabIndex = 37;
            this.BattDischrgVolt.Text = "Volts          ";
            // 
            // BattFullChrgVolt
            // 
            this.BattFullChrgVolt.AutoSize = true;
            this.BattFullChrgVolt.BackColor = System.Drawing.Color.Transparent;
            this.BattFullChrgVolt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BattFullChrgVolt.Location = new System.Drawing.Point(150, 117);
            this.BattFullChrgVolt.MaximumSize = new System.Drawing.Size(50, 20);
            this.BattFullChrgVolt.Name = "BattFullChrgVolt";
            this.BattFullChrgVolt.Size = new System.Drawing.Size(47, 20);
            this.BattFullChrgVolt.TabIndex = 36;
            this.BattFullChrgVolt.Text = "Volts                    ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(22, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Batt Dischrg Current:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(15, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Batt Full Chrg Current:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(19, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Batt Dischrg Voltage:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(12, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Batt Full Chrg Voltage:";
            // 
            // OffPeakTimeStop
            // 
            this.OffPeakTimeStop.AutoSize = true;
            this.OffPeakTimeStop.BackColor = System.Drawing.Color.Transparent;
            this.OffPeakTimeStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.OffPeakTimeStop.Location = new System.Drawing.Point(148, 93);
            this.OffPeakTimeStop.Name = "OffPeakTimeStop";
            this.OffPeakTimeStop.Size = new System.Drawing.Size(95, 13);
            this.OffPeakTimeStop.TabIndex = 31;
            this.OffPeakTimeStop.Text = "HH:MM AM/PM";
            // 
            // OffPeakTimeStart
            // 
            this.OffPeakTimeStart.AutoSize = true;
            this.OffPeakTimeStart.BackColor = System.Drawing.Color.Transparent;
            this.OffPeakTimeStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.OffPeakTimeStart.Location = new System.Drawing.Point(149, 74);
            this.OffPeakTimeStart.Name = "OffPeakTimeStart";
            this.OffPeakTimeStart.Size = new System.Drawing.Size(95, 13);
            this.OffPeakTimeStart.TabIndex = 30;
            this.OffPeakTimeStart.Text = "HH:MM AM/PM";
            // 
            // PeakTimeStop
            // 
            this.PeakTimeStop.AutoSize = true;
            this.PeakTimeStop.BackColor = System.Drawing.Color.Transparent;
            this.PeakTimeStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PeakTimeStop.Location = new System.Drawing.Point(148, 56);
            this.PeakTimeStop.Name = "PeakTimeStop";
            this.PeakTimeStop.Size = new System.Drawing.Size(95, 13);
            this.PeakTimeStop.TabIndex = 29;
            this.PeakTimeStop.Text = "HH:MM AM/PM";
            // 
            // PeakTimeStart
            // 
            this.PeakTimeStart.AutoSize = true;
            this.PeakTimeStart.BackColor = System.Drawing.Color.Transparent;
            this.PeakTimeStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PeakTimeStart.Location = new System.Drawing.Point(149, 33);
            this.PeakTimeStart.Name = "PeakTimeStart";
            this.PeakTimeStart.Size = new System.Drawing.Size(95, 13);
            this.PeakTimeStart.TabIndex = 28;
            this.PeakTimeStart.Text = "HH:MM AM/PM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(24, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Off-Peak Time Stop:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(45, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Peak Time Stop:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(24, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Off-Peak Time Start:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(44, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Peak Time Start:";
            // 
            // StatusGroupBox
            // 
            this.StatusGroupBox.BackColor = System.Drawing.Color.Black;
            this.StatusGroupBox.Controls.Add(this.EnergyCost);
            this.StatusGroupBox.Controls.Add(this.label25);
            this.StatusGroupBox.Controls.Add(this.TotalWattHr);
            this.StatusGroupBox.Controls.Add(this.label22);
            this.StatusGroupBox.Controls.Add(this.LoadConnection);
            this.StatusGroupBox.Controls.Add(this.label5);
            this.StatusGroupBox.Controls.Add(this.InverterStatus);
            this.StatusGroupBox.Controls.Add(this.label4);
            this.StatusGroupBox.Controls.Add(this.RectifierStatus);
            this.StatusGroupBox.Controls.Add(this.label21);
            this.StatusGroupBox.Controls.Add(this.Mode);
            this.StatusGroupBox.Controls.Add(this.label20);
            this.StatusGroupBox.Controls.Add(this.BatteryStatus);
            this.StatusGroupBox.Controls.Add(this.label19);
            this.StatusGroupBox.Controls.Add(this.WattHr);
            this.StatusGroupBox.Controls.Add(this.label18);
            this.StatusGroupBox.Controls.Add(this.BatteryCurrent);
            this.StatusGroupBox.Controls.Add(this.label16);
            this.StatusGroupBox.Controls.Add(this.BatteryVoltage);
            this.StatusGroupBox.Controls.Add(this.label15);
            this.StatusGroupBox.Controls.Add(this.Period);
            this.StatusGroupBox.Controls.Add(this.label14);
            this.StatusGroupBox.Controls.Add(this.StatusBits);
            this.StatusGroupBox.Controls.Add(this.label3);
            this.StatusGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StatusGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatusGroupBox.Location = new System.Drawing.Point(678, 67);
            this.StatusGroupBox.Name = "StatusGroupBox";
            this.StatusGroupBox.Size = new System.Drawing.Size(282, 314);
            this.StatusGroupBox.TabIndex = 53;
            this.StatusGroupBox.TabStop = false;
            this.StatusGroupBox.Text = "STATUS";
            // 
            // EnergyCost
            // 
            this.EnergyCost.AutoSize = true;
            this.EnergyCost.BackColor = System.Drawing.Color.Transparent;
            this.EnergyCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EnergyCost.Location = new System.Drawing.Point(127, 286);
            this.EnergyCost.Name = "EnergyCost";
            this.EnergyCost.Size = new System.Drawing.Size(43, 13);
            this.EnergyCost.TabIndex = 74;
            this.EnergyCost.Text = "##.##";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label25.Location = new System.Drawing.Point(45, 286);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 13);
            this.label25.TabIndex = 73;
            this.label25.Text = "Energy Cost: ";
            // 
            // TotalWattHr
            // 
            this.TotalWattHr.AutoSize = true;
            this.TotalWattHr.BackColor = System.Drawing.Color.Transparent;
            this.TotalWattHr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TotalWattHr.Location = new System.Drawing.Point(127, 263);
            this.TotalWattHr.Name = "TotalWattHr";
            this.TotalWattHr.Size = new System.Drawing.Size(43, 13);
            this.TotalWattHr.TabIndex = 72;
            this.TotalWattHr.Text = "##.##";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label22.Location = new System.Drawing.Point(40, 263);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 71;
            this.label22.Text = "Total WattHr:";
            // 
            // LoadConnection
            // 
            this.LoadConnection.AutoSize = true;
            this.LoadConnection.BackColor = System.Drawing.Color.Transparent;
            this.LoadConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LoadConnection.Location = new System.Drawing.Point(127, 223);
            this.LoadConnection.Name = "LoadConnection";
            this.LoadConnection.Size = new System.Drawing.Size(76, 13);
            this.LoadConnection.TabIndex = 70;
            this.LoadConnection.Text = "Utility/Local";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(17, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Load Connection: ";
            // 
            // InverterStatus
            // 
            this.InverterStatus.AutoSize = true;
            this.InverterStatus.BackColor = System.Drawing.Color.Transparent;
            this.InverterStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.InverterStatus.Location = new System.Drawing.Point(127, 199);
            this.InverterStatus.Name = "InverterStatus";
            this.InverterStatus.Size = new System.Drawing.Size(46, 13);
            this.InverterStatus.TabIndex = 68;
            this.InverterStatus.Text = "On/Off";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(29, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Inverter Status:";
            // 
            // RectifierStatus
            // 
            this.RectifierStatus.AutoSize = true;
            this.RectifierStatus.BackColor = System.Drawing.Color.Transparent;
            this.RectifierStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RectifierStatus.Location = new System.Drawing.Point(127, 177);
            this.RectifierStatus.Name = "RectifierStatus";
            this.RectifierStatus.Size = new System.Drawing.Size(46, 13);
            this.RectifierStatus.TabIndex = 66;
            this.RectifierStatus.Text = "On/Off";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label21.Location = new System.Drawing.Point(25, 177);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 13);
            this.label21.TabIndex = 65;
            this.label21.Text = "Rectifier Status:";
            // 
            // Mode
            // 
            this.Mode.AutoSize = true;
            this.Mode.BackColor = System.Drawing.Color.Transparent;
            this.Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Mode.Location = new System.Drawing.Point(127, 53);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(80, 13);
            this.Mode.TabIndex = 64;
            this.Mode.Text = "Auto/Manual";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label20.Location = new System.Drawing.Point(81, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 63;
            this.label20.Text = "Mode:";
            // 
            // BatteryStatus
            // 
            this.BatteryStatus.AutoSize = true;
            this.BatteryStatus.BackColor = System.Drawing.Color.Transparent;
            this.BatteryStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BatteryStatus.Location = new System.Drawing.Point(127, 155);
            this.BatteryStatus.Name = "BatteryStatus";
            this.BatteryStatus.Size = new System.Drawing.Size(137, 13);
            this.BatteryStatus.TabIndex = 62;
            this.BatteryStatus.Text = "Charging/Not Charging";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label19.Location = new System.Drawing.Point(32, 157);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "Battery Status:";
            // 
            // WattHr
            // 
            this.WattHr.AutoSize = true;
            this.WattHr.BackColor = System.Drawing.Color.Transparent;
            this.WattHr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WattHr.Location = new System.Drawing.Point(127, 133);
            this.WattHr.Name = "WattHr";
            this.WattHr.Size = new System.Drawing.Size(43, 13);
            this.WattHr.TabIndex = 60;
            this.WattHr.Text = "##.##";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label18.Location = new System.Drawing.Point(72, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 59;
            this.label18.Text = "WattHr:";
            // 
            // BatteryCurrent
            // 
            this.BatteryCurrent.AutoSize = true;
            this.BatteryCurrent.BackColor = System.Drawing.Color.Transparent;
            this.BatteryCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BatteryCurrent.Location = new System.Drawing.Point(127, 113);
            this.BatteryCurrent.Name = "BatteryCurrent";
            this.BatteryCurrent.Size = new System.Drawing.Size(43, 13);
            this.BatteryCurrent.TabIndex = 58;
            this.BatteryCurrent.Text = "##.##";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label16.Location = new System.Drawing.Point(27, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "Battery Current:";
            // 
            // BatteryVoltage
            // 
            this.BatteryVoltage.AutoSize = true;
            this.BatteryVoltage.BackColor = System.Drawing.Color.Transparent;
            this.BatteryVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BatteryVoltage.Location = new System.Drawing.Point(127, 94);
            this.BatteryVoltage.Name = "BatteryVoltage";
            this.BatteryVoltage.Size = new System.Drawing.Size(43, 13);
            this.BatteryVoltage.TabIndex = 56;
            this.BatteryVoltage.Text = "##.##";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label15.Location = new System.Drawing.Point(25, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Battery Voltage:";
            // 
            // Period
            // 
            this.Period.AutoSize = true;
            this.Period.BackColor = System.Drawing.Color.Transparent;
            this.Period.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Period.Location = new System.Drawing.Point(127, 73);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(92, 13);
            this.Period.TabIndex = 54;
            this.Period.Text = "Peak/Off-Peak";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label14.Location = new System.Drawing.Point(76, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Period:";
            // 
            // StatusBits
            // 
            this.StatusBits.AutoSize = true;
            this.StatusBits.BackColor = System.Drawing.Color.Transparent;
            this.StatusBits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatusBits.Location = new System.Drawing.Point(127, 33);
            this.StatusBits.Name = "StatusBits";
            this.StatusBits.Size = new System.Drawing.Size(67, 13);
            this.StatusBits.TabIndex = 52;
            this.StatusBits.Text = "BbBbBbBb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(51, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Status Bits:";
            // 
            // AutoEnable
            // 
            this.AutoEnable.AutoSize = true;
            this.AutoEnable.BackColor = System.Drawing.Color.Transparent;
            this.AutoEnable.Checked = true;
            this.AutoEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoEnable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AutoEnable.Location = new System.Drawing.Point(20, 340);
            this.AutoEnable.Name = "AutoEnable";
            this.AutoEnable.Size = new System.Drawing.Size(144, 17);
            this.AutoEnable.TabIndex = 54;
            this.AutoEnable.Text = "Auto Polling Enabled";
            this.AutoEnable.UseVisualStyleBackColor = false;
            // 
            // TotalWattHr2
            // 
            this.TotalWattHr2.AutoSize = true;
            this.TotalWattHr2.BackColor = System.Drawing.Color.Transparent;
            this.TotalWattHr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalWattHr2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TotalWattHr2.Location = new System.Drawing.Point(675, 36);
            this.TotalWattHr2.Name = "TotalWattHr2";
            this.TotalWattHr2.Size = new System.Drawing.Size(132, 25);
            this.TotalWattHr2.TabIndex = 55;
            this.TotalWattHr2.Text = "Total WattHr";
            // 
            // EnergyCost2
            // 
            this.EnergyCost2.AutoSize = true;
            this.EnergyCost2.BackColor = System.Drawing.Color.Transparent;
            this.EnergyCost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnergyCost2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EnergyCost2.Location = new System.Drawing.Point(828, 36);
            this.EnergyCost2.Name = "EnergyCost2";
            this.EnergyCost2.Size = new System.Drawing.Size(130, 25);
            this.EnergyCost2.TabIndex = 56;
            this.EnergyCost2.Text = "Energy Cost";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(972, 600);
            this.Controls.Add(this.EnergyCost2);
            this.Controls.Add(this.TotalWattHr2);
            this.Controls.Add(this.AutoEnable);
            this.Controls.Add(this.StatusGroupBox);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DateTime);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Incoming);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterCommand);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.PortList);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Peak-Off-Peak System (Beta Version)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.StatusGroupBox.ResumeLayout(false);
            this.StatusGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ComboBox PortList;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ComboBox EnterCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Incoming;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Timer DelayTimer;
        private System.Windows.Forms.Label DateTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button CloseApp;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Label BattDischrgAmp;
        private System.Windows.Forms.Label BattFullChrgAmp;
        private System.Windows.Forms.Label BattDischrgVolt;
        private System.Windows.Forms.Label BattFullChrgVolt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label OffPeakTimeStop;
        private System.Windows.Forms.Label OffPeakTimeStart;
        private System.Windows.Forms.Label PeakTimeStop;
        private System.Windows.Forms.Label PeakTimeStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox StatusGroupBox;
        private System.Windows.Forms.Label RectifierStatus;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label BatteryStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label WattHr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label BatteryCurrent;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label BatteryVoltage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label Period;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label StatusBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label InverterStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LoadConnection;
        private System.Windows.Forms.CheckBox AutoEnable;
        private System.Windows.Forms.Label TotalWattHr;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label TotalWattHr2;
        private System.Windows.Forms.Label OffPeakRate;
        private System.Windows.Forms.Label PeakRate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label EnergyCost;
        private System.Windows.Forms.Label EnergyCost2;
    }
}

