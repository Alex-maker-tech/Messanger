using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			if ((UsernameTB.Text.Length >= 1) && (PasswordTB.Text.Length >= 1))
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

			bool result = Convert.ToInt32(await Form1.API.LoginAsync(userData)) > 0;
			if (result)
			{
				Form1.UserName = UsernameTB.Text;
				Form1.Password = PasswordTB.Text;
				this.Hide();
			}
			else MessageBox.Show("The username or password is incorrect", "Error", 
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private async void RegisterBtn_Click(object sender, EventArgs e)
		{
			if ((UsernameTB.Text.Length >= 1) && (PasswordTB.Text.Length >= 1))
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

			bool result = Convert.ToInt32(await Form1.API.RegisterAsync(userData)) > 0;
			if (result)
			{
				Form1.UserName = UsernameTB.Text;
				Form1.Password = PasswordTB.Text;
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
