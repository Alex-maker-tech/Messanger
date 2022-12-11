using Newtonsoft.Json;
using MyMessanger;

namespace ASPCoreServer
{
	public class Program
	{
		public static string UsersDataFile = "users.txt";
		public static string MessagesDataFile = "messages.txt";

		public static void Main(string[] args)
		{
			if (!File.Exists(UsersDataFile))
				File.Create(UsersDataFile);
			if (!File.Exists(MessagesDataFile))
				File.Create(MessagesDataFile);

			using (StreamReader reader = new StreamReader(UsersDataFile))
			{
				string? line;
				while ((line = reader.ReadLine()) != null)
				{
					Controllers.Messanger.ListOfUsers.Add(JsonConvert.DeserializeObject<UserData>(line));
				}
			}

			using (StreamReader reader = new StreamReader(MessagesDataFile))
			{
				string? line;
				while ((line = reader.ReadLine()) != null)
				{
					Controllers.Messanger.ListOfMessages.Add(JsonConvert.DeserializeObject<Message>(line));
				}
			}


			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}