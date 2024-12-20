using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace FishShop
{
    internal class DatabaseManager
    {
        public static Entities entity;

        public static int authUserId;
        public static int? staff;
        public static string ImageToAdd;
        public static int selecteditemindex;


        public static string AddProduct(string name, int price, string description)
        {
            return name;
        }

        public static string AddUser(string login, string password)
        {
            return login;
        }

        public static bool ValidatePass(string pass)
        {
            return true;
        }

        public static bool FilterProduct(string name)
        {
            return true;
        }

        public static bool AddManufacturer(string name)
        {
            return name;
        }


    }
}
