using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_and_Inventory_Management_System
{
    class DBConnection
    {
        public string Connection() {

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PosInventory;Integrated Security=True";
            return con;
        }
    }
}
