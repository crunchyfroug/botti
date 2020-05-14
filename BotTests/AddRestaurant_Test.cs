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
            var lists = new Lists();
            var getData = new GetData();
            var addRestaurant = new AddRestaurant();
            int i = 0;
            string url = "https://www.lounaat.info/jyvaskyla";

            var html = "";
            html = getData.SearchData(html, url);


            addRestaurant._AddRestaurant(lists.Names, lists.Meals, lists.Address, html);


            foreach(var item in addRestaurant.restaurantList)
                {
                if (i >= 1)
                    {
                    Assert.AreNotEqual(lists.Names[i - 1], lists.Names[i]);
                    Assert.AreNotEqual(lists.Meals[i - 1], lists.Meals[i]);
                    }
                Assert.IsNotNull(lists.Names[i]);
                Assert.IsNotNull(lists.Meals[i]);
                Assert.IsNotNull(lists.Address[i]);

                i++;
                }
            }

        [TestMethod]
        public void Test_AddRestaurant_ListsAreEmpty ()
            {
            var lists = new Lists();
            var addRestaurant = new AddRestaurant();
            var html = "";
            int i = 0;


            addRestaurant._AddRestaurant(lists.Names, lists.Meals, lists.Address, html);

            foreach (var item in addRestaurant.restaurantList)
                {

                Assert.IsNull(lists.Names[i]);
                Assert.IsNull(lists.Meals[i]);
                Assert.IsNull(lists.Address[i]);
                i++;
                }
            }

        }
    }
