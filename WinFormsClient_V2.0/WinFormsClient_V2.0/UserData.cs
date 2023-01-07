namespace MessangerAPI
{
	[Serializable]
	public class UserData
	{
		public string? UserName { get; set; }
		public int? UserId { get; set; }
		public string? Password { get; set; }

		public bool? IsOnline { get; set; }

		public UserData()
		{
			UserName = "user";
			UserId = null;
			Password = "password";
			IsOnline = false;
		}

		public UserData(int? userId, bool isonline)
		{
			UserName = null;
			UserId = userId;
			Password = null;
			IsOnline = isonline;
		}

		public UserData(string userName, string password)
		{
			UserName = userName;
			UserId = null;
			Password = password;
			IsOnline = false;
		}

		public UserData(int? userId, string userName, string password)
		{
			UserName = userName;
			UserId = userId;
			Password = password;
			IsOnline = false;
		}

		public UserData(int? userId, string userName, string password, bool isonline)
		{
			UserName = userName;
			UserId = userId;
			Password = password;
			IsOnline = isonline;
		}

		public override string? ToString() => $"\"{UserName}\" #{UserId} : {Password}";
		
	}
}
