using Microsoft.AspNetCore.Mvc;

using MyMessanger;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Messanger : ControllerBase
	{
		public static List<Message> ListOfMessages = new List<Message>();
		public static List<UserData> ListOfUsers = new List<UserData>();

		// GET api/<Messanger>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			string OutputString = "Not found";
			if ((id < ListOfMessages.Count) && (id >= 0))
			{
				OutputString = JsonConvert.SerializeObject(ListOfMessages[id]);
			}
			Console.WriteLine($"Запрошено сообщение № {id}: {OutputString}");
			return OutputString;
		}

		// GET api/Messanger/get-msg-count
		[HttpGet("get-msg-count")]
		public int GetMsgCount()
		{
			return ListOfMessages.Count;
		}

		// POST api/<Messanger>
		[HttpPost]
		public IActionResult SendMessage([FromBody] Message msg)
		{
			if (msg == null)
			{
				return BadRequest();
			}

			using (StreamWriter writer = new StreamWriter(Program.MessagesDataFile, true))
			{
				writer.WriteLine(JsonConvert.SerializeObject(msg));
			}

			ListOfMessages.Add(msg);
			Console.WriteLine($"Всего сообщений: {ListOfMessages.Count} Посланное сообщение: {msg}");

			return new OkResult();
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			for (int i = 0; i < ListOfUsers.Count; ++i)
			{
				UserData user = ListOfUsers[i];
				if ((user.UserName == userData.UserName) && (user.Password == userData.Password))
				{
					Message hello = new Message("Server", $"{userData.UserName} joined the messanger", DateTime.Now);

					using (StreamWriter writer = new StreamWriter(Program.MessagesDataFile, true))
					{
						writer.WriteLine(JsonConvert.SerializeObject(hello));
					}

					ListOfMessages.Add(hello);
					return new OkResult();
				}
			}

			return BadRequest();
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			for (int i = 0; i < ListOfUsers.Count; ++i)
			{
				UserData user = ListOfUsers[i];
				if ((user.UserName == userData.UserName) && (user.Password == userData.Password))
				{
					return BadRequest();
				}
			}

			using (StreamWriter writer = new StreamWriter(Program.UsersDataFile, true))
			{
				writer.WriteLine(JsonConvert.SerializeObject(userData));
			}

			Message hello = new Message("Server", $"{userData.UserName} joined the messanger for the first time", DateTime.Now);

			using (StreamWriter writer = new StreamWriter(Program.MessagesDataFile, true))
			{
				writer.WriteLine(JsonConvert.SerializeObject(hello));
			}

			ListOfUsers.Add(userData);
			ListOfMessages.Add(hello);
			Console.WriteLine($"Добавлен новый пользователь: {userData}");

			return new OkResult();
		}

		[HttpPost("logout")]
		public IActionResult Logout([FromBody] UserData userData)
		{
			if (userData == null)
			{
				return BadRequest();
			}

			for (int i = 0; i < ListOfUsers.Count; ++i)
			{
				UserData user = ListOfUsers[i];
				if ((user.UserName == userData.UserName) && (user.Password == userData.Password))
				{
					Message goodbye = new Message("Server", $"{userData.UserName} left the messanger", DateTime.Now);

					using (StreamWriter writer = new StreamWriter(Program.MessagesDataFile, true))
					{
						writer.WriteLine(JsonConvert.SerializeObject(goodbye));
					}

					ListOfMessages.Add(goodbye);
					return new OkResult();
				}
			}

			return BadRequest();
		}
	}
}
