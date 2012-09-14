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
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonEditCard = new System.Windows.Forms.Button();
			this.listBoxCards = new System.Windows.Forms.ListBox();
			this.groupBoxRFIDCards = new System.Windows.Forms.GroupBox();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.domainUpDownComPort = new System.Windows.Forms.DomainUpDown();
			this.buttonOpenPort = new System.Windows.Forms.Button();
			this.groupBoxRFIDCards.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(204, 161);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonEditCard
			// 
			this.buttonEditCard.Location = new System.Drawing.Point(123, 161);
			this.buttonEditCard.Name = "buttonEditCard";
			this.buttonEditCard.Size = new System.Drawing.Size(75, 23);
			this.buttonEditCard.TabIndex = 1;
			this.buttonEditCard.Text = "Edit card";
			this.buttonEditCard.UseVisualStyleBackColor = true;
			this.buttonEditCard.Click += new System.EventHandler(this.buttonEditCard_Click);
			// 
			// listBoxCards
			// 
			this.listBoxCards.FormattingEnabled = true;
			this.listBoxCards.Location = new System.Drawing.Point(12, 21);
			this.listBoxCards.Name = "listBoxCards";
			this.listBoxCards.Size = new System.Drawing.Size(267, 134);
			this.listBoxCards.TabIndex = 2;
			// 
			// groupBoxRFIDCards
			// 
			this.groupBoxRFIDCards.Controls.Add(this.buttonOpen);
			this.groupBoxRFIDCards.Controls.Add(this.listBoxCards);
			this.groupBoxRFIDCards.Controls.Add(this.buttonSave);
			this.groupBoxRFIDCards.Controls.Add(this.buttonEditCard);
			this.groupBoxRFIDCards.Location = new System.Drawing.Point(13, 36);
			this.groupBoxRFIDCards.Name = "groupBoxRFIDCards";
			this.groupBoxRFIDCards.Size = new System.Drawing.Size(291, 193);
			this.groupBoxRFIDCards.TabIndex = 3;
			this.groupBoxRFIDCards.TabStop = false;
			this.groupBoxRFIDCards.Text = "RFID Cards";
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(12, 161);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 3;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Wave the card over the sensor to add it.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "House model is connect to";
			// 
			// domainUpDownComPort
			// 
			this.domainUpDownComPort.Location = new System.Drawing.Point(155, 11);
			this.domainUpDownComPort.Name = "domainUpDownComPort";
			this.domainUpDownComPort.Size = new System.Drawing.Size(65, 20);
			this.domainUpDownComPort.TabIndex = 9;
			this.domainUpDownComPort.Text = "0";
			this.domainUpDownComPort.SelectedItemChanged += new System.EventHandler(this.domainUpDownComPort_SelectedItemChanged);
			// 
			// buttonOpenPort
			// 
			this.buttonOpenPort.Location = new System.Drawing.Point(230, 8);
			this.buttonOpenPort.Name = "buttonOpenPort";
			this.buttonOpenPort.Size = new System.Drawing.Size(74, 23);
			this.buttonOpenPort.TabIndex = 8;
			this.buttonOpenPort.Text = "Open port";
			this.buttonOpenPort.UseVisualStyleBackColor = true;
			this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
			// 
			// InitializeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(316, 252);
			this.Controls.Add(this.domainUpDownComPort);
			this.Controls.Add(this.buttonOpenPort);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBoxRFIDCards);
			this.Name = "InitializeForm";
			this.Text = "Initialize";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitializeForm_FormClosing);
			this.groupBoxRFIDCards.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonEditCard;
		private System.Windows.Forms.ListBox listBoxCards;
		private System.Windows.Forms.GroupBox groupBoxRFIDCards;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DomainUpDown domainUpDownComPort;
		private System.Windows.Forms.Button buttonOpenPort;
		private System.Windows.Forms.Button buttonOpen;
	}
}