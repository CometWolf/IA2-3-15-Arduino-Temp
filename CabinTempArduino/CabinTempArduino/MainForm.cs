using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinTempArduino
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimitsForm limitForm = new LimitsForm();
            limitForm.ShowDialog();
        }

        private void btnSubscribers_Click(object sender, EventArgs e)
        {
            SubscribersForm subscribersForm = new SubscribersForm();
            subscribersForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
