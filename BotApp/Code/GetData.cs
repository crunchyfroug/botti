﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace BotApp
	{
	public class GetData
		{
		public string SearchData (string data, string url)
			{
			using (WebClient client = new WebClient())
				{
				client.UseDefaultCredentials = true;
				client.Headers.Add("User-Agent: Other");
				string html = client.DownloadString(url);

				//poistetaan välit + lisätään UTF-8
				html = Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1");
				byte[] bytes = Encoding.Default.GetBytes(html);
				data = Encoding.UTF8.GetString(bytes);
				}
			return data;
			}
		}
	}
