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
    public partial class Hasta_Giris : Form
    {
        public Hasta_Giris()
        {
            InitializeComponent();
        }
        baglanti con = new baglanti();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             Hasta_Kayıt hk = new Hasta_Kayıt();
             hk.Show();
             this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select hastaTc, hastaSifre from Tbl_Hasta where hastaTc=@p1 and hastaSifre=@p2",con.connection());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            SqlDataReader dr= cmd.ExecuteReader();
            if (dr.Read())
            {
                Hasta_Detay hd = new Hasta_Detay();
                hd.tc = maskedTextBox2.Text;
                timer1.Enabled = false;
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Girişi.");
            }
            con.connection().Close();
        }
        int sayac;
        private void Hasta_Giris_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            sayac = 120;
        }
        Giris g = new Giris();
        private void button2_Click(object sender, EventArgs e)
        {
            
            g.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = sayac.ToString();
            if (sayac == 0)
            {
                timer1.Enabled = false;
                g.Show();

                this.Hide();
            }
            else
            {
                sayac--;
            }
        }
    }
}
