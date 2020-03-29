using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP_Tester
{
    public partial class MainForm : Form
    {
        String replyString;
        int DelayInMillis = 0;
        int RequestCounter = 0;
        String SystemMode = "Auto";
        String SendString;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            getPortList();
            Connect.Text = "Connect";
        }

        private void getPortList()
        {
            string[] portListing = System.IO.Ports.SerialPort.GetPortNames();
            PortList.Items.Clear();

            foreach (string portName in portListing)
            {
                PortList.Items.Add(portName);
            }
            PortList.SelectedIndex = 0;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
                Connect.Text = "Connect";
                Timer.Enabled = false;
                Send.Enabled = false;
                EnterCommand.Enabled = false;
            }
            else
            {
                SerialPort.PortName = PortList.Text;
                SerialPort.Open();
                Connect.Text = "Disconnect";
                getSettings();
                Timer.Enabled = true;
                Send.Enabled = true;
                EnterCommand.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            SerialPort.ReadTimeout = 100;
            try
            {
                replyString = SerialPort.ReadLine();
                Incoming.Text = replyString;
                switch (parseString(replyString, 1))
                {
                    case "ALL":
                        String AllStatus = parseString(replyString, 2);
                        StatusBits.Text = AllStatus;
                        switch (AllStatus.Substring(5, 2))
                        {
                            case "00":
                                Period.Text = "Off-Peak";
                                break;
                            case "10":
                                Period.Text = "Peak";
                                break;
                            default:
                                Period.Text = "Unknown";
                                break;
                        }
                        if (AllStatus.Substring(1, 1) == "0")
                        {
                            BatteryStatus.Text = "Discharging";
                        }
                        else if (AllStatus.Substring(1, 1) == "1" && AllStatus.Substring(2, 1) == "1")
                        {
                            BatteryStatus.Text = "Charging";
                        }
                        else if (AllStatus.Substring(1, 1) == "1" && AllStatus.Substring(2, 1) == "0")
                        {
                            BatteryStatus.Text = "Standby";
                        }
                        if (AllStatus.Substring(7, 1) == "0")
                        {
                            Mode.Text = "Automated";
                            SystemMode = "Auto";
                        }
                        else
                        {
                            Mode.Text = "Manual";
                            SystemMode = "Manual";
                        }
                        if (AllStatus.Substring(2, 1) == "1")
                        {
                            RectifierStatus.Text = "On";
                        }
                        else
                        {
                            RectifierStatus.Text = "Off";
                        }
                        if (AllStatus.Substring(1, 1) == "0")
                        {
                            InverterStatus.Text = "On";
                        }
                        else
                        {
                            InverterStatus.Text = "Off";
                        }
                        if (AllStatus.Substring(0, 1) == "0")
                        {
                            LoadConnection.Text = "Utility";
                        }
                        else
                        {
                            LoadConnection.Text = "Local (Battery)";
                        }
                        BatteryVoltage.Text = parseString(replyString, 3) + " V";
                        BatteryCurrent.Text = parseString(replyString, 4) + " A";
                        WattHr.Text = parseString(replyString, 5) + " WHr";
                        TotalWattHr.Text = parseString(replyString, 6) + " WHr";
                        TotalWattHr2.Text = parseString(replyString, 6) + " WHr";
                        EnergyCost.Text = "P " + parseString(replyString, 7);
                        EnergyCost2.Text = "P " + parseString(replyString, 7);
                        DateTime.Text = parseString(replyString, 8);
                        break;
                    case "PTSTART":
                        PeakTimeStart.Text = parseString(replyString, 2);
                        break;
                    case "PTSTOP":
                        PeakTimeStop.Text = parseString(replyString, 2);
                        break;
                    case "NPTSTART":
                        OffPeakTimeStart.Text = parseString(replyString, 2);
                        break;
                    case "NPTSTOP":
                        OffPeakTimeStop.Text = parseString(replyString, 2);
                        break;
                    case "BATCHAR":
                        BattFullChrgVolt.Text = parseString(replyString, 2);
                        break;
                    case "BATDISC":
                        BattDischrgVolt.Text = parseString(replyString, 2);
                        break;
                    case "BATHIAMP":
                        BattFullChrgAmp.Text = parseString(replyString, 2);
                        break;
                    case "BATLOAMP":
                        BattDischrgAmp.Text = parseString(replyString, 2);
                        break;
                    case "BATLVL":
                        BatteryVoltage.Text = parseString(replyString, 2);
                        break;
                    case "BATAMP":
                        BatteryCurrent.Text = parseString(replyString, 2);
                        break;
                    case "WATTHR":
                        WattHr.Text = parseString(replyString, 2);
                        break;
                    case "TOTWATTHR":
                        TotalWattHr.Text = parseString(replyString, 2);
                        TotalWattHr2.Text = parseString(replyString, 2);
                        break;
                    case "CLOCK":
                        DateTime.Text = parseString(replyString, 2);
                        break;
                    case "STATUS":
                        String Status = parseString(replyString, 2);
                        StatusBits.Text = Status;
                        switch (Status.Substring(5, 2))
                        {
                            case "00":
                                Period.Text = "Off-Peak";
                                break;
                            case "10":
                                Period.Text = "Peak";
                                break;
                            default:
                                Period.Text = "Unknown";
                                break;
                        }
                        if (Status.Substring(1,1) == "0")
                        {
                            BatteryStatus.Text = "Discharging";
                        }
                        else if (Status.Substring(1,1) == "1" && Status.Substring(2,1) == "1")
                        {
                            BatteryStatus.Text = "Charging";
                        }
                        else if (Status.Substring(1,1) == "1" && Status.Substring(2,1) == "0")
                        {
                            BatteryStatus.Text = "Standby";
                        }
                        if (Status.Substring(7,1) == "0")
                        {
                            Mode.Text = "Automated";
                            SystemMode = "Auto";
                        }
                        else
                        {
                            Mode.Text = "Manual";
                            SystemMode = "Manual";
                        }
                        if (Status.Substring(2,1) == "1")
                        {
                            RectifierStatus.Text = "On";
                        }
                        else
                        {
                            RectifierStatus.Text = "Off";
                        }
                        if (Status.Substring(1,1) == "0")
                        {
                            InverterStatus.Text = "On";
                        }
                        else
                        {
                            InverterStatus.Text = "Off";
                        }
                        if (Status.Substring(0,1) == "0")
                        {
                            LoadConnection.Text = "Utility";
                        }
                        else
                        {
                            LoadConnection.Text = "Local (Battery)";
                        }
                        break;
                    case "SETTINGS":
                        PeakTimeStart.Text = parseString(replyString, 2);
                        PeakTimeStop.Text = parseString(replyString, 3);
                        OffPeakTimeStart.Text = parseString(replyString, 4);
                        OffPeakTimeStop.Text = parseString(replyString, 5);
                        BattFullChrgVolt.Text = parseString(replyString, 6) + " V";
                        BattDischrgVolt.Text = parseString(replyString, 7) + " V";
                        BattFullChrgAmp.Text = parseString(replyString, 8) + " A";
                        BattDischrgAmp.Text = parseString(replyString, 9) + " A";
                        PeakRate.Text = "P " + parseString(replyString, 10) + "/KwHr";
                        OffPeakRate.Text = "P " + parseString(replyString, 11) + "/KwHr";
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                ;
            }

            //send requests
            
            if ((--RequestCounter == 0))
            {
                RequestCounter = RequestCounter + 5;
                if (AutoEnable.Checked == true)
                {
                    SerialPort.WriteLine("GET-ALL\n");
                }
            }
            if (SendString != "")
            {
                SerialPort.WriteLine(SendString + "\n");
                RequestCounter = RequestCounter + 2;
                SendString = "";
            }
            Timer.Enabled = true;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendString = EnterCommand.Text;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Incoming.Text = "";

        }
        private async void getSettings()
        {
            SerialPort.DiscardInBuffer();
            SerialPort.WriteLine("GET-SETTINGS\n");
            await Task.Delay(1000);
            RequestCounter = RequestCounter + 2;
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            if (DelayInMillis >= 100) { DelayInMillis = DelayInMillis - 100; }
        }
        private void Delay(int DelayInMillisecond)
        {
            DelayInMillis = DelayInMillisecond;
            while (DelayInMillis > 0) { Application.DoEvents(); }
        }

        private string parseString(string rawString, int fieldNum)
        {
            int startParse;
            int delimeterCount;
            string extractString;

            char[] rawStringArray = rawString.ToArray();
            extractString = "";

            startParse = 0;
            delimeterCount = 1;
            for (int i = startParse; i < rawString.Length; i++)
            {
                if (rawStringArray[i] == '|')
                {
                    delimeterCount += 1;
                    startParse = i + 1;
                }
                if (delimeterCount == fieldNum)
                {
                    for (int j = startParse; j < rawString.Length; j++)
                    {
                        if (rawStringArray[j] == '|' || rawStringArray[j] == '\r' || rawStringArray[j] == '\n')
                        {
                            return extractString;
                        }
                        extractString += rawStringArray[j];
                    }
                    return extractString;
                }
            }
            return "";
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Peak-Off-Peak System\n\nA Capstone Project by;\n\nPaul Mirandilla\nYisak Cabugnason\nCesar G. Manalo, Jr. (Adviser)\n\nCopyright 2019","About");
        }
    }
}
