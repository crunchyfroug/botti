using System;
using System.Collections.Generic;
using BotApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotTests
    {
    [TestClass]
    public class AddRestaurant_Test
        {
        [TestMethod]
        public void Test_AddRestaurant_ReturnValuesToLists ()
            {
            var getdata = new GetData();

            string url = "https://www.lounaat.info/jyvaskyla";

            var html = "";
            html = getdata.SearchData(html, url);
            //arrange
            var result ="";

            //act
            //result = addrestaurant._AddRestaurant()

            //assert


            }
        }
    }
