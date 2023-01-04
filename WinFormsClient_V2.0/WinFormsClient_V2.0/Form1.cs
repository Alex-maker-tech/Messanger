using MessangerAPI;

using WinFormsClient;

namespace WinFormsClient_V2._0
{
	public partial class Form1 : Form
	{
		private static AuthForm? authForm;

		public static string? UserName;
		public static string? Password;

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

		private void authForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}


	}
}