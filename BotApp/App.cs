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
    class App
        {
        AddRestaurant add = new AddRestaurant();
        GetData data = new GetData();
        Lists lists = new Lists();
        
        public void RunApp ()
            {


            //add try, catch (argumentnullexception)
            string html = null;
            try
                {
                html = null;
                html = data.SearchData(html);

                }
                catch {
                
                throw new ArgumentNullException(nameof(html), "Didn't return any value");
                
                
                }

            add._AddRestaurant(lists.Names, lists.Meals, lists.Address, html);
            
        }

        }
    }
