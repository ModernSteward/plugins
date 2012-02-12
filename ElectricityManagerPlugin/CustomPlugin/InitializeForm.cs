using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ElectricityManager;

namespace ModernSteward
{
    public partial class InitializeForm : Telerik.WinControls.UI.RadForm
    {
        ElectricityManager.ElectricityManager mElectricityManager;
        public InitializeForm(ElectricityManager.ElectricityManager aElectricityManager)
        {
            InitializeComponent();

            mElectricityManager = aElectricityManager;

            string com = "COM";
            for (int i = 1; i < 9; i++)
            {
                dropDownListPorts.Items.Add(com+i.ToString());
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool toCloseTheForm = true;
            try
            {
                mElectricityManager =
                    new ElectricityManager.ElectricityManager(dropDownListPorts.SelectedText, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the port! Message: " + ex.Message);
                toCloseTheForm = false;
            }
            if (toCloseTheForm)
            {
                this.Close();
            }
        }
    }
}
