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
using System.IO;
using DevExpress.XtraLayout.Resizing;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace WindowsFormsApp1
{
    public partial class FrmÖgretmenler : Form
    {
        public FrmÖgretmenler()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * from Tbl_Ogretmenler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void ilekle()
        {
            SqlCommand komut = new SqlCommand("Select*from iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİl.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void bransGetir()
        {
            SqlCommand komut = new SqlCommand("Select*from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBrans.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTc.Text = "";
            mskTelefon.Text = "";
            cmbİl.Text = "";
            cmbİlce.Text = "";
            txtMail.Text = "";
            rchAdres.Text = "";
            pcrResim.ImageLocation = "";
        }
        private void FrmÖgretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            bransGetir();
        }

        private void cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbİlce.Properties.Items.Clear();
            cmbİlce.Text = "";
            SqlCommand komut = new SqlCommand("select*from ilceler where il_no=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" ,cmbİl.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİlce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
         
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut =new SqlCommand("insert into Tbl_Ogretmenler(OgrtAd,OgrtSoyad,OgrtTc,OgrtTel,OgrtMail,Ogrtİl,Ogrtİlce,OgrtAdres,OgrtBrans,OgrtFoto) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl.baglanti());

            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTc.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbİl.Text);
            komut.Parameters.AddWithValue("@p7", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("personel eklendi", "bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!= null)
            {
                txtId.Text = dr["OgrtId"].ToString();
                txtAd.Text = dr["OgrtAd"].ToString();
                txtSoyad.Text = dr["OgrtSoyad"].ToString();
                mskTc.Text = dr["OgrtTc"].ToString();
                mskTelefon.Text = dr["OgrtTel"].ToString();
                cmbİl.Text = dr["Ogrtİl"].ToString();
                cmbİlce.Text = dr["Ogrtİlce"].ToString();
                cmbBrans.Text = dr["OgrtBrans"].ToString();
                txtMail.Text = dr["OgrtMail"].ToString();
                rchAdres.Text = dr["OgrtAdres"].ToString();
                yeniyol = " C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrtFoto"].ToString();
                pcrResim.ImageLocation=yeniyol;

            }
        }
        public string yeniyol;

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya=new OpenFileDialog();
            dosya.Filter = "Resim Dosyası | *.jpg;*png;*nef |Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = " C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
            pcrResim.ImageLocation=yeniyol;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Ogretmenler set OgrtAd=@p1,OgrtSoyad=@p2,OgrtTc=@p3,OgrtTel=@p4,OgrtMail=@p5,Ogrtİl=@p6,Ogrtİlce=@p7,OgrtAdres=@p8,OgrtBrans=@p9,OgrtFoto=@p10 where OgrtId=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTc.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbİl.Text);
            komut.Parameters.AddWithValue("@p7", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11",txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("personel güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Ogretmenler where OgrtId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("personel silindi","bilgi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
