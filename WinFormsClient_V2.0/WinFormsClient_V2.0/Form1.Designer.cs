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
			this.MessagesTextBox = new System.Windows.Forms.TextBox();
			this.OutMessageTextBox = new System.Windows.Forms.TextBox();
			this.SendButton = new System.Windows.Forms.Button();
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
			this.UsersListBox.Size = new System.Drawing.Size(150, 424);
			this.UsersListBox.TabIndex = 0;
			// 
			// MessagesTextBox
			// 
			this.MessagesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MessagesTextBox.Location = new System.Drawing.Point(168, 12);
			this.MessagesTextBox.Multiline = true;
			this.MessagesTextBox.Name = "MessagesTextBox";
			this.MessagesTextBox.ReadOnly = true;
			this.MessagesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MessagesTextBox.Size = new System.Drawing.Size(620, 361);
			this.MessagesTextBox.TabIndex = 1;
			// 
			// OutMessageTextBox
			// 
			this.OutMessageTextBox.Location = new System.Drawing.Point(168, 379);
			this.OutMessageTextBox.Multiline = true;
			this.OutMessageTextBox.Name = "OutMessageTextBox";
			this.OutMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OutMessageTextBox.Size = new System.Drawing.Size(518, 57);
			this.OutMessageTextBox.TabIndex = 2;
			// 
			// SendButton
			// 
			this.SendButton.Location = new System.Drawing.Point(692, 379);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(96, 57);
			this.SendButton.TabIndex = 3;
			this.SendButton.Text = "Send";
			this.SendButton.UseVisualStyleBackColor = true;
			// 
			// UpdateMessagesTimer
			// 
			this.UpdateMessagesTimer.Enabled = true;
			this.UpdateMessagesTimer.Interval = 1000;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.OutMessageTextBox);
			this.Controls.Add(this.MessagesTextBox);
			this.Controls.Add(this.UsersListBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Messanger";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ListBox UsersListBox;
		private TextBox MessagesTextBox;
		private TextBox OutMessageTextBox;
		private Button SendButton;
		private System.Windows.Forms.Timer UpdateMessagesTimer;
	}
}