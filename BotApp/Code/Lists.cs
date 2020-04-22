using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApp
    {
    public class Lists
        {
        private List<string> names = new List<string>();
        private List<string> meals = new List<string>();
        private List<string> address = new List<string>();

        public List<string> Names
            {
            get => names;
            set => names = value;
            }
        public List<string> Meals
            {
            get => meals;
            set => meals = value;
            }
        public List<string> Address
            {
            get => address;
            set => address = value;
            }
        }
    }
