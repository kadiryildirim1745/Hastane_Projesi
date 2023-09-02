using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hastane_Projesi
{
    public partial class Duyurular : Form
    {
        public Duyurular()
        {
            InitializeComponent();
        }
        baglanti con = new baglanti();
        private void Duyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from Tbl_Duyuru ", con.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.connection().Close();
        }
    }
}
