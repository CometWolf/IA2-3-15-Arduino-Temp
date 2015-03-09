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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtCustomInterval.Enabled = false;
            rbtSeconds.Enabled = false;
            rbtMinutes.Enabled = false;
        }

        private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPreset.Text != "Custom")
            { 
                txtCustomInterval.Enabled = false;
                rbtSeconds.Enabled = false;
                rbtMinutes.Enabled = false;
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtSeconds.Enabled = true;
                rbtMinutes.Enabled = true;
            }
                    
        }
    }
}
