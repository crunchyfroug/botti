using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BotApp
    {
    class App
        {
        AddRestaurant add = new AddRestaurant();
        GetData data = new GetData();
        public void RunApp ()
            {

            List<string> names = new List<string>();
            List<string> meals = new List<string>();
            List<string> address = new List<string>();

            string html = null;
            html = data.SearchData(html);

            add._AddRestaurant(names, meals, address, html);
            
        }

        }
    }
