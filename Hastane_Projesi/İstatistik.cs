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
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }
        baglanti con = new baglanti();
        private void İstatistik_Load(object sender, EventArgs e)
        {
            //grafik
            SqlCommand cmd = new SqlCommand("select doktorBranş, count(*)as 'sayi' from Tbl_Doktor group by doktorBranş order by sayi DESC", con.connection());
            SqlDataReader ra = cmd.ExecuteReader();
            while(ra.Read())
            {
                chart1.Series["BD"].Points.AddXY(ra[0].ToString(), ra[1].ToString());
            }
            con.connection().Close();
            SqlCommand cmd2 = new SqlCommand("select randevuBrans, count(*)as 'sayi' from Tbl_Randevu group by randevuBrans order by sayi DESC", con.connection());
            SqlDataReader ra2 = cmd2.ExecuteReader();
            while (ra2.Read())
            {
                chart2.Series["BR"].Points.AddXY(ra2[0].ToString(), ra2[1].ToString());
            }
            con.connection().Close ();

            SqlCommand cmd7 = new SqlCommand("select randevuDurum, count(*) from Tbl_Randevu  where randevuDurum='true' group by randevuDurum ", con.connection());
            SqlDataReader ra7 = cmd7.ExecuteReader();
            while (ra7.Read())
            {
                chart3.Series["RD"].Points.AddXY("Dolu Randevu", ra7[1].ToString());
            }
            con.connection().Close();
            SqlCommand cmd8 = new SqlCommand("select randevuDurum, count(*) from Tbl_Randevu  where randevuDurum='false' group by randevuDurum ", con.connection());
            SqlDataReader ra8 = cmd8.ExecuteReader();
            while (ra8.Read())
            {
                chart3.Series["RD"].Points.AddXY("Boş Randevu", ra8[1].ToString());
            }
            con.connection().Close();

            chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //istatistik
            SqlCommand cmd3 = new SqlCommand("select count(*) from Tbl_Hasta", con.connection());
            SqlDataReader ra3= cmd3.ExecuteReader();
            while (ra3.Read())
            {
                label6.Text= ra3[0].ToString();
            }
            con.connection().Close();

            SqlCommand cmd4 = new SqlCommand("select count(*) from Tbl_Doktor", con.connection());
            SqlDataReader ra4 = cmd4.ExecuteReader();
            while (ra4.Read())
            {
                label5.Text = ra4[0].ToString();
            }
            con.connection().Close();

            SqlCommand cmd5 = new SqlCommand("select count(*) from Tbl_Brans", con.connection());
            SqlDataReader ra5 = cmd5.ExecuteReader();
            while (ra5.Read())
            {
                label4.Text = ra5[0].ToString();
            }
            con.connection().Close();

            SqlCommand cmd6 = new SqlCommand("select count(*) from Tbl_Randevu", con.connection());
            SqlDataReader ra6 = cmd6.ExecuteReader();
            while (ra6.Read())
            {
                label9.Text = ra6[0].ToString();
            }
            con.connection().Close();
        }
    }
}
