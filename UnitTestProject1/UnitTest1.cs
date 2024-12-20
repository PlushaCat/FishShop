using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FishShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // проверка добавился ли товар в базу данных
        public void Product_added_test()
        {
            string Productname = "Удочка";
            string description = "Рыболовная удочка";

        }

        [TestMethod]
        // проверка добавился ли пользователь в базу данных
        public void User_added_test()
        {
            Entities entities = new Entities();


            var user = new users()
            {
                login = "login",
                password = "123",
                name = "пользователь1",

            };
            entities.SaveChanges();
            Assert.AreEqual(entities.users.Last(), user.name);

        }

        [TestMethod]
        // проверка добавился ли производитель в базу данных
        public void Manufacturer_added()
        {
            Entities entities = new Entities();


            var manufacturer = new manufacturer()
            {

                manufacturer1 = "ООО Рыба",

            };
            entities.SaveChanges();
            Assert.AreEqual(entities.manufacturer.Last(), manufacturer.manufacturer1);

        }

        [TestMethod]
        // проверка добавился ли поставщик в базу данных
        public void Provider_added()
        {
            Entities entities = new Entities();


            var provider = new provider()
            {
                provider1 = "ООО Перевозки рыбные",

            };
            entities.SaveChanges();
            Assert.AreEqual(entities.provider.Last(), provider.provider1);

        }

        [TestMethod]
        // проверка добавился ли страна в базу данных
        public void Country_added()
        {
            Entities entities = new Entities();
;

            var country = new country()
            {
                country1 = "Китай",

            };
            entities.SaveChanges();
            Assert.AreEqual(entities.country.Last(), country.country1);

        }
    }
}
