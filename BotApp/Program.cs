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
		// datan kerääminen
		static string GetData (string data)
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
				};
			return data;
			}
		// ottaa talteen paikkojen nimet listaan

		static List<string> GetNames (Match data, List<string> namesList)
			{
			string pattern = "<h3.*?>(.*?)<\\/h3>";
			data = Regex.Match(data.Value, pattern);
			string name;
			namesList = new List<string>();
				name = data.Value;
				name = Regex.Replace(name, "<.*?>", String.Empty);
				namesList.Add(name);
			return namesList;
			}

		// kerää kaikki osoitteet listaan
		static List<string> GetAddress (Match data, List<string> addressList)
			{
			string pattern = "<p[^>] *class=\"dist.*?\"(.*?)>";
			string address;
			addressList = new List<string>();
			Match match = Regex.Match(data.Value, pattern);

				address = match.Value;
				address = Regex.Replace(address, "<p class=\"dist\" title=\"", String.Empty);
				address = Regex.Replace(address, "\">", String.Empty);
				addressList.Add(address);
				
			return addressList;
			}

			//kerää ateriat
		static List<string> GetMeals (Match data, List<string> mealList)
			{
			string pattern = "<li [^>]*class=\"menu-ite.*?\"(.*?)</div>";
			string meal;
			Match match = Regex.Match(data.Value, pattern);
			mealList = new List<string>();

				meal = match.Value;
				meal = meal.Replace("<p class=\"dish\">", "\n");
				meal = Regex.Replace(meal, "<.*?>", "");
			meal = meal.Replace("l ", " Laktoositon, ")
			.Replace("g ", "Gluteeniton, ").Replace("m ", "Maidoton, ")
			;
			mealList.Add(meal);
			return mealList;
			}

		static List<Restaurants> RestaurantList = new List<Restaurants>();

		//lisää kaikkien ravintoloiden tiedot yhteen listaan
		static void AddRestaurant (List<string> name, List<string> meals, List<string> address, string data)
			{
			Restaurants restaurant;
			string pattern = "<div [^>]*class=\"menu item.*?\"(.*?)</div></div>" +
			"<div [^>]*class=\"item.*?\"(.*?)</div><div [^>]*class=\"item.*?\"(.*?)</div>";

			MatchCollection matches = Regex.Matches(data, pattern);
			foreach (Match m in matches)
				{
				int i = 0;
				name = GetNames(m, name);
				meals = GetMeals(m, meals);
				address = GetAddress(m, address);

				restaurant = new Restaurants(name[i], meals[i], address[i]);
				RestaurantList.Add(restaurant);
				i++;
				}
			}

		static void Main (string[] args)
			{
			List<string> addressList = new List<string>();
			List<string> nameList = new List<string>();
			List<string> mealList = new List<string>();
			string data = null;
			data = GetData(data);

			AddRestaurant(nameList, mealList, addressList, data);

			Console.ReadKey();
		}
	}
}