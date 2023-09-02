using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Hastane_Projesi
{
    internal class baglanti
    {
        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=hastaneDB;Integrated Security=True");
            conn.Open();
            return conn;
        }
    }
}
