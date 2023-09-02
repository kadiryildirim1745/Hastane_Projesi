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
    public partial class Hasta_Kayıt : Form
    {
        public Hasta_Kayıt()
        {
            InitializeComponent();
        }
        baglanti bg=new baglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com= new SqlCommand("insert into Tbl_Hasta (hastaAd,hastaSoyad,hastaTc,hastaTelefon,hastaSifre,hastaCinsiyet) values" +
                " (@p1,@p2,@p3,@p4,@p5,@p6)",bg.connection());
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            com.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@p5", textBox3.Text);
            if (radioButton1.Checked)
            {
                com.Parameters.AddWithValue("@p6", radioButton1.Text);
            }
            else
            {
                com.Parameters.AddWithValue("@p6", radioButton2.Text);
            }
            com.ExecuteNonQuery();
            bg.connection().Close();
            MessageBox.Show("Hasta Başarılı Bir Şekilde Kaydedildi.");
            Hasta_Giris hg= new Hasta_Giris();
            hg.Show();
            this.Hide();
        }
    }
}
