using System;
using System.Collections.Generic;
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

namespace FishShop
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            
            MainWindow page = new MainWindow();
            page.ShowsNavigationUI = false;
            nav.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
