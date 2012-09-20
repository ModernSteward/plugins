using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ModernSteward
{
    public partial class InitializeForm : Telerik.WinControls.UI.RadForm
    {
        public string selectedCOM = "COM4";

        public InitializeForm()
        {
            InitializeComponent();

            string com = "COM";
            for (int i = 1; i < 36; i++)
            {
                dropDownListPorts.Items.Add(com+i.ToString());
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool toCloseTheForm = true;
            try
            {
                selectedCOM = "COM" + (dropDownListPorts.SelectedIndex+1).ToString();
            }
            catch (Exception ex)
            {
                toCloseTheForm = false;
            }
            if (toCloseTheForm)
            {
                this.Close();
            }
        }
    }
}
