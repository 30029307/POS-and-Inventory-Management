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
