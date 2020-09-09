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
        public MainPage()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void manageBrandButton_Click(object sender, RoutedEventArgs e)
        {
            BrandsList B = new BrandsList();

            ManageBrand manageBrandWindow = new ManageBrand();

            manageBrandWindow.Show();
           
            
            
            
        }

        
    }
}
