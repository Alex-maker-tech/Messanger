using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessanger
{
	[Serializable]
	public class Message
	{
		public string UserName { get; set; }
		public string MessageText { get; set; }
		public DateTime TimeStamp { get; set; }

		public Message()
		{
			UserName = "System";
			MessageText = "Server is running...";
			TimeStamp = DateTime.Now;
		}

		public Message(string userName, string messageText, DateTime timeStamp)
		{
			UserName = userName;
			MessageText = messageText;
			TimeStamp = timeStamp;
		}

		public override string? ToString()
		{
			return $"{UserName} <{TimeStamp}>: {MessageText}";
		}
	}
}
