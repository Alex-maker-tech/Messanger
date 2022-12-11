using ASPCoreServer;

using Messanger;

using System.Runtime.InteropServices;

namespace WinFormsClient
{
	public partial class Form1 : Form
	{
		public static string? UserName;
		public static string? Password;
		private static int MessageId = 0;
		public static MessangerClientAPI API = new MessangerClientAPI();
		private static AuthForm? authForm;


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			UpdateMessagesTimer.Enabled = false;
			authForm = new AuthForm();
			authForm.FormClosed += new FormClosedEventHandler(authForm_FormClosed);
			authForm.ShowDialog();
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (UpdateMessagesTimer.Enabled == false)
				UpdateMessagesTimer.Enabled = true;
			if (UserName != null)
				this.Text = $"Messanger Client ({UserName})";
		}

		private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool result = Convert.ToInt32(await API.LogoutAsync(new UserData(UserName, Password))) > 0;
			if (result)
			{
				e.Cancel = true;
			}
			else
			{
				e.Cancel = false;
				MessageBox.Show("Try close window again", "Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void authForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

		private async void SendMessageBtn_Click(object sender, EventArgs e)
		{
			string str = MessageTB.Text.Trim();
			if (str.Length < 1)
			{
				MessageTB.Select();
				return;
			}
			Messanger.Message msg = new Messanger.Message(UserName, MessageTB.Text, DateTime.Now);
			await API.SendMessageAsync(msg);
			MessageTB.Text = string.Empty;
			MessageTB.Select();
		}

		private void UpdateMessagesTimer_Tick(object sender, EventArgs e)
		{
			var getMessage = new Func<Task>(async () =>
			{
				Messanger.Message msg = await API.GetMessageHTTPAsync(MessageId);
				while (msg != null)
				{
					MessagesLB.Items.Add(msg);
					MessagesLB.SelectedIndex = MessagesLB.Items.Count - 1;
					MessagesLB.SelectedIndex = -1;
					++MessageId;
					msg = await API.GetMessageHTTPAsync(MessageId);
					Thread.Sleep(100);
				}
			}
			);
			getMessage.Invoke();
		}
	}
}