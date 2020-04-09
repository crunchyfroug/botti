using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace BotApp
	{
	class GetData
		{
		public string SearchData (string data)
			{
			string urlAddress = "https://www.lounaat.info/jyvaskyla";
			using (WebClient client = new WebClient())
				{
				client.UseDefaultCredentials = true;
				client.Headers.Add("User-Agent: Other");
				string html = client.DownloadString(urlAddress);

				//poistetaan välit + lisätään UTF-8
				html = Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1");
				byte[] bytes = Encoding.Default.GetBytes(html);
				data = Encoding.UTF8.GetString(bytes);
				}
			return data;
			}
		}
	}
