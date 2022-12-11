namespace WinFormsClient
{
	partial class AuthForm
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
			this.UsernameTB = new System.Windows.Forms.TextBox();
			this.PasswordTB = new System.Windows.Forms.TextBox();
			this.OkBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RegisterBtn = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// UsernameTB
			// 
			this.UsernameTB.Location = new System.Drawing.Point(96, 6);
			this.UsernameTB.Name = "UsernameTB";
			this.UsernameTB.Size = new System.Drawing.Size(207, 27);
			this.UsernameTB.TabIndex = 0;
			// 
			// PasswordTB
			// 
			this.PasswordTB.Location = new System.Drawing.Point(96, 39);
			this.PasswordTB.Name = "PasswordTB";
			this.PasswordTB.PasswordChar = '*';
			this.PasswordTB.Size = new System.Drawing.Size(207, 27);
			this.PasswordTB.TabIndex = 1;
			// 
			// OkBtn
			// 
			this.OkBtn.Location = new System.Drawing.Point(12, 102);
			this.OkBtn.Name = "OkBtn";
			this.OkBtn.Size = new System.Drawing.Size(93, 29);
			this.OkBtn.TabIndex = 3;
			this.OkBtn.Text = "OK";
			this.OkBtn.UseVisualStyleBackColor = true;
			this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(210, 102);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(93, 29);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Password:";
			// 
			// RegisterBtn
			// 
			this.RegisterBtn.Location = new System.Drawing.Point(111, 102);
			this.RegisterBtn.Name = "RegisterBtn";
			this.RegisterBtn.Size = new System.Drawing.Size(93, 29);
			this.RegisterBtn.TabIndex = 4;
			this.RegisterBtn.Text = "Register";
			this.RegisterBtn.UseVisualStyleBackColor = true;
			this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(96, 72);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(139, 24);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Visible password";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// AuthForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 140);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.RegisterBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PasswordTB);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OkBtn);
			this.Controls.Add(this.UsernameTB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AuthForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Authentication";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox UsernameTB;
		private TextBox PasswordTB;
		private Button OkBtn;
		private Button CancelBtn;
		private Label label1;
		private Label label2;
		private Button RegisterBtn;
		private CheckBox checkBox1;
	}
}