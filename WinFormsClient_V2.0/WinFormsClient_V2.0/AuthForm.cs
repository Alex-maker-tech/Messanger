using MessangerAPI;

using WinFormsClient_V2._0;

namespace WinFormsClient
{
	public partial class AuthForm : Form
	{
		private UserData? userData;

		public static bool IsClosed = false;

		public AuthForm()
		{
			InitializeComponent();
		}

		private async void OkBtn_Click(object sender, EventArgs e)
		{
			//! Проверка имени пользователя и пароля
			if ((UsernameTB.Text.Length > 0) && (PasswordTB.Text.Length > 0))
			{
				userData = new UserData()
				{
					UserName = UsernameTB.Text,
					Password = PasswordTB.Text
				};
			}
			else
			{
				MessageBox.Show("The username or password is too short", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int result = await Form1.API.LoginAsync(userData);
			if (result != -1)
			{
				Form1.Id = result;
				Form1.UserName = userData.UserName;
				Form1.Password = userData.Password;
				this.Hide();
			}
			else MessageBox.Show("The username or password is incorrect", "Error", 
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private async void RegisterBtn_Click(object sender, EventArgs e)
		{
			if ((UsernameTB.Text.Length > 0) && (PasswordTB.Text.Length > 0))
			{
				userData = new UserData()
				{
					UserName = UsernameTB.Text,
					Password = PasswordTB.Text
				};
			}
			else
			{
				MessageBox.Show("The username or password is too short", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int result = await Form1.API.RegisterAsync(userData);
			if (result != -1)
			{
				Form1.Id = result;
				Form1.UserName = userData.UserName;
				Form1.Password = userData.Password;
				this.Hide();
			}
			else MessageBox.Show("Try again", "Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked) PasswordTB.PasswordChar = (char)0;
			else PasswordTB.PasswordChar = '*';
		}
	}
}
