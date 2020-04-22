using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BotApp
    {

    public class AddRestaurant
        {
		public List<Restaurants> restaurants = new List<Restaurants>();
		GetInfo info = new GetInfo();
        public void _AddRestaurant (List<string> name, List<string> meals, List<string> address, string data)
            {
			
			Restaurants restaurant;
			string pattern = "<div [^>]*class=\"menu item.*?\"(.*?)</div></div>" +
			"<div [^>]*class=\"item.*?\"(.*?)</div><div [^>]*class=\"item.*?\"(.*?)</div>";

			MatchCollection matches = Regex.Matches(data, pattern);
			int i = 0;
			foreach (Match m in matches)
				{
				name = info.ReturnName(name,m);
				meals = info.ReturnMeal(meals, m);
				address = info.ReturnAddress(address, m);

				restaurant = new Restaurants(name[i], meals[i], address[i]);
				restaurants.Add(restaurant);
				i++;
				}
			}
        }
    }
