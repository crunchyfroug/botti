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
            string urladdress = "https://www.lounaat.info/jyvaskyla";
            var result = "";
            var getData = new GetData();


            result = getData.SearchData(result, urladdress);

            Assert.IsNotNull(result);
            }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
        "Code returns null")]
        public void SearchData_DoesntReturnAnyValue ()
            {
            var app = new App();
            app.urladdress = "";
            app.RunApp();
            }
        }
    }