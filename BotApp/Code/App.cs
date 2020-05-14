using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BotApp
    {
    public class App
        {
        AddRestaurant add = new AddRestaurant();
        GetData data = new GetData();
        Lists lists = new Lists();
        public string urladdress = "https://www.lounaat.info/jyvaskyla";
        public void RunApp ()
            {


            //add try, catch (argumentnullexception)
            var html = "";
            try
                {
                html = null;
                html = data.SearchData(html,urladdress);

                }
                catch {
                
                throw new ArgumentNullException(nameof(html), "Didn't return any value");
                
                
                }
            int i = 1;
            add._AddRestaurant(lists.Names, lists.Meals, lists.Address, html);
            foreach (var item in add.restaurantList)
                {
                
                }
            
        }

        }
    }
