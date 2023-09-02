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
using System.Data.Common;

namespace Hastane_Projesi
{
    public partial class Hasta_Detay : Form
    {
        public Hasta_Detay()
        {
            InitializeComponent();
        }
        public string tc;
        baglanti con=new baglanti();
        void yenile()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevu where hastaTc=" + tc, con.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.connection().Close();
        }
        void yenile2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select* from Tbl_Randevu where randevuBrans='" + comboBox2.Text + "' and randevuDoktor='" + comboBox1.Text + "' and randevuDurum='"+ false +"'", con.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.connection().Close();
        }
        private void Hasta_Detay_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand cmd = new SqlCommand("select hastaAd,hastaSoyad from Tbl_Hasta where hastaTc=@p1", con.connection());
            cmd.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
                label5.Text = dr[1].ToString();
            }
            con.connection().Close();

            //dgw

            yenile();
            //branş
            SqlCommand cmd2 = new SqlCommand("select * from Tbl_Brans", con.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[1].ToString());
            }
            con.connection().Close();
            //
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            SqlCommand cmd3 = new SqlCommand("select * from Tbl_Doktor where doktorBranş=@p1", con.connection());
            cmd3.Parameters.AddWithValue("@p1", comboBox2.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox1.Items.Add(dr3[1]+" "+dr3[2]);
            }
            con.connection().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hasta_Düzenle hd=new Hasta_Düzenle();
            hd.tc = tc;
            hd.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            yenile2();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5= new SqlCommand("update Tbl_Randevu set randevuDurum=@h1,hastaTc=@h2,hastaSikayet=@h3 where randevuID=@h4",con.connection());
            cmd5.Parameters.AddWithValue("@h1", true);
            cmd5.Parameters.AddWithValue("@h2",tc);
            cmd5.Parameters.AddWithValue("@h3", richTextBox1.Text);
            cmd5.Parameters.AddWithValue("@h4", textBox1.Text);
            cmd5.ExecuteNonQuery();
            con.connection().Close();
            MessageBox.Show("Randevu Oluşturuldu");
            yenile();
            yenile2();
                
        }
        

        private void doktorGirişToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Doktor_Giriş dg = new Doktor_Giriş();
            dg.Show();
            this.Hide();
        }

        private void anaMenüToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
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
