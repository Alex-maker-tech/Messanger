using MessangerAPI;

using Microsoft.VisualBasic.ApplicationServices;

using System.Linq;
using System.Web;

using WinFormsClient;

namespace WinFormsClient_V2._0
{
	public partial class Form1 : Form
	{
		private static AuthForm? AuthForm;

		public static int? Id;
		public static string? UserName;
		public static string? Password;

		public static MessangerClientAPI API = new MessangerClientAPI();

		List<int> IdsList = new();
		Dictionary<int, string> UsersDict = new();
		Dictionary<int, List<MessangerAPI.Message>> MessagesDict = new();
		KeyValuePair<int, string> IdUsernamePair;

		public Form1() => InitializeComponent();
		

		private void Form1_Shown(object sender, EventArgs e)
		{
			UpdateMessagesTimer.Enabled = false;
			UsersListBox.SelectedIndex = -1;
			AuthForm = new AuthForm();
			AuthForm.FormClosed += new FormClosedEventHandler(AuthForm_FormClosed);
			AuthForm.ShowDialog();
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (UpdateMessagesTimer.Enabled == false)
				UpdateMessagesTimer.Enabled = true;
			if (UserName != null)
				this.Text = $"Messanger Client ({UserName} #{Id})";
		}

		private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool result = await API.LogoutAsync(new UserData { UserId = Id });

			if (result)
				e.Cancel = true;
			else
			{
				e.Cancel = false;
				MessageBox.Show("Try close window again", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AuthForm_FormClosed(object sender, FormClosedEventArgs e) => this.Close();
		

		private async void SendMessageButton_Click(object sender, EventArgs e)
		{
			string str = OutMessageTextBox.Text;

			if (str.Length < 1)
			{
				OutMessageTextBox.Select();
				return;
			}

			MessangerAPI.Message msg = new MessangerAPI.Message
			{ 
				UserId = (int)Id,
				RecipientId = IdUsernamePair.Key,
				MessageText = str,
				TimeStamp = DateTime.UtcNow
			};

			bool res;
			do
			{
				res = await API.SendMessageAsync(msg);
			} while (!res);

			OutMessageTextBox.Text = string.Empty;
			OutMessageTextBox.Select();
		}

		private void UsersListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (UsersListBox.SelectedIndex == -1) return;

			IdUsernamePair = new KeyValuePair<int, string>(Convert.ToInt32(UsersListBox.SelectedItem.ToString().Split(" #")[1]), UsersListBox.SelectedItem.ToString().Split(" #")[0]);

			UsernameLabel.Text = UsersListBox.SelectedItem.ToString();

			List<MessangerAPI.Message> msgs = new();
			if (IdUsernamePair.Value == "Self") msgs.AddRange(MessagesDict[-1]);
			else msgs = MessagesDict[IdUsernamePair.Key];
				

			msgs = msgs.OrderBy(p => p.TimeStamp).ToList();

			List<MessangerAPI.Message> MessagesList = new();
			if (!MessagesList.Equals(msgs))
			{
				MessagesTextBox.Text = string.Empty;
				foreach (var msg in msgs)
				{
					if (!MessagesList.Contains(msg))
					{
						MessagesList.Add(msg);
						MessagesTextBox.Text += msg.ToString() + Environment.NewLine;
					}
				}
			}

			OutMessageTextBox.Select();
		}

		private void UsersComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (UsersComboBox.SelectedIndex == -1) return;

			UsernameLabel.Text = UsersComboBox.SelectedItem.ToString();

			if (UsersListBox.Items.Contains(UsersComboBox.SelectedItem.ToString()))
			{
				UsersListBox.SelectedItem = UsersComboBox.SelectedItem.ToString();
				OutMessageTextBox.Select();
			}
			else
			{
				IdUsernamePair = new KeyValuePair<int, string>(Convert.ToInt32(UsersComboBox.SelectedItem.ToString().Split(" #")[1]), UsersComboBox.SelectedItem.ToString().Split(" #")[0]);
				MessagesDict[IdUsernamePair.Key] = new List<MessangerAPI.Message>();

				UsersListBox.Items.Insert(1, UsersComboBox.SelectedItem.ToString());
				UsersListBox.SelectedItem = UsersComboBox.SelectedItem.ToString();
				OutMessageTextBox.Select();
			}

		}
		
