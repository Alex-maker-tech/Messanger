﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using ASPCoreServer;

namespace Messanger
{
	public class MessangerClientAPI
	{
		private static readonly HttpClient client = new HttpClient();
		private static string SiteName = "http://alexmaker09-001-site1.gtempurl.com/";
		// http://www.alex-messanger.somee.com/
		// http://alexandrmaker-001-site1.ctempurl.com/ - не актуально
		// http://alexmaker09-001-site1.gtempurl.com/

		public void TestNewtonsoftJson()
		{
			Message msg = new Message("Alex", "Hello World!", DateTime.UtcNow);
			string output = JsonConvert.SerializeObject(msg);
			Console.WriteLine(output);
			Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
			Console.WriteLine(deserializedMsg);
		}

		//! GET
		public Message GetMessage(int MessageId)
		{
			WebRequest request = WebRequest.Create($"{SiteName}api/Messanger/" + MessageId.ToString());
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
				Message deserializedMessage = JsonConvert.DeserializeObject<Message>(responseFromServer);
				return deserializedMessage;
			}
			return null;
		}
		public async Task<Message> GetMessageHTTPAsync(int MessageId)
		{
			var responseString = await client.GetStringAsync($"{SiteName}api/Messanger/" + MessageId.ToString());
			if (responseString != null)
			{
				Message? message = JsonConvert.DeserializeObject<Message>(responseString);
				return message;
			}
			return null;
		}
		public int GetMsgCount()
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

		public async Task<bool> LoginAsync(UserData userData)
		{
			var json = JsonConvert.SerializeObject(userData);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger/login", data);
			var result = response.StatusCode;

			if (result == HttpStatusCode.OK)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> RegisterAsync(UserData userData)
		{
			var json = JsonConvert.SerializeObject(userData);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"{SiteName}api/Messanger/register", data);
			var result = response.StatusCode;

			if (result == HttpStatusCode.OK)
			{
				return true;
			}
			else return false;
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
