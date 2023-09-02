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

namespace Hastane_Projesi
{
    public partial class Doktor_Detay : Form
    {
        public Doktor_Detay()
        {
            InitializeComponent();
        }
        public string tc;
        baglanti con=new baglanti();
        private void Doktor_Detay_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand cmd = new SqlCommand("select doktorAd, doktorSoyad from Tbl_Doktor where doktorTc=@p1", con.connection());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
                label5.Text = dr[1].ToString();
            }
            con.connection().Close();
            DataTable dt = new DataTable();
            string ad = label4.Text + " " + label5.Text;
            SqlDataAdapter da=new SqlDataAdapter("select * from Tbl_Randevu where randevuDoktor='"+ad +"' and randevuDurum='"+ true +"'",con.connection());
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label11.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label16.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            SqlCommand cmd5 = new SqlCommand("select hastaAd, hastaSoyad from Tbl_Hasta where hastaTc=@p1", con.connection());
            cmd5.Parameters.AddWithValue("@p1", label11.Text);
            SqlDataReader dr= cmd5.ExecuteReader();
            while(dr.Read())
            {
                label8.Text = dr[0].ToString();
                label7.Text= dr[1].ToString();
            }
            con.connection().Close();
            SqlCommand cmd6 = new SqlCommand("select hastaSikayet,randevuTarih,randevuSaat from Tbl_Randevu where hastaTc=@l5 and randevuID=@l6", con.connection());
            cmd6.Parameters.AddWithValue("@l5", label11.Text);
            cmd6.Parameters.AddWithValue("@l6", label16.Text);
            SqlDataReader dr2 = cmd6.ExecuteReader();
            while (dr2.Read())
            {
                richTextBox1.Text = dr2[0].ToString();
                label13.Text = dr2[1].ToString();
                label12.Text= dr2[2].ToString();
            }
            SqlCommand cmd7 = new SqlCommand("select hastaAd,hastaSoyad from Tbl_Hasta where hastaTc=@g1",con.connection());
            cmd7.Parameters.AddWithValue("@g1", label11.Text);
            SqlDataReader dr3 = cmd7.ExecuteReader();
            while (dr3.Read())
            {
                label8.Text = dr3[0].ToString();
                label7.Text = dr3[1].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Duyurular d =new Duyurular();
            d.Show();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giris giris =new Giris();
            giris.Show();
            this.Hide();
        }

        private void sekreterGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sekreter_Giriş sg = new Sekreter_Giriş();
            sg.Show();
            this.Hide();
        }

        private void hastaGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hasta_Giris hg=new Hasta_Giris();
            hg.Show();
            this.Hide();
        }

        private void doktorGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doktor_Giriş dg = new Doktor_Giriş();
            dg.Show();
            this.Hide();
        }

        private void çıkşYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
