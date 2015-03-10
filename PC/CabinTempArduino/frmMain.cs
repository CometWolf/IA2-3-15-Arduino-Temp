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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //GUI
            totGraph.SetToolTip(chartFetchedValues, "Click to enlarge");
            //END GUI        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLimits limitForm = new frmLimits();
            limitForm.ShowDialog();
        }

        private void btnSubscribers_Click(object sender, EventArgs e)
        {
            frmSubscribers subscribersForm = new frmSubscribers();
            subscribersForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
        }

        private void chartFetchedValues_Click(object sender, EventArgs e)
        {
            frmChart chart = new frmChart();
            chart.Show();
        }
    }
}
