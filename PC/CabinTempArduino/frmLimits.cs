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
    public partial class frmLimits : Form
    {
        public frmLimits()
        {
            InitializeComponent();
        }

        private void txtValue_Click(object sender, EventArgs e)
        {
            //GUI
            if (txtValue.Text == "Value (C)")
                txtValue.Text = "";
            //END GUI
        }
    }
}
