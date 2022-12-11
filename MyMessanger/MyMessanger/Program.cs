using Newtonsoft.Json;
using Messanger;

namespace MyMessanger
{
	internal class Program
	{
		public static int MessageId;
		public static string UserName;
		private static MessangerClientAPI API = new MessangerClientAPI();

		private static void GetNewMessages(bool state = true)
		{
			Message msg = API.GetMessage(MessageId);
			while (msg != null)
			{
				if ((msg.UserName == UserName) && (UserName != null) && (state == true))
				{
					++MessageId;
					msg = API.GetMessage(MessageId);
					continue; 
				}

				Console.WriteLine(msg.ToString());
				++MessageId;
				msg = API.GetMessage(MessageId);
			}
		}

		static void Main(string[] args)
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
	}
}