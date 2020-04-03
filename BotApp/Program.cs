using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;

namespace BotApp
{
	class Program
		{
		// datan kerääminen
		static string GetData (string data)
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
		// ottaa talteen paikkojen nimet listaan

			static List<string> GetNames (string data, List<string> nimet)
			{
			string pattern = "<h3.*?>(.*?)<\\/h3>";
			string nimi;
			nimet = new List<string>();
			MatchCollection match = Regex.Matches(data, pattern);
				foreach (Match m in match)
					{
					nimi = m.Groups[1].Value;
					nimi = Regex.Replace(nimi, "<.*?>", String.Empty);
					nimet.Add(nimi);
					}
			return nimet;
			}

		// kerää kaikki osoitteet listaan
		static List<string> GetAddress (string data, List<string> addresses)
			{
			string pattern = "<p[^>] *class=\"dist.*?\"(.*?)>";
			string address;
			addresses = new List<string>();
			MatchCollection match = Regex.Matches(data, pattern);
			Console.WriteLine("{0} matches found", match.Count);
			foreach (Match m in match)
				{
				address = m.Groups[1].Value;
				address = address.Replace(" " + "title=\"", "").Replace("\"", "");
				address = Regex.Replace(address, "<.*?>", ",");
				addresses.Add(address);
				}
			return addresses;
			}
		static List<string> GetMeals (string data, List<string> mealList)
			{
			string pattern = "<li [^>]*class=\"menu-ite.*?\"(.*?)</div>";
			string meal;
			MatchCollection match = Regex.Matches(data, pattern);
			

			foreach (Match m in match)
				{
				meal = m.Groups[1].Value;
				meal = meal.Replace("<p class=\"dish\">", "\n");
				meal = Regex.Replace(meal, "<.*?>", "");
				meal = meal.Replace(">", "").Replace(" l ", "Laktoositon, ")
				.Replace(" g ", "Gluteeniton, ").Replace(" m ", "Maidoton, ")
				;
				Console.WriteLine(meal);
				mealList.Add(meal);
				Console.WriteLine();
				Console.WriteLine();
				}

			return mealList;
			}
		static List<Ravintolat> RestaurantList = new List<Ravintolat>();

		// lisää ravintolat listaan
		static void AddRestaurant(List<string> name, List<string> meals, List<string> address)
			{
			
			Ravintolat restaurant;
			try
				{
				for (int i = 0 ; i < name.Count || i < meals.Count || i< address.Count ;)
					{
					restaurant = new Ravintolat(name[i], meals[i], address[i]);
					RestaurantList.Add(restaurant);
					i++;
					}
				}
			catch (System.IO.IOException e)
				{
				Console.WriteLine(e);
				}
			finally
				{
				
				}

			}
		static void Main(string[] args)
		{
			List<string> addressList = new List<string>();
			List<string> nameList = new List<string>();
			List<string> mealList = new List<string>();
			string data = null;

			//string div_pattern = "<div.*?>(.*?)<\\/div>";
			//string body_pattern = "<div [^>]*class=\"item-body*?\"(.*?)</div>";
			//string item_pattern = "<div [^>]*class=\"menu item.*?\"(.*?)</div>";
			//string dish_pattern = "<p [^>]*class=\"dish\"(.*?)</p>";
			data = GetData(data);

			//addressList = GetAddress(data, addressList);
			//nameList = GetNames(data, nameList);
			mealList = GetMeals(data, mealList);
			addressList = GetAddress(data, addressList);
			nameList = GetNames(data, nameList);

			AddRestaurant(nameList, mealList, addressList);
			//kerää koko html-tiedostosta tietyt osiot patternin mukaan

			// tallentaa jokaisen paikan, aterian ja osoitteen listaan

			Console.WriteLine();
			Console.ReadKey();
		}
	}
}