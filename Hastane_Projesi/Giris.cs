using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Projesi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hasta_Giris hg = new Hasta_Giris();
            hg.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doktor_Giriş dg = new Doktor_Giriş();
            dg.Show();
            this.Hide();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sekreter_Giriş sg = new Sekreter_Giriş();
            sg.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            İstatistik i =new İstatistik();
            i.Show();

        }
    }
}
