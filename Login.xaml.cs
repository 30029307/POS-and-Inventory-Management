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
using System.Data.SqlClient;

namespace POS_and_Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection cn;
        SqlCommand cm = new SqlCommand();
        DBConnection dbCon = new DBConnection();

        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());
            
           
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
            MainPage main = new MainPage();
            this.Close();

            try
            {
                cn.Open();
                main.Show();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message.ToString());
                Login l = new Login();
                l.Show();
            }
           
        }

        private void loginButton_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
