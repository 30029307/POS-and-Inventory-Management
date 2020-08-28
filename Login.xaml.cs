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
using System.Windows.Shapes;

namespace POS_and_Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void userNameTextBox_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            userNameTextBox.Text = "";
        }

        private void passTextBox_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            passTextBox.Password = "";
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashBoard = new Dashboard();
            App.Current.MainWindow = dashBoard;
            this.Close();
            dashBoard.Show();
        }
    }
}
