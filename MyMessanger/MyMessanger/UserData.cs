namespace ASPCoreServer
{
	[Serializable]
	public class UserData
	{
		public int? UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

		public UserData()
		{
			UserId = null;
			UserName = "user";
			Password = "password";
		}

		public UserData(string userName, string password)
		{
			UserId = null;
			UserName = userName;
			Password = password;
		}

		public UserData(int id, string username, string password)
		{
			UserId = id;
			UserName = username;
			Password = password;
		}

		public override string? ToString()
		{
			return $"\"{UserName}\" #{UserId} : {Password}";
		}
	}
}
