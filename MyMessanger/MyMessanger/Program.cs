using Newtonsoft.Json;
using Messanger;
using ASPCoreServer;

namespace MyMessanger
{
	internal class Program
	{
		//public static int MessageId;
		//public static string UserName;
		private static MessangerClientAPI API = new MessangerClientAPI();
		private static List<int> Ids = new List<int>();


		/*private static void GetNewMessages(bool state = true)
		{
			Message msg = API.GetMessages(MessageId);
			while (msg != null)
			{
				if ((msg.UserName == UserName) && (UserName != null) && (state == true))
				{
					++MessageId;
					msg = API.GetMessages(MessageId);
					continue; 
				}

				Console.WriteLine(msg.ToString());
				++MessageId;
				msg = API.GetMessages(MessageId);
			}
		}*/

		/*static void Main(string[] args)
		{
			// { "UserName":"Alex","MessageText":"Hello World!","TimeStamp":"2022-07-27T14:42:34.7955623Z"}
			// Alex < 27.07.2022 14:42:34 >: Hello World!

			MessageId = 0;
			do
			{
				Console.Write("Введите Ваше имя: ");
				UserName = Console.ReadLine().Trim('\n', '\t');
			} while ((UserName == null) || (UserName == string.Empty));

			if (MessageId < API.GetMsgCount())
			{
				GetNewMessages();
			}


			string MessageText = string.Empty;
			while (MessageText.ToLower() != "exit")
			{
				GetNewMessages();
				Console.Write("Введите текст сообщения: ");
				MessageText = Console.ReadLine();
				if (MessageText.Length > 1)
				{
					Message SendMsg = new Message(UserName, MessageText, DateTime.Now);
					API.SendMessage(SendMsg);
				}
			}
		}
		*/
		
		private static void GetNewMessages(int id)
		{
			var list = API.GetMessagesHTTPAsync(id).Result;

			foreach (var item in list)
			{
				if (!Ids.Contains(item.Id))
				{
					Ids.Add(item.Id);
					Console.WriteLine(item);
				}
			}

		}

		static void Main(string[] args)
		{
			/*int id = -1;
			UserData user;
			do
			{
				Console.Clear();
				user = new UserData();
				Console.Write("Username: ");
				string username = Console.ReadLine().Trim('\n', '\r');
				Console.Write("Password: ");
				string password = Console.ReadLine().Trim('\n', '\r');

				if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
					continue;

				user.UserName = username;
				user.Password = password;

				id = API.LoginAsync(user).Result;
			} while (id == -1);

			user.UserId = id;
			Console.WriteLine(user);

			do
			{
				GetNewMessages((int)user.UserId);
			} while (Console.ReadLine() != "exit") ;


			bool result = API.LogoutAsync(user).Result;
			Console.WriteLine(result);*/

			object? str = new();
			str = null;
			_ = int.TryParse(str.ToString(), out int integer);
			Console.WriteLine(integer);
		}
	}
}