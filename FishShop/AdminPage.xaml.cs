using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace FishShop
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        string paths;
        string saymyname;
        public AdminPage()
        {
            InitializeComponent();
            DatabaseManager.entity = new Entities();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var goods = new goods()
            {
                name = nameBox.Text.Trim(),
                price = Convert.ToInt32(priceBox.Text.Trim()),
                description = descBox.Text.Trim(),
                image = DatabaseManager.ImageToAdd,

            };

            DatabaseManager.entity.goods.Add(goods);
            DatabaseManager.entity.SaveChanges();
            File.Copy(paths, System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..", ".."), $"images\\{saymyname}")));
            MessageBox.Show("Успешно добавлено");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Выберите картинку";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    paths = op.FileName;
                    saymyname = op.SafeFileName;
                    imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                    DatabaseManager.ImageToAdd = op.SafeFileName;
                }
            }
            catch
            {
                MessageBox.Show("Что то пошло не так");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);

            MainWindow page = new MainWindow();
            page.ShowsNavigationUI = false;
            nav.Navigate(page);
        }
    }
}
