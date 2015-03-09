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
    public partial class frmSubscribers : Form
    {
        public frmSubscribers()
        {
            InitializeComponent();
        }

        private void cboSelectSubscriber_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GUI
            if (cboSelectSubscriber.Text != "New")
                btnSubmit.Text = "Submit changes";

            if (cboSelectSubscriber.Text == "New")
                btnDelete.Enabled = false;
            else
                btnDelete.Enabled = true;
            //END GUI
        }
    }
}
