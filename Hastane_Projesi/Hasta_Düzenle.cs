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
    public partial class Hasta_Düzenle : Form
    {
        public Hasta_Düzenle()
        {
            InitializeComponent();
        }
        public string tc;
        baglanti con=new baglanti();
        private void Hasta_Düzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text= tc;
            SqlCommand cmd = new SqlCommand("select* from Tbl_Hasta where hastaTc=@p1",con.connection());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[5].ToString();
                label7.Text = dr[6].ToString();
                maskedTextBox2.Text = dr[4].ToString();
            }
            con.connection().Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hasta_Giris hg= new Hasta_Giris();
            hg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Tbl_Hasta set hastaAd=@l1,hastaSoyad=@l2,hastaCinsiyet=@l3,hastaTelefon=@l4,hastaSifre=@l5 where hastaTc=@l6", con.connection());
            cmd2.Parameters.AddWithValue("@l1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@l2", textBox2.Text);
            cmd2.Parameters.AddWithValue("@l5", textBox3.Text);
            cmd2.Parameters.AddWithValue("@l3", label7.Text);
            cmd2.Parameters.AddWithValue("@l4", maskedTextBox2.Text);
            cmd2.Parameters.AddWithValue("@l6", tc);
            cmd2.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Hasta Bilgileri Güncellendi.");
        }
    }
}
