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
    public partial class Doktor_Paneli : Form
    {
        public Doktor_Paneli()
        {
            InitializeComponent();
        }
        baglanti con = new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("insert into Tbl_Doktor (doktorAd,doktorSoyad,doktorBranş,doktorTc,doktorSifre) values (@p1,@p2,@p3,@p4,@p5)",con.connection());
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p5", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Doktor Kaydedildi");
            yenile();

        }
        void yenile()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktor", con.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.connection().Close();
        }
        private void Doktor_Paneli_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select bransAD from Tbl_Brans", con.connection());
            SqlDataReader dataReader = cmd2.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader[0].ToString());
            }
            con.connection().Close();
            //dgv
            yenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("delete from Tbl_Doktor where doktorTc=@l1", con.connection());
            
            cmd3.Parameters.AddWithValue("@l1", maskedTextBox1.Text);
            
            cmd3.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Doktor Silindi");
            yenile();
            con.connection().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("update Tbl_Doktor set doktorAd=@k1,doktorSoyad=@k2,doktorBranş=@k3,doktorSifre=@k5 where doktorTc=@k4", con.connection());
            cmd4.Parameters.AddWithValue("@k1", textBox2.Text);
            cmd4.Parameters.AddWithValue("@k2", textBox3.Text);
            cmd4.Parameters.AddWithValue("@k3", comboBox1.Text);
            cmd4.Parameters.AddWithValue("@k4", maskedTextBox1.Text);
            cmd4.Parameters.AddWithValue("@k5", textBox4.Text);
            cmd4.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Doktor Güncellendi");
            yenile();
            con.connection().Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void Bilgiler_Enter(object sender, EventArgs e)
        {

        }
    }
}
