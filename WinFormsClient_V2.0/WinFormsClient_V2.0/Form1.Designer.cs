namespace WinFormsClient_V2._0
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.UsersListBox = new System.Windows.Forms.ListBox();
			this.UsernameLabel = new System.Windows.Forms.Label();
			this.MessagesTextBox = new System.Windows.Forms.TextBox();
			this.OutMessageTextBox = new System.Windows.Forms.TextBox();
			this.SendMessageButton = new System.Windows.Forms.Button();
			this.UsersComboBox = new System.Windows.Forms.ComboBox();
			this.UpdateMessagesTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// UsersListBox
			// 
			this.UsersListBox.FormattingEnabled = true;
			this.UsersListBox.ItemHeight = 20;
			this.UsersListBox.Location = new System.Drawing.Point(12, 12);
			this.UsersListBox.Name = "UsersListBox";
			this.UsersListBox.ScrollAlwaysVisible = true;
			this.UsersListBox.Size = new System.Drawing.Size(177, 424);
			this.UsersListBox.TabIndex = 0;
			this.UsersListBox.SelectedIndexChanged += new System.EventHandler(this.UsersListBox_SelectedIndexChanged);
			// 
			// UsernameLabel
			// 
			this.UsernameLabel.Location = new System.Drawing.Point(195, 12);
			this.UsernameLabel.Name = "UsernameLabel";
			this.UsernameLabel.Size = new System.Drawing.Size(348, 25);
			this.UsernameLabel.TabIndex = 1;
			// 
			// MessagesTextBox
			// 
			this.MessagesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MessagesTextBox.Location = new System.Drawing.Point(195, 40);
			this.MessagesTextBox.Multiline = true;
			this.MessagesTextBox.Name = "MessagesTextBox";
			this.MessagesTextBox.ReadOnly = true;
			this.MessagesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MessagesTextBox.Size = new System.Drawing.Size(593, 339);
			this.MessagesTextBox.TabIndex = 2;
			// 
			// OutMessageTextBox
			// 
			this.OutMessageTextBox.Location = new System.Drawing.Point(195, 385);
			this.OutMessageTextBox.Multiline = true;
			this.OutMessageTextBox.Name = "OutMessageTextBox";
			this.OutMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OutMessageTextBox.Size = new System.Drawing.Size(515, 51);
			this.OutMessageTextBox.TabIndex = 3;
			// 
			// SendMessageButton
			// 
			this.SendMessageButton.Location = new System.Drawing.Point(716, 385);
			this.SendMessageButton.Name = "SendMessageButton";
			this.SendMessageButton.Size = new System.Drawing.Size(72, 51);
			this.SendMessageButton.TabIndex = 4;
			this.SendMessageButton.Text = "Send";
			this.SendMessageButton.UseVisualStyleBackColor = true;
			this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
			// 
			// UsersComboBox
			// 
			this.UsersComboBox.FormattingEnabled = true;
			this.UsersComboBox.Location = new System.Drawing.Point(549, 9);
			this.UsersComboBox.Name = "UsersComboBox";
			this.UsersComboBox.Size = new System.Drawing.Size(239, 28);
			this.UsersComboBox.TabIndex = 5;
			this.UsersComboBox.Text = "Select User you want to write to";
			this.UsersComboBox.SelectedIndexChanged += new System.EventHandler(this.UsersComboBox_SelectedIndexChanged);
			this.UsersComboBox.Leave += new System.EventHandler(this.UsersComboBox_Leave);
			// 
			// UpdateMessagesTimer
			// 
			this.UpdateMessagesTimer.Tick += new System.EventHandler(this.UpdateMessagesTimer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.UsersComboBox);
			this.Controls.Add(this.SendMessageButton);
			this.Controls.Add(this.OutMessageTextBox);
			this.Controls.Add(this.MessagesTextBox);
			this.Controls.Add(this.UsernameLabel);
			this.Controls.Add(this.UsersListBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Messanger Client";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ListBox UsersListBox;
		private Label UsernameLabel;
		private TextBox MessagesTextBox;
		private TextBox OutMessageTextBox;
		private Button SendMessageButton;
		private ComboBox UsersComboBox;
		private System.Windows.Forms.Timer UpdateMessagesTimer;
	}
}