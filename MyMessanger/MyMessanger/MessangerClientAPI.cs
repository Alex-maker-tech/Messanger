using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using MyMessanger;
using ASPCoreServer;
using MessangerAPI;

namespace Messanger
{
	public class MessangerClientAPI
	{
		private static readonly HttpClient client = new HttpClient();
		private static string SiteName = "http://localhost:5000/";
		// http://www.alex-messanger.somee.com/
		// http://alexandrmaker-001-site1.ctempurl.com/ - не актуально
		// http://alexmaker09-001-site1.gtempurl.com/


		//! GET
		public List<Message>? GetMessages(int MessagesId)
		//! УСТАРЕВШИЙ МЕТОД
		{
			WebRequest request = WebRequest.Create($"{SiteName}api/Messanger/" + MessagesId.ToString());
			request.Method = "GET";
			WebResponse response = request.GetResponse();
			string status = ((HttpWebResponse)response).StatusDescription;

			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			reader.Close();
			dataStream.Close();
			response.Close();
			
			if ((status.ToLower() == "ok") && (responseFromServer != "Not found"))
			{
				List<Message> msgs = JsonConvert.DeserializeObject<List<Message>>(responseFromServer);
				return new List<Message>();
			}
			return null;
		}

		public async Task<List<Message>> GetMessagesHTTPAsync(int MessageId)
		//! АКТУАЛЬНЫЙ МЕТОД
		{
			var responseString = await client.GetStringAsync($"{SiteName}api/Messanger/messages/" + MessageId.ToString());
			if (responseString != null)
			{
				List<Message> msgs = JsonConvert.DeserializeObject<List<Message>>(responseString);
				return msgs;
			}
			return null;
		}

		public int GetMsgCount()
		//! УСТАРЕВШИЙ МЕТОД
		{
			WebRequest request = WebRequest.Create($"{SiteName}api/Messanger/get-msg-count");
			request.Method = "GET";
			WebResponse response = request.GetResponse();
			string status = ((HttpWebResponse)response).StatusDescription;

			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			reader.Close();
			dataStream.Close();
			response.Close();

			if (status.ToLower() == "ok")
			{
				return Convert.ToInt32(responseFromServer);
			}
			return -1;
		}


		//! POST
		public async Task<bool> SendMessageAsync(Message msg)
		{
			string postData = JsonConvert.SerializeObject(msg);
			var data = new StringContent(postData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger", data);
			var result = response.StatusCode;

			if (result == HttpStatusCode.OK)
			{
				return true;
			}
			else return false;
		}

		public async Task<int> LoginAsync(UserData userData)
		{
			var json = JsonConvert.SerializeObject(userData);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger/login", data);
			var result = response.StatusCode;
			string resp;
			using (var res = response.Content.ReadAsStream())
			{
				StreamReader reader = new StreamReader(res);
				resp = reader.ReadToEnd();
				reader.Close();
			}

			if (result == HttpStatusCode.OK)
			{
				return Convert.ToInt32(resp);
			}
			else return -1;
		}

		public async Task<int> RegisterAsync(UserData userData)
		{
			var json = JsonConvert.SerializeObject(userData);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger/register", data);
			var result = response.StatusCode;
			string resp;
			using (var res = response.Content.ReadAsStream())
			{
				StreamReader reader = new StreamReader(res);
				resp = reader.ReadToEnd();
				reader.Close();
			}

			if (result == HttpStatusCode.OK)
			{
				return Convert.ToInt32(resp);
			}
			else return -1;
		}

		public async Task<bool> LogoutAsync(UserData userData)
		{
			var json = JsonConvert.SerializeObject(userData);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger/logout", data);
			var result = response.StatusCode;

			if (result == HttpStatusCode.OK)
			{
				return true;
			}
			else return false;
		}
	}
}
