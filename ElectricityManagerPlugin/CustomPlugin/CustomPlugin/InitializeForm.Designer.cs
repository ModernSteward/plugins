namespace ModernSteward
{
    partial class InitializeForm
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
            this.dropDownListPorts = new Telerik.WinControls.UI.RadDropDownList();
            this.buttonOK = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListPorts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dropDownListPorts
            // 
            this.dropDownListPorts.DropDownAnimationEnabled = true;
            this.dropDownListPorts.Location = new System.Drawing.Point(13, 11);
            this.dropDownListPorts.Name = "dropDownListPorts";
            this.dropDownListPorts.ShowImageInEditorArea = true;
            this.dropDownListPorts.Size = new System.Drawing.Size(90, 20);
            this.dropDownListPorts.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(110, 9);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(41, 24);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // InitializeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 43);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dropDownListPorts);
            this.Name = "InitializeForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "COMPort";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListPorts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList dropDownListPorts;
        private Telerik.WinControls.UI.RadButton buttonOK;
    }
}
