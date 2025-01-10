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

namespace WindowsFormsApp1
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        dbOkulEntities db=new dbOkulEntities();

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OgrtTc,OgrtSifre from Tbl_Ayarlar inner join Tbl_Ogretmenler on Tbl_Ayarlar.AyarlarId=Tbl_Ogretmenler.OgrtId where OgrtTc=@p1 and OgrtSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FormAnaModul frm1 = new FormAnaModul();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı veya şifre");
                mskTc.Text = "";
                txtSifre.Text = "";
            }
            bgl.baglanti().Close();

        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OgrtTc,OgrtSifre from Tbl_Ayarlar inner join Tbl_Ogretmenler on Tbl_Ayarlar.AyarlarId=Tbl_Ogretmenler.OgrtId where OgrtTc=@p1 and OgrtSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frmOgretmenAnaModul frm2 = new frmOgretmenAnaModul();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı veya şifre");
                mskTc.Text = "";
                txtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.Tbl_OgrAyarlar
                        join d2 in db.Tbl_Ogrenciler
                        on d1.AyarlarOgrId equals d2.OgrId
                        where d2.OgrTc == mskTc.Text &&
                        d1.OgrSifre == txtSifre.Text
                        select d2;
            if (sorgu.Any())
            {
                frmOgrenciAnaModul frm3= new frmOgrenciAnaModul();
                frm3.Show();
                this.Hide();
            }
            MessageBox.Show("hatalı kullanıcı veya şifre");
            mskTc.Text = "";
            txtSifre.Text = "";
        }
    }
}