		private void UpdateMessagesTimer_Tick(object sender, EventArgs e)
		{
			var GetMessages = new Func<Task>(async () =>
			{
				var list = await API.GetMessagesHTTPAsync((int)Id);

				foreach (var item in list)
				{
					if (!IdsList.Contains(item.Id))
					{
						IdsList.Add(item.Id);

						item.UserName = await API.GetUsername(item.UserId);

						if ((item.UserId == Id) && (item.RecipientId == Id))
						{
							item.UserId = -1;
							item.RecipientId = -1;
							item.UserName = "Self";
						}

						if (item.UserId == Id && item.RecipientId != Id) 
						{
							item.UserName = "Me";
						}

						if (!UsersDict.Keys.Contains(item.UserId))
							UsersDict[item.UserId] = item.UserName;

						if (!MessagesDict.Keys.Contains(item.UserId))
							MessagesDict[item.UserId] = new List<MessangerAPI.Message>();

						int tempId = item.UserId;
						if (item.UserId == -1) item.UserId = (int)Id;

						if (item.UserId == (int)Id && item.RecipientId != Id)
						{
							if (!UsersDict.Keys.Contains((int)item.RecipientId))
								UsersDict[(int)item.RecipientId] = await API.GetUsername((int)item.RecipientId);

							if (!MessagesDict.Keys.Contains((int)item.RecipientId))
								MessagesDict[(int)item.RecipientId] = new List<MessangerAPI.Message>();

							MessagesDict[(int)item.RecipientId].Add(item);
						}
						else MessagesDict[tempId].Add(item);
					}
				}


				if (!UsersListBox.Items.Contains(UsersDict.Values))
				{
					var keys = UsersDict.Keys.OrderBy(p => p).ToList();

					foreach (var key in keys)
					{
						if (UsersDict[key] == "Self")
							UsersDict[key] += $" #{Id}";
						if (!UsersDict[key].Contains(" #"))
							UsersDict[key] += $" #{key}";

						if ((!UsersListBox.Items.Contains(UsersDict[key])) && (key != Id))
							UsersListBox.Items.Add(UsersDict[key]);
					}
				}

				var users = await API.GetUsers();
				var usersList = new List<string>();

				foreach (var user in users)
				{
					usersList.Add($"{user.UserName} #{user.UserId}");
				}

				if (!UsersComboBox.Items.Equals(usersList))
				{
					foreach (var user in usersList)
					{
						if (!UsersComboBox.Items.Contains(user))
						{
							if (Convert.ToInt32(user.Split(" #")[1]) != Id)
							{
								UsersComboBox.Items.Add(user);
							}
						}
					}
				}

				var messages = new List<MessangerAPI.Message>();
				if (Convert.ToInt32(UsersListBox.SelectedItem.ToString().Split(" #")[1]) == Id) messages = MessagesDict[-1];
				else messages = MessagesDict[Convert.ToInt32(UsersListBox.SelectedItem.ToString().Split(" #")[1])];
				string msgs = string.Empty;
				foreach (var msg in messages)
					msgs += msg.ToString() + Environment.NewLine;
				
				if (!MessagesTextBox.Text.Equals(msgs))
				{
					MessagesTextBox.Text = msgs;
				}
			}
			);

			GetMessages.Invoke();
		}

		private void UsersComboBox_Leave(object sender, EventArgs e)
		{
			UsersComboBox.Text = "Select User you want to write to";
		}
	}
}