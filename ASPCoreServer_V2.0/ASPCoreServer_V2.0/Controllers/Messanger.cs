using Microsoft.AspNetCore.Mvc;

using MessangerAPI;
using Microsoft.Data.Sqlite;
using System.Reflection.PortableExecutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer_V2._0.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Messanger : ControllerBase
	{
		public static string connectionString = "Data Source=users.db;Mode=ReadWrite;Foreign Keys=true;";


		// GET api/<Messanger>/messages/5
		[HttpGet("messages/{id}")]
		public List<Message> GetMessages(int id)
		{
			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();
				SqliteCommand command = new SqliteCommand($"SELECT Id, UserId, MessageText, TimeStamp FROM Messages Where RecipientId = @id OR RecipientId IS NULL", db);
				SqliteParameter param = new SqliteParameter { ParameterName = "@id", Value = id, SqliteType = SqliteType.Integer };
				command.Parameters.Add(param);
				var reader = command.ExecuteReader();

				List<Message> messages = new List<Message>();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Message message = new Message(reader.GetInt32(0), reader.GetInt32(1), id, reader.GetString(2), reader.GetDateTime(3));
						messages.Add(message);
					}
				}

				return messages;
			}
		}

		// GET api/<Messanger>/users/5
		[HttpGet("users/{id}")]
		public string GetUserName(int id)
		{
			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();
				SqliteCommand command = new SqliteCommand($"SELECT UserName, Id FROM Users Where Id = @id", db);
				SqliteParameter param = new SqliteParameter { ParameterName = "@id", Value = id, SqliteType = SqliteType.Integer };
				command.Parameters.Add(param);
				var reader = command.ExecuteReader();

				string username = "null";
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						username = reader.GetString(0);

					}
				}

				return username;
			}
		}

		// POST api/<Messanger>
		[HttpPost]
		public IActionResult SendMessage([FromBody] Message msg)
		{
			if (msg == null)
			{
				return BadRequest();
			}

			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();

				SqliteCommand command = new SqliteCommand($"INSERT INTO Messages (UserId, RecipientId, MessageText) VALUES (@id, @r_id, @msg)", db);
				SqliteParameter param1 = new SqliteParameter { ParameterName = "@id", Value = msg.UserId, SqliteType = SqliteType.Integer },
					param2 = new SqliteParameter { ParameterName = "@r_id", Value = msg.RecipientId, SqliteType = SqliteType.Integer },
					param3 = new SqliteParameter { ParameterName = "@msg", Value = msg.MessageText, SqliteType = SqliteType.Text };
				command.Parameters.AddRange(new SqliteParameter[]{param1, param2, param3});
				var res = command.ExecuteNonQuery();

				if (res == 1) return new OkResult();
			}

			return BadRequest();
		}

		// POST api/<Messanger>/login
		[HttpPost("login")]
		public IActionResult Login([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();

				SqliteCommand command = new SqliteCommand($"SELECT Id, IsOnline FROM Users WHERE UserName = @username AND Password = @password", db);
				SqliteParameter param1 = new SqliteParameter { ParameterName = "@username", Value = userData.UserName, SqliteType = SqliteType.Text },
					param2 = new SqliteParameter { ParameterName = "@password", Value = userData.Password, SqliteType = SqliteType.Text, Size = 4 };
				command.Parameters.AddRange(new SqliteParameter[] { param1, param2 });
				var reader = command.ExecuteReader();

				List<UserData> users = new List<UserData>();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						users.Add(new UserData(reader.GetInt32(0), reader.GetBoolean(1)));
					}
				}
				reader.Close();

				if (users.Count != 1)
					return BadRequest();
				else
				{
					if (users[0].IsOnline == false) users[0].IsOnline = true;

					command = new SqliteCommand($"UPDATE Users SET IsOnline = true WHERE Id = @id", db);
					SqliteParameter param = new SqliteParameter { ParameterName = "@id", Value = users[0].UserId, SqliteType = SqliteType.Integer };
					command.Parameters.Add(param);
					var res = command.ExecuteNonQuery();

					if (res == 1) return new OkObjectResult(users[0].UserId);
				}
			}
			return BadRequest();
		}

		// POST api/<Messanger>/register
		[HttpPost("register")]
		public IActionResult Register([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();

				SqliteCommand command = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE UserName = @username AND Password = @password", db);
				SqliteParameter param = new SqliteParameter { ParameterName = "@username", Value = userData.UserName, SqliteType = SqliteType.Text }, 
					param2 = new SqliteParameter { ParameterName = "@password", Value = userData.Password, SqliteType = SqliteType.Text };
				command.Parameters.AddRange(new SqliteParameter[] { param, param2 });
				int res = Convert.ToInt32(command.ExecuteScalar());

				if (res != 0) return BadRequest();
				else
				{
					command = new SqliteCommand("INSERT INTO Users(UserName, Password, IsOnline) VALUES (@username, @password, @isonline)", db);
					command.Parameters.AddRange(new SqliteParameter[] { param, param2, new SqliteParameter { ParameterName = "@isonline", Value = true, SqliteType = SqliteType.Integer } });
					res = command.ExecuteNonQuery();

					if (res == 1)
					{
						command = new SqliteCommand("SELECT Id FROM Users WHERE UserName = @username AND Password = @password", db);
						command.Parameters.AddRange(new SqliteParameter[] { param, param2 });
						var reader = command.ExecuteReader();

						int id = -1;
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								id = reader.GetInt32(0);
							}
						}

						if (id != -1) return new OkObjectResult(id);
						else return BadRequest();
					}
					else return BadRequest();
				}
			}
		}

		// POST api/<Messanger>/logout
		[HttpPost("logout")]
		public IActionResult Logout([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			using (var db = new SqliteConnection(connectionString))
			{
				db.Open();

				SqliteCommand command = new SqliteCommand("SELECT IsOnline FROM Users WHERE Id = @id", db);
				SqliteParameter param = new SqliteParameter { ParameterName = "@id", Value = userData.UserId, SqliteType = SqliteType.Integer };
				command.Parameters.Add(param);
				var reader = command.ExecuteReader();

				bool isonline = false;
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						isonline = reader.GetBoolean(0);
					}
				}

				if (isonline == true)
				{
					isonline = false;

					command = new SqliteCommand($"UPDATE Users SET IsOnline = @isonline WHERE Id = @id", db);
					SqliteParameter param1 = new SqliteParameter { ParameterName = "@id", Value = userData.UserId, SqliteType = SqliteType.Integer },
						param2 = new SqliteParameter { ParameterName = "@isonline", Value = isonline, SqliteType = SqliteType.Integer };
					command.Parameters.AddRange(new SqliteParameter[] {param1, param2});
					var res = command.ExecuteNonQuery();

					if (res == 1) return new OkResult();
				}
			}
			return BadRequest();
		}

	}
}
