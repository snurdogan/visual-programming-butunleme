using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rozgift_stock_management_system
{
    public class Database
    {
        public static MySqlConnection dbconnection = new MySqlConnection("server=localhost; database=rozgiftnew; uid=root; pwd='';");
    }
}
