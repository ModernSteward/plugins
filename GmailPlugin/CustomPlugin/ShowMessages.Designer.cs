namespace ModernSteward
{
    partial class ShowMessages
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			this.groupBoxUnreadMessages = new Telerik.WinControls.UI.RadGroupBox();
			this.gridViewMessages = new Telerik.WinControls.UI.RadGridView();
			this.labelNoNewMessages = new Telerik.WinControls.UI.RadLabel();
			((System.ComponentModel.ISupportInitialize)(this.groupBoxUnreadMessages)).BeginInit();
			this.groupBoxUnreadMessages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMessages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.labelNoNewMessages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxUnreadMessages
			// 
			this.groupBoxUnreadMessages.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.groupBoxUnreadMessages.Controls.Add(this.labelNoNewMessages);
			this.groupBoxUnreadMessages.Controls.Add(this.gridViewMessages);
			this.groupBoxUnreadMessages.FooterImageIndex = -1;
			this.groupBoxUnreadMessages.FooterImageKey = "";
			this.groupBoxUnreadMessages.HeaderImageIndex = -1;
			this.groupBoxUnreadMessages.HeaderImageKey = "";
			this.groupBoxUnreadMessages.HeaderMargin = new System.Windows.Forms.Padding(0);
			this.groupBoxUnreadMessages.HeaderText = "Непрочетени съобщения";
			this.groupBoxUnreadMessages.Location = new System.Drawing.Point(13, 13);
			this.groupBoxUnreadMessages.Name = "groupBoxUnreadMessages";
			this.groupBoxUnreadMessages.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			// 
			// 
			// 
			this.groupBoxUnreadMessages.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			this.groupBoxUnreadMessages.Size = new System.Drawing.Size(838, 441);
			this.groupBoxUnreadMessages.TabIndex = 0;
			this.groupBoxUnreadMessages.Text = "Непрочетени съобщения";
			// 
			// gridViewMessages
			// 
			this.gridViewMessages.Location = new System.Drawing.Point(6, 22);
			// 
			// gridViewMessages
			// 
			this.gridViewMessages.MasterTemplate.AllowAddNewRow = false;
			this.gridViewMessages.MasterTemplate.AllowColumnReorder = false;
			gridViewTextBoxColumn1.FormatString = "";
			gridViewTextBoxColumn1.HeaderText = "№";
			gridViewTextBoxColumn1.MaxWidth = 20;
			gridViewTextBoxColumn1.MinWidth = 20;
			gridViewTextBoxColumn1.Name = "id";
			gridViewTextBoxColumn1.Width = 20;
			gridViewTextBoxColumn2.FormatString = "";
			gridViewTextBoxColumn2.HeaderText = "Тема";
			gridViewTextBoxColumn2.MaxWidth = 300;
			gridViewTextBoxColumn2.MinWidth = 300;
			gridViewTextBoxColumn2.Name = "subject";
			gridViewTextBoxColumn2.Width = 300;
			gridViewTextBoxColumn3.FormatString = "";
			gridViewTextBoxColumn3.HeaderText = "Изпращач";
			gridViewTextBoxColumn3.MaxWidth = 150;
			gridViewTextBoxColumn3.MinWidth = 150;
			gridViewTextBoxColumn3.Name = "sender";
			gridViewTextBoxColumn3.Width = 150;
			this.gridViewMessages.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
			this.gridViewMessages.Name = "gridViewMessages";
			this.gridViewMessages.ReadOnly = true;
			this.gridViewMessages.Size = new System.Drawing.Size(827, 410);
			this.gridViewMessages.TabIndex = 0;
			this.gridViewMessages.Text = "gridViewMessages";
			this.gridViewMessages.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridViewMessages_CellDoubleClick);
			// 
			// labelNoNewMessages
			// 
			this.labelNoNewMessages.Location = new System.Drawing.Point(348, 207);
			this.labelNoNewMessages.Name = "labelNoNewMessages";
			this.labelNoNewMessages.Size = new System.Drawing.Size(128, 18);
			this.labelNoNewMessages.TabIndex = 0;
			this.labelNoNewMessages.Text = "Няма нови съобщения!";
			// 
			// ShowMessages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(863, 457);
			this.Controls.Add(this.groupBoxUnreadMessages);
			this.Name = "ShowMessages";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "Проверяване на поща";
			this.ThemeName = "ControlDefault";
			((System.ComponentModel.ISupportInitialize)(this.groupBoxUnreadMessages)).EndInit();
			this.groupBoxUnreadMessages.ResumeLayout(false);
			this.groupBoxUnreadMessages.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMessages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.labelNoNewMessages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Telerik.WinControls.UI.RadGroupBox groupBoxUnreadMessages;
		private Telerik.WinControls.UI.RadGridView gridViewMessages;
		private Telerik.WinControls.UI.RadLabel labelNoNewMessages;
    }
}
