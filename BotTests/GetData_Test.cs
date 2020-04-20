using System;
using BotApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotTests
    {
    [TestClass]
    public class GetData_Test
        {
        [TestMethod]
        public void SearchData_ReturnHtml ()
            {
            //arrange

            var result = "";
            var getData = new GetData();


            //act
            result = getData.SearchData(result);

            //assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            }
        }
    }