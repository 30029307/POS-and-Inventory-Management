using POS_and_Inventory_Management_System;
using POS_and_Inventory_Management_System.UserControls;
using POS_and_Inventory_Management_System.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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

namespace POS_and_Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Window
    {

        Login login;
        public MainPage(Login l)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            login = l;

            //usernameDisplay.Content = Username;


        }


        private void manageProduct_Click(object sender, RoutedEventArgs e)
        {
            ManageProduct manageProductWindow = new ManageProduct();
            manageProductWindow.ShowDialog();

        }
        private void manageBrandButton_Click(object sender, RoutedEventArgs e)
        {
            ManageBrand manageBrandWindow = new ManageBrand();
            manageBrandWindow.ShowDialog();
        }

        private void manageCategory_Click(object sender, RoutedEventArgs e)
        {
            ManageCategory manageCategoryWindow = new ManageCategory();
            manageCategoryWindow.ShowDialog();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

            Login loginPage = new Login();
            loginPage.Show();
            this.Close();
        }

        private void manageStock_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manageStockWindow = new ManageStock();
            manageStockWindow.ShowDialog();
        }

        private void manageUserButton_Click(object sender, RoutedEventArgs e)
        {
            ManageUser manageUserWindow = new ManageUser();
            manageUserWindow.ShowDialog();
        }

        private void managePOS_Click(object sender, RoutedEventArgs e)
        {
            POS managePOS = new POS();
            managePOS.ShowDialog();
        }
    }
}
