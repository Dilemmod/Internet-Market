using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetMarket;
using System.Linq;

namespace InternetMarketUnitTest
{
    [TestClass]
    public class AdminFormTests
    {
        [TestMethod]
        public void CheckUser_Cezar_Dnepr_38095423234_returnedTrue()
        {
            //arrenge
            string FuullName = "Цезарь, Гриша, Александровичь", Addres = "Днепр, Шевченка 5, 50", PhoneNumber = "38093453457";
            bool expected = true;
            //act
            AdminForm aF = new AdminForm();
            bool actual = aF.CheckUser(FuullName, Addres, PhoneNumber);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckUser_Cezar_Dnepr_380954sdf23234_returnedFalse()
        {
            //arrenge
            string FuullName = "Цезарь,Гриша, Александровичь", Addres = "Днепр, Шевченка 5, 50", PhoneNumber = "38093asda453457";
            bool expected = false;
            //act
            AdminForm aF = new AdminForm();
            bool actual = aF.CheckUser(FuullName, Addres, PhoneNumber);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckUser_Cezar_DneprFalse_38095423234_returnedfalse()
        {
            //arrenge
            string FuullName = "ЦезарьГриша, Александровичь", Addres = "Днепр, ", PhoneNumber = "38093453457";
            bool expected = false;
            //act
            AdminForm aF = new AdminForm();
            bool actual = aF.CheckUser(FuullName, Addres, PhoneNumber);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckUser_grishagmailcom_returnedTrue()
        {
            //arrenge
            string Email = "grisha@gmail.com";
            bool expected = true;
            //act
            AdminForm aF = new AdminForm();
            bool actual = aF.CheckUser(Email);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
