namespace WinFormsClient
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
			this.SendMessageBtn = new System.Windows.Forms.Button();
			this.MessageTB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.UpdateMessagesTimer = new System.Windows.Forms.Timer(this.components);
			this.MessagesLB = new System.Windows.Forms.ListBox();
			this.ClosingTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// SendMessageBtn
			// 
			this.SendMessageBtn.Location = new System.Drawing.Point(563, 322);
			this.SendMessageBtn.Name = "SendMessageBtn";
			this.SendMessageBtn.Size = new System.Drawing.Size(102, 60);
			this.SendMessageBtn.TabIndex = 3;
			this.SendMessageBtn.Text = "Send";
			this.SendMessageBtn.UseVisualStyleBackColor = true;
			this.SendMessageBtn.Click += new System.EventHandler(this.SendMessageBtn_Click);
			// 
			// MessageTB
			// 
			this.MessageTB.Location = new System.Drawing.Point(88, 319);
			this.MessageTB.Multiline = true;
			this.MessageTB.Name = "MessageTB";
			this.MessageTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MessageTB.Size = new System.Drawing.Size(469, 63);
			this.MessageTB.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 322);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Message:";
			// 
			// UpdateMessagesTimer
			// 
			this.UpdateMessagesTimer.Enabled = true;
			this.UpdateMessagesTimer.Interval = 1000;
			this.UpdateMessagesTimer.Tick += new System.EventHandler(this.UpdateMessagesTimer_Tick);
			// 
			// MessagesLB
			// 
			this.MessagesLB.FormattingEnabled = true;
			this.MessagesLB.ItemHeight = 20;
			this.MessagesLB.Location = new System.Drawing.Point(12, 12);
			this.MessagesLB.Name = "MessagesLB";
			this.MessagesLB.Size = new System.Drawing.Size(653, 304);
			this.MessagesLB.TabIndex = 6;
			this.MessagesLB.TabStop = false;
			// 
			// ClosingTimer
			// 
			this.ClosingTimer.Enabled = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 394);
			this.Controls.Add(this.MessagesLB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MessageTB);
			this.Controls.Add(this.SendMessageBtn);
			this.Name = "Form1";
			this.Text = "Messanger Client";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button SendMessageBtn;
		private TextBox MessageTB;
		private Label label2;
		private System.Windows.Forms.Timer UpdateMessagesTimer;
		private ListBox MessagesLB;
		private System.Windows.Forms.Timer ClosingTimer;
	}
}