using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hastane_Projesi
{
    public partial class Branş_Paneli : Form
    {
        public Branş_Paneli()
        {
            InitializeComponent();
        }
        baglanti con = new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("insert into Tbl_Brans (bransAd) values (@p1)",con.connection());
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Branş Kaydedildi");
            con.connection().Close();
            yenile();
        }
        void yenile()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Brans", con.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.connection().Close();
        }
        private void Branş_Paneli_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("delete from Tbl_Brans where bransID=@l1", con.connection());
            cmd2.Parameters.AddWithValue("@l1", textBox1.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Branş Silindi");
            con.connection().Close();
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Tbl_Brans set bransAd=@k1 where bransID=@k2", con.connection());
            cmd2.Parameters.AddWithValue("@k2", textBox1.Text);
            cmd2.Parameters.AddWithValue("@k1", textBox2.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Branş Güncellendi");
            con.connection().Close();
            yenile();
        }
    }
}
