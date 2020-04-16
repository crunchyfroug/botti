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
        Lists lists = new Lists();
        public void RunApp ()
            {

            string html = null;
            html = data.SearchData(html);

            add._AddRestaurant(lists.names, lists.meals, lists.address, html);
            
        }

        }
    }
