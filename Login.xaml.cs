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
using POS_and_Inventory_Management_System.Classes;
using POS_and_Inventory_Management_System.Windows;

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


        List<Users> userLogin = new List<Users>();
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());
            cn.Open();
            GetUser();

        }

        private List<Users> GetUser()
        {

            //userLogin.Clear();

            SqlCommand comUsers = new SqlCommand("SELECT u.UserId, u.Fullname, u.Username, u.Password, u.RoleId, u.Contact,u.Email, r.RoleName from ManageUser as u inner join Role as r on r.RoleId = u.RoleId", cn);

            dr = comUsers.ExecuteReader();

            while (dr.Read())
            {
                userLogin.Add(new Users
                {
                    UserId = (int)dr[0],
                    Fullname = dr[1].ToString(),
                    Username = dr[2].ToString(),
                    Password = dr[3].ToString(),
                    RoleId = (int)dr[4],
                    Contact = (int)dr[5],
                    Email = dr[6].ToString(),
                    RoleName = dr[7].ToString()

                });
            }

            dr.Close();

            return userLogin;

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
            MainPage main = new MainPage(this);
            

            var userQuery = (from u in GetUser() where u.Username.Equals(userNameTextBox.Text) && u.Password.Equals(passTextBox.Password) select u).FirstOrDefault();

            if (userQuery == null)
            {
                MessageBox.Show("Invalid login.", "Login", MessageBoxButton.OK, MessageBoxImage.Asterisk);


            }
            else
            {
                this.Close();
                main.Show();
                main.usernameDisplay.Content = userQuery.Username;
                main.roleDisplay.Content = userQuery.RoleName;
                App.loginName = userQuery.Fullname;

                if (userQuery.RoleName == "Cashier") {
                    main.stackPanelBrand.Visibility = Visibility.Collapsed;
                    main.stackPanelCategory.Visibility = Visibility.Collapsed;
                    main.stackPanelProduct.Visibility = Visibility.Collapsed;
                    main.stackPanelStock.Visibility = Visibility.Collapsed;
                    main.stackPanelUser.Visibility = Visibility.Collapsed;                  
                }
                else if (userQuery.RoleName == "Inventory")
                {
                    
                    main.stackPanelUser.Visibility = Visibility.Collapsed;
                    main.stackPanelPOS.Visibility = Visibility.Collapsed;
                }
                else if (userQuery.RoleName == "Admin" || userQuery.RoleName == "Manager")
                {
                    main.stackPanelBrand.Visibility = Visibility.Visible;
                    main.stackPanelCategory.Visibility = Visibility.Visible;
                    main.stackPanelProduct.Visibility = Visibility.Visible;
                    main.stackPanelStock.Visibility = Visibility.Visible;
                    main.stackPanelUser.Visibility = Visibility.Visible;
                    main.stackPanelPOS.Visibility = Visibility.Visible;
                }





            }

        }

        private void loginButton_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cn.Close();
        }
    }
}
