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
    public partial class Sekreter_Giriş : Form
    {
        public Sekreter_Giriş()
        {
            InitializeComponent();
        }
        baglanti con=new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select* from Tbl_Sekreter where sekreterTc=@p1 and sekreterSifre=@p2",con.connection());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Sekreter_Detay sd=new Sekreter_Detay();
                sd.tc = maskedTextBox2.Text.ToString();
                timer1.Enabled = false;
                sd.Show();
                
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");

            }
            con.connection().Close();
        }
        Giris g = new Giris();
        private void button2_Click(object sender, EventArgs e)
        {
            
            g.Show();
            this.Hide();
        }
        int sayac;
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

        private void Sekreter_Giriş_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            sayac = 120;
        }
    }
}
