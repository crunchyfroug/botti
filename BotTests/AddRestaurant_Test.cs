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
            //arrange
            var lists = new Lists();
            var getData = new GetData();
            var addRestaurant = new AddRestaurant();
            List<Restaurants> restaurantList = new List<Restaurants>();
            int i = 0;
            string url = "https://www.lounaat.info/jyvaskyla";

            var html = "";
            html = getData.SearchData(html, url);

            //act

            addRestaurant._AddRestaurant(lists.Names, lists.Meals, lists.Address, html);

            //result = addrestaurant._AddRestaurant()

            //assert
            foreach(var item in restaurantList)
                {
                Assert.IsNotNull(lists.Names[i]);
                Assert.IsNotNull(lists.Meals[i]);
                Assert.IsNotNull(lists.Address[i]);

                Assert.AreNotEqual("", lists.Names[i]);
                Assert.AreNotEqual("", lists.Meals[i]);
                Assert.AreNotEqual("", lists.Address[i]);
                i++;
                }


            }
        }
    }
