using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace CabinTempArduino
{
    public partial class frmSettings : Form
    {
        Database settings = new Database("ArduinoTemperaturMåling.accdb");
        frmMain main = (frmMain)Application.OpenForms["frmMain"];
        public frmSettings()
        {
            InitializeComponent();
            //GUI
            txtCustomInterval.Enabled = false;
            rbtHours.Enabled = false;
            rbtMinutes.Enabled = false;
            btnInterval.Enabled = false;
            btnComPort.Enabled = false;
            //END GUI

            //Valid ports
            string[] serialPortNames = SerialPort.GetPortNames();
            foreach (string port in serialPortNames)
            {
                cboComPort.Items.Add(port); //Adds ports with serialCom attached to the combobox.
            }
            //END Valid ports
        }
        private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUI
            if (cboPreset.SelectedIndex != 3)
            { 
                txtCustomInterval.Enabled = false;
                rbtHours.Enabled = false;
                rbtMinutes.Enabled = false;
                btnInterval.Enabled = true;
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtHours.Enabled = true;
                rbtMinutes.Enabled = true;
                btnInterval.Enabled = true;
            }
            //END GUI
        }

        private void txtCustomInterval_Click(object sender, EventArgs e)
        {
            //GUI
            if (txtCustomInterval.Text == "Verdi")
                txtCustomInterval.Text = "";
            //END GUI
        }

        private void btnComPort_Click(object sender, EventArgs e)
        {
            //Changes the port.
            try
            {
                if (cboComPort.Text != "Port")
                {
                    settings.UpdateSetting(cboComPort.Text, 8, 0);
                    main.SetPortArduino(cboComPort.Text);
                    MessageBox.Show("Port endret.");
                }
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Porten er allerede i bruk."+"\r\n"+"Hvis dette er feil: Restart og eventuelt sett inn USB-kabel på nytt.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUI
            if (cboComPort.Text == "Port")
                btnComPort.Enabled = false;
            else
                btnComPort.Enabled = true;
            //END GUI
        }

        private void btnInterval_Click(object sender, EventArgs e)
        {
            //Changes the interval.
            try
            {
                string[] usedValue = settings.GetSettings(0);

                if (cboPreset.SelectedIndex == 0)
                {
                    if (usedValue[5] == "60")
                        MessageBox.Show("Intervall allerede i bruk.");
                    else
                    {
                        SetNewInterval("60", "false");
                    }

                }
                else if (cboPreset.SelectedIndex == 1)
                {
                    if (usedValue[5] == "30")
                        MessageBox.Show("Intervall allerede i bruk.");
                    else
                    {
                        SetNewInterval("30", "false");
                    }
                }
                else if (cboPreset.SelectedIndex == 2)
                {
                    if (usedValue[5] == "15")
                        MessageBox.Show("Intervall allerede i bruk");
                    else
                    {
                        SetNewInterval("15", "false");
                    }
                }
                else if (cboPreset.SelectedIndex == 3)
                {
                    int value = 0;
                    if (rbtHours.Checked || rbtMinutes.Checked)
                    {
                        if (!int.TryParse(txtCustomInterval.Text, out value) || txtCustomInterval.Text == "0")
                        {
                            MessageBox.Show("Ikke bruk desimaltall, null eller tekst.");
                        }
                        else
                        {
                            if (rbtHours.Checked)
                            {
                                if (value > 24)
                                    MessageBox.Show("Ikke gå over 24 timer.");
                                else if (Convert.ToString(value * 60) == usedValue[5])
                                    MessageBox.Show("Intervall allerede i bruk.");
                                else if (value * 60 == 1440)
                                {
                                    settings.UpdateSetting("1440", 5, 0);
                                    main.NextLogTime(); //Since it's 24hrs to next log only a log time is needed, a log will automatically be executed since it's the same time as now the next day.
                                    settings.UpdateSetting("true", 7, 0);
                                    MessageBox.Show("Intervall endret.");
                                }
                                else
                                {
                                    SetNewInterval(Convert.ToString(value * 60), "true");
                                }
                            }
                            else if (rbtMinutes.Checked)
                            {
                                if (value > 1440)
                                    MessageBox.Show("Ikke gå over 24 timer.");
                                else if (Convert.ToString(value) == usedValue[5])
                                    MessageBox.Show("Intervall allerede i bruk.");
                                else if (value == 1440)
                                {
                                    settings.UpdateSetting("1440", 5, 0);
                                    main.NextLogTime();
                                    settings.UpdateSetting("true", 7, 0);
                                    MessageBox.Show("Intervall endret.");
                                }
                                else
                                {
                                    SetNewInterval(Convert.ToString(value), "true");
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Huk av for 'Timer' eller 'Minutter'");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetNewInterval(string newInterval, string custom)
        {
            //Sets the new interval and makes sure the temperature is logged at the same time. 
            settings.UpdateSetting(newInterval, 5, 0);
            settings.UpdateSetting(custom, 7, 0);
            main.NewInterval();
            MessageBox.Show("Intervall endret.");
        }
    }
}
