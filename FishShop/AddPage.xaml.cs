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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        string paths;
        string saymyname;
        public AddPage()
        {

            InitializeComponent();
            DatabaseManager.entity = new Entities();
            var good = DatabaseManager.entity.goods.Find(DatabaseManager.selecteditemindex+1);
            nameBox.Text = good.name;
            descBox.Text = good.description;
            priceBox.Text = good.price.ToString();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var good = DatabaseManager.entity.goods.Find(DatabaseManager.selecteditemindex + 1);
            good.description = descBox.Text;
            good.name = nameBox.Text;
            good.price = Convert.ToInt32(priceBox.Text);
            if (imgPhoto.Source != null)
                good.image = imgPhoto.Source.ToString();
            DatabaseManager.entity.SaveChanges();

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
