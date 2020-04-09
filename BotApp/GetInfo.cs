using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotApp
    {
    public class GetInfo
        {
        ParseHTML parse = new ParseHTML();

        public List<string> ReturnMeal (List<string> meals, Match htmlMatch)
            {
            string meal = parse.MenuItem(htmlMatch.Value);
            meals.Add(meal);
            return meals;
            }

        public List<string> ReturnName (List<string> names, Match htmlMatch)
            {
            string name = parse.Name(htmlMatch.Value);
            names.Add(name);
            return names;
            }
        public List<string> ReturnAddress (List<string> addresses, Match htmlMatch)
            {
            string address = parse.Address(htmlMatch.Value);
            addresses.Add(address);
            return addresses;
            }

        }
    }
