using POS_and_Inventory_Management_System.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace POS_and_Inventory_Management_System.UserControls
{
    /// <summary>
    /// Interaction logic for BrandsList.xaml
    /// </summary>
    public partial class BrandsList : UserControl
    {
        Brands b = new Brands();
        Brands b2 = new Brands();
        List<Brands> brnds = new List<Brands>();
        public BrandsList()
        {
            InitializeComponent();
                  
        }

        private void brandsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {


            for (int i = 0; i < 10; ++i)
            {

                brnds.Add(new Brands() { BrandID = i, BrandName = "Brand " + i.ToString() });
                
               
            }

            foreach (Brands b in brnds) {

                brandsListDataGrid.Items.Add(b);
            }

            


        }

        private void brandDelete_Click(object sender, RoutedEventArgs e)
        {
            // DataRowView row = (DataRowView)brandsListDataGrid.SelectedItem;
            //brandsListDataGrid.Items.Remove(brandsListDataGrid.SelectedItem);

            MessageBox.Show("hehehe" + brandsListDataGrid.SelectedIndex);



        }

        private void brandModify_Click(object sender, RoutedEventArgs e)
        {
            Brands row = brandsListDataGrid.SelectedItem as Brands;
            string name = row.BrandName;

            row.BrandName = "updated";


            

           
            brandsListDataGrid.Items.Refresh();


            //if (brandsListDataGrid.Items.IndexOf(brandsListDataGrid.SelectedItem) == 2)
            //{
               
            //}
           
        }
    }
}
