﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApp
    {
    public class Restaurants
        {
        public string Nimi;
        public string Ateriat;
        public string Osoite;


        public Restaurants (string nimi, string ateriat, string osoite)
            {
            this.Nimi = nimi;
            this.Ateriat = ateriat;
            this.Osoite = osoite;
            }
        }
    }
