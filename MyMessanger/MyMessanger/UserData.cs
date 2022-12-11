namespace ASPCoreServer
{
	[Serializable]
	public class UserData
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public UserData()
		{
			UserName = "user";
			Password = "password";
		}

		public UserData(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}

		public override string? ToString()
		{
			return $"\"{UserName}\": {Password}";
		}
	}
}
