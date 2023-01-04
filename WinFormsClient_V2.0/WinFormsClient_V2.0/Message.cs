﻿namespace MessangerAPI
{
	[Serializable]
	public class Message
	{
		public string? UserName { get; set; }
		public int UserId { get; set; }	
		public int?  RecipientId { get; set; }
		public string MessageText { get; set; }
		public DateTime TimeStamp { get; set; }

		public Message()
		{
			UserName = "System";
			UserId = 0;
			RecipientId = null;
			MessageText = "Server is running...";
			TimeStamp = DateTime.Now;
		}

		public Message(string userName, int userid, int? recipientid, string messageText, DateTime timeStamp)
		{
			UserName = userName;
			UserId = userid;
			RecipientId = recipientid;
			MessageText = messageText;
			TimeStamp = timeStamp;
		}

		public Message(string userName, int userid, int? recipientid, string messageText)
		{
			UserName = userName;
			UserId = userid;
			RecipientId = recipientid;
			MessageText = messageText;
			TimeStamp = DateTime.Now;
		}

		public Message(int userid, string messageText, DateTime timeStamp)
		{
			UserName = null;
			UserId = userid;
			RecipientId = 0;
			MessageText = messageText;
			TimeStamp = timeStamp;
		}

		public override string? ToString()
		{
			return $"{UserName}({UserId}) to {RecipientId} <{TimeStamp}>: {MessageText}";
		}
	}
}
