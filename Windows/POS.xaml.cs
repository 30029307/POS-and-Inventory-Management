using POS_and_Inventory_Management_System.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for POS.xaml
    /// </summary>
    public partial class POS : Window
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection cn;
        DataTable dt = new DataTable();
        DataView dv;

        List<StockInProducts> stocks = new List<StockInProducts>();

        public POS()
        {
            InitializeComponent();
            datePickerDateIssued.SelectedDate = DateTime.Now;
            cn = new SqlConnection(dbCon.Connection());

            cn.Open();
        }


        private void UpdateGridProducts() {
            dataGridLoadProducts.ItemsSource = null;
            dt.Clear();

            SqlCommand com = cn.CreateCommand();
            com.CommandText = "SELECT * From Product";

            SqlDataReader read = com.ExecuteReader();

            while (read.Read()) {

                stocks.Add( new StockInProducts {
                    PCode = Int32.Parse(read[0].ToString()),
                    Barcode = read[1].ToString(),
                    PDesc = read[2].ToString(),
                    BrandID = Int32.Parse(read[3].ToString()),
                    CategoryID = Int32.Parse(read[4].ToString()),
                    Price = Double.Parse(read[5].ToString()),
                    Qty = Int32.Parse(read[6].ToString())

                });
            
            }

            dt.Columns.Add("Barcode");
            dt.Columns.Add("PDesc");
            dt.Columns.Add("Price");
            dt.Columns.Add("Qty");
          

            foreach (StockInProducts s in stocks)
            {

                dt.Rows.Add(s.Barcode, s.PDesc, s.Price, s.Qty);

            }

            dv = new DataView(dt);
            dataGridLoadProducts.ItemsSource = dv;
        }

        private void dataGridLoadProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void datePickerDateIssued_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateGridProducts();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cn.Close();
        }

        private void dataGridLoadProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            DataRowView item = dg.SelectedItem as DataRowView;

            textBlockBarcode.Text = item.Row[0].ToString();
            textBlockItemName.Text = item.Row[1].ToString();
            textBoxPrice.Text = item.Row[2].ToString();
            textBoxQty.Text = "1";
            textBlockTotal.Text = item.Row[2].ToString();


        }

        private void textBoxQty_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (textBoxQty.Text != "" && textBoxPrice.Text != "") {

                double qty = Double.Parse(textBoxQty.Text);
                double price = Double.Parse(textBoxPrice.Text);


                var totalUpdate = qty * price;


                textBlockTotal.Text = totalUpdate.ToString();
            }

        }

        private void textBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var totalUpdate = Double.Parse(textBoxQty.Text) * Double.Parse(textBoxPrice.Text);
            //textBlockTotal.Text = totalUpdate.ToString();
        }
    }
}
