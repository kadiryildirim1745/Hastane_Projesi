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
    public partial class Doktor_Giriş : Form
    {
        public Doktor_Giriş()
        {
            InitializeComponent();
        }
        baglanti con= new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select doktorTc, doktorSifre from Tbl_doktor where doktorTc=@p1 and doktorSifre=@p2",con.connection());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            SqlDataReader rd= cmd.ExecuteReader();
            if (rd != null)
            {
                Doktor_Detay dt = new Doktor_Detay();
                dt.tc = maskedTextBox2.Text;
                timer1.Enabled = false;
                dt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girilen Bilgiler Yanlış");
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
        
        private void Doktor_Giriş_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            sayac = 120;
            

        }
    }
}
