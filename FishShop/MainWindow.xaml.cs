using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public partial class MainWindow : Page
        {
            public MainWindow()
            {
                InitializeComponent();
                DatabaseManager.entity = new Entities();
                ListView1.ItemsSource = DatabaseManager.entity.goods.ToList();




                SortBy.ItemsSource = new string[] { "Название", "цена" };
                var enumDirection = new string[] { "по возрастанию", "по убыванию" };

                sortProp.ItemsSource = enumDirection;
                sortProp.SelectedValue = enumDirection[0];
                SortBy.SelectedValue = "Название";
                ListView1.Items.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));

                ListView1.Items.Filter = NameFilter;

                sortProp.SelectionChanged += SelectionChanged;
                SortBy.SelectionChanged += SelectionChanged;


            }

            private void SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                string selectedFilter = sortProp.SelectedItem.ToString();
                string selectedSort = SortBy.SelectedItem.ToString();
                ListSortDirection sortDirection = selectedFilter.Contains("по возрастанию") ? ListSortDirection.Ascending : ListSortDirection.Descending;

                var view = (CollectionView)CollectionViewSource.GetDefaultView(ListView1.ItemsSource);
                view.SortDescriptions.Clear();

                if (selectedSort == "Название")
                    selectedSort = "name";
                if (selectedSort == "цена")
                    selectedSort = "price";

                view.SortDescriptions.Add(new SortDescription(selectedSort, sortDirection));
            }

            private bool NameFilter(object obj)
            {
                var FilterObj = obj as goods;

                return FilterObj.name.Contains(filter.Text);
            }

            private void filter_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (filter.Text == null)
                    ListView1.Items.Filter = null;
                else
                    ListView1.Items.Filter = NameFilter;
            }



        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatabaseManager.staff == 1)
            {
                var item = ListView1.SelectedIndex;
                DatabaseManager.selecteditemindex = item;
                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
                AddPage page = new AddPage();
                nav.Navigate(page);
            }
                

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DatabaseManager.staff == 1)
            {
                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
                AdminPage page = new AdminPage();
                nav.Navigate(page);
            }
        }
    }
}
