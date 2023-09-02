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
    public partial class Sekreter_Detay : Form
    {
        baglanti con=new baglanti();
        Randevu_Listesi rl = new Randevu_Listesi();
        public Sekreter_Detay()
        {
            InitializeComponent();
        }
        public string tc;
        private void button2_Click(object sender, EventArgs e)
        {
            Doktor_Paneli dp = new Doktor_Paneli();
            dp.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Branş_Paneli bp= new Branş_Paneli();
            bp.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            rl.Show();
            
        }

        private void Sekreter_Detay_Load(object sender, EventArgs e)
        {
            
            label6.Text = tc;
            SqlCommand cmd = new SqlCommand("select sekreterAd, sekreterSoyad from Tbl_Sekreter where sekreterTc=@p1", con.connection());
            cmd.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label4.Text = reader[0].ToString();
                label5.Text = reader[1].ToString();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Brans", con.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.connection().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter dv = new SqlDataAdapter("select (doktorAd + ' ' + doktorSoyad) as'Doktorlar' ,doktorBranş from Tbl_Doktor ", con.connection());
            dv.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.connection().Close();
            //dgv veri çekme
            SqlCommand cmd2 = new SqlCommand("select bransAd from Tbl_Brans",con.connection());
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2[0].ToString());
            }

           

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            SqlCommand cmd3 = new SqlCommand("select doktorAd, doktorSoyad from Tbl_Doktor where doktorBranş=@p1", con.connection());
            cmd3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader rd= cmd3.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd[0].ToString() + " " + rd[1].ToString());
            }
            con.connection().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("insert into Tbl_Randevu (randevuTarih,randevuSaat,randevuBrans,randevuDoktor) values(@p1,@p2,@p3,@p4)", con.connection());
            cmd4.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd4.Parameters.AddWithValue("@p2", maskedTextBox2.Text);
            cmd4.Parameters.AddWithValue("@p3", comboBox1.Text);
            cmd4.Parameters.AddWithValue("@p4", comboBox2.Text);
            cmd4.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Randevu Oluşturuldu");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("insert into Tbl_Duyuru (Duyuru) values (@p9)",con.connection());
            cmd5.Parameters.AddWithValue("@p9", richTextBox1.Text);
            cmd5.ExecuteNonQuery();
            MessageBox.Show("Duyuru Oluşturuldu");
            con.connection().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }
        

        private void anaMenüToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void doktorGirişToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Doktor_Giriş dg = new Doktor_Giriş();
            dg.Show();
            this.Hide();
        }

        private void hastaGirişToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hasta_Giris hg = new Hasta_Giris();
            hg.Show();
            this.Hide();
        }

        private void sekreterGirişToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Sekreter_Giriş sg = new Sekreter_Giriş();
            sg.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
