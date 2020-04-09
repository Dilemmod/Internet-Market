using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetMarket;
using DatabaseLibrary;
using System.Linq;

namespace InternetMarketUnitTest
{
    [TestClass]
    public class CustomerFormTests
    {
        [TestMethod]
        public void OrderPanelСompletedCorrectly_ValueRight_returnedTrue()
        {
            //arrenge
            string orderFamily = "Цезарь", orderName = "Гриша", orderDad = "Александровичь", orderAddres = "Днепр, Шевченка 5, 50";
            string orderPhoneNumber="380952342342", orderEmail="grisha@gmail.com", orderDeliveryMetod= "Новой почтой", orderPaymentMthod= "GooglePay", OrderPriceLabel="6023";
            bool expected = true;
            //act
            DataBaseIM db = new DataBaseIM();
            CustomerForm custumerForm = new CustomerForm(db.CustomersInformations.First());
            bool actual = custumerForm.OrderPanelСompletedCorrectly(orderFamily, orderName, orderDad, orderAddres, orderPhoneNumber, orderEmail, orderDeliveryMetod, orderPaymentMthod, OrderPriceLabel);
            //assert
            Assert.AreEqual(expected, actual);
            
        }
    }
}
