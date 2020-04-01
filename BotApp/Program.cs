using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace BotApp
{
	class Program
{
		public static string GetData (string data)
			{
			string urlAddress = "https://www.lounaat.info/jyvaskyla";
			using (WebClient client = new WebClient())
				{
				client.UseDefaultCredentials = true;
				client.Headers.Add("User-Agent: Other");
				string html = client.DownloadString(urlAddress);
				byte[] bytes = Encoding.Default.GetBytes(html);
				data = Encoding.UTF8.GetString(bytes);
				};
			return data;
			}
		public static MatchCollection GetMatches (MatchCollection matchCollection, string data, string pattern)
			{
			matchCollection = Regex.Matches(data, pattern);
			Console.WriteLine("Matches found: {0}", matchCollection.Count);
			return matchCollection;
			}

		public static string Osoite (string osoite, string data, string pattern, MatchCollection match)
			{
			match = Regex.Matches(data, pattern);
			foreach (Match m in match)
				{
				osoite = m.Groups[1].Value;
				osoite = osoite.Replace("title=\"", "");
				osoite = osoite.Replace("\">", "");
				osoite = Regex.Replace(osoite, "<.*?>", ",");
				Console.WriteLine(osoite);
				Console.WriteLine();
				}
			return osoite;
			}
		public List<Ravintolat> RavintolaList = new List<Ravintolat>();
		public List<Ravintolat> LisaaRavintola(string nimi, string ateriat, string osoite)
			{
			
			Ravintolat ravintola;
			try
				{
				ravintola = new Ravintolat(nimi, ateriat, osoite);
				RavintolaList.Add(ravintola);
				return RavintolaList;
				}
			catch (System.IO.IOException e)
				{
				Console.WriteLine(e);
				return null;
				}
			finally
				{
				
				}

			}
		static void Main(string[] args)
		{
			string data = null;
			
			data = GetData(data);
			string p_pattern = "<p[^>] *class=\"dist.*?\"(.*?)</p>";
			//string div_pattern = "<div.*?>(.*?)<\\/div>";
			//string body_pattern = "<div [^>] *class=\"item-body*?\"(.*?)</div>";
			//string item_pattern = "<div [^>]*class=\"menu item.*?\"(.*?)</div>";

			//kerää koko html-tiedostosta tietyt osiot patternin mukaan
			Console.WriteLine();
			MatchCollection matches = Regex.Matches(data, p_pattern);
			Console.WriteLine("Matches found: {0}", matches.Count);
			if (matches.Count > 0)
			{
				//string pattern2 = "<p [^>]*class=\"dish\"(.*?)</p>";
				foreach (Match m in matches)
				{
					var osoite = m.Groups[1].Value;
					osoite = osoite.Replace("title=\"", "");
					osoite = osoite.Replace("\">", "");
					osoite = Regex.Replace(osoite, "<.*?>", ",");
					Console.WriteLine(osoite);
					Console.WriteLine();

					
				}
				// tallentaa jokaisen paikan, aterian ja osoitteen listaan
				// Ravintolat ravintola = new Ravintolat("","",osoite);

				//for (int i = 0 ; i < matches.Count ; i++)
				//	{
				//	Console.WriteLine();
				//	Console.WriteLine();
				//	Console.WriteLine(ruokalistat[i]);
				//	}
				/*string html = string.Join("",ruokalistat.ToArray());
				MatchCollection matches2 = Regex.Matches(html, pattern2);
				if (matches2.Count > 0)
				{
					foreach(Match x in matches2)
					{
					//Console.WriteLine();
					//Console.WriteLine("{0}", x.Groups[1]);
					}
				}*/




				}
			Console.WriteLine();
			Console.ReadKey();
		}
	}
}