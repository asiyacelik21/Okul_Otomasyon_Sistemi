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
using DevExpress.XtraBars.Docking;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using DevExpress.XtraLayout.Resizing;


namespace WindowsFormsApp1
{
    public partial class frmOgrenciler : Form
    {
        public frmOgrenciler()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();

        void listele()
        {
            //5.sınıf
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1=new SqlDataAdapter("execute OgrenciVeli5",bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;

            //6.sınıf
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("execute OgrenciVeli6", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;

            //7.sınıf
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("execute OgrenciVeli7", bgl.baglanti());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;

            //8.sınıf
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("execute OgrenciVeli8", bgl.baglanti());
            da4.Fill(dt4);
            gridControl4.DataSource = dt4;

        }
        void velilistesi()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select VeliId,(VeliAnne+'|'+VeliBaba)as VeliAnneBaba from Tbl_Veliler",bgl.baglanti());
            da.Fill(dt1);
            lookUpEdit1.Properties.ValueMember = "VeliId";
            lookUpEdit1.Properties.DisplayMember = "VeliAnneBaba";
            lookUpEdit1.Properties.DataSource = dt1;

        }

        void sehirEkle()
        {
            SqlCommand komut = new SqlCommand("select*from Tbl_iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskOgrNo.Text = "";
            mskTc.Text = "";
            rdbtnErkek.Checked = false;
            rdbtnKiz.Checked = false;
            cmbSinif.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            dateEdit1.Text = "";
            rchAdres.Text = "";
            pictureEdit1.Text = "";
        }
        private void frmOgrenciler_Load(object sender, EventArgs e)
        {
            listele();
            sehirEkle();
            velilistesi();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            cmbilce.Text = "";

            SqlCommand komut = new SqlCommand("select*from ilceler where isim='@p1'", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        public string Cinsiyet;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Tbl_Ogrenciler(OgrAd,OgrSoyad,OgrNo,OgrSinif,OgrDogTar,OgrCinsiyet,OgrTc,Ogrİl,Ogrİlce,OgrAdres,OgrFoto,OgrVeliId)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskOgrNo.Text);
            komut.Parameters.AddWithValue("@p4", cmbSinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (rdbtnErkek.Checked==true)
            {
                komut.Parameters.AddWithValue("@p6",Cinsiyet="e");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", Cinsiyet = "k");
            }
            komut.Parameters.AddWithValue("@p7", mskTc.Text);
            komut.Parameters.AddWithValue("@p8", cmbil.Text);
            komut.Parameters.AddWithValue("@p9", cmbilce.Text);
            komut.Parameters.AddWithValue("@p10",rchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("öğrenci ekelndi","bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                txtId.Text = dr["OgrId"].ToString();
                txtAd.Text = dr["OgrAd"].ToString() ;
                txtSoyad.Text = dr["OgrSoyad"].ToString();
                mskTc.Text = dr["OgrTc"].ToString();
                mskOgrNo.Text = dr["OgrNo"].ToString();
                cmbSinif.Text = dr["OgrSinif"].ToString();
                if (dr["OgrCinsiyet"].ToString()=="e")
                {
                    rdbtnErkek.Checked = true;
                }
                else
                {
                    rdbtnKiz.Checked = true;
                }
                cmbil.Text = dr["Ogrİl"].ToString();
                cmbilce.Text = dr["Ogrİlce"].ToString();
                dateEdit1.Text = dr["OgrDogTar"].ToString();
                rchAdres.Text = dr["OgrAdres"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrFoto"].ToString();
                 pictureEdit1.Image=Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VeliAnneBaba"].ToString();
            }
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["OgrId"].ToString();
                txtAd.Text = dr["OgrAd"].ToString();
                txtSoyad.Text = dr["OgrSoyad"].ToString();
                mskTc.Text = dr["OgrTc"].ToString();
                mskOgrNo.Text = dr["OgrNo"].ToString();
                cmbSinif.Text = dr["OgrSinif"].ToString();
                if (dr["OgrCinsiyet"].ToString() == "e")
                {
                    rdbtnErkek.Checked = true;
                }
                else
                {
                    rdbtnKiz.Checked = true;
                }
                cmbil.Text = dr["Ogrİl"].ToString();
                cmbilce.Text = dr["Ogrİlce"].ToString();
                dateEdit1.Text = dr["OgrDogTar"].ToString();
                rchAdres.Text = dr["OgrAdres"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrFoto"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VeliAnneBaba"].ToString();
            }
        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["OgrId"].ToString();
                txtAd.Text = dr["OgrAd"].ToString();
                txtSoyad.Text = dr["OgrSoyad"].ToString();
                mskTc.Text = dr["OgrTc"].ToString();
                mskOgrNo.Text = dr["OgrNo"].ToString();
                cmbSinif.Text = dr["OgrSinif"].ToString();
                if (dr["OgrCinsiyet"].ToString() == "e")
                {
                    rdbtnErkek.Checked = true;
                }
                else
                {
                    rdbtnKiz.Checked = true;
                }
                cmbil.Text = dr["Ogrİl"].ToString();
                cmbilce.Text = dr["Ogrİlce"].ToString();
                dateEdit1.Text = dr["OgrDogTar"].ToString();
                rchAdres.Text = dr["OgrAdres"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrFoto"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VeliAnneBaba"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["OgrId"].ToString();
                txtAd.Text = dr["OgrAd"].ToString();
                txtSoyad.Text = dr["OgrSoyad"].ToString();
                mskTc.Text = dr["OgrTc"].ToString();
                mskOgrNo.Text = dr["OgrNo"].ToString();
                cmbSinif.Text = dr["OgrSinif"].ToString();
                if (dr["OgrCinsiyet"].ToString() == "e")
                {
                    rdbtnErkek.Checked = true;
                }
                else
                {
                    rdbtnKiz.Checked = true;
                }
                cmbil.Text = dr["Ogrİl"].ToString();
                cmbilce.Text = dr["Ogrİlce"].ToString();
                dateEdit1.Text = dr["OgrDogTar"].ToString();
                rchAdres.Text = dr["OgrAdres"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrFoto"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VeliAnneBaba"].ToString();
            }
        }
        public string yeniyol;

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter="resim dosyası | *.jpg;*.png;*.nef | tüm dosyalar|*.*";
            dosya.ShowDialog();
            string dosyayolu= dosya.FileName;
            yeniyol= "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1"+"\\resimler\\"+ Guid.NewGuid().ToString()+ ".jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureEdit1.Image = Image.FromFile(yeniyol);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("Update Tbl_Ogrenciler set OgrAd=@p1,OgrSoyad=@p2,OgrNo=@p3,OgrSinif=@p4,OgrDogTar=@p5,OgrCinsiyet=@p6,OgrTc=@p7,Ogrİl=@p8,Ogrİlce=@p9,OgrAdres=@p10,OgrFoto=@p11,OgrVeliId=@p12 where OgrId=@p13",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskOgrNo.Text);
            komut.Parameters.AddWithValue("@p4", cmbSinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (rdbtnErkek.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6", Cinsiyet = "e");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", Cinsiyet = "k");
            }
            komut.Parameters.AddWithValue("@p7", mskTc.Text);
            komut.Parameters.AddWithValue("@p8", cmbil.Text);
            komut.Parameters.AddWithValue("@p9", cmbilce.Text);
            komut.Parameters.AddWithValue("@p10", rchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12",txtId.Text);
            komut.Parameters.AddWithValue("@p13", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("öğrenci bilgileri güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Delete from Tbl_Ogrenciler where OgrId=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("öğrenci bilgileri silindi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmKimlikKarti frm =new FrmKimlikKarti();
            if (dr!= null)
            {
                frm.ad = dr["OgrAd"].ToString();
                frm .soyad = dr["OgrSoyad"].ToString() ;
                frm.tc = dr["OgrTc"].ToString();
                frm.cinsiyet = dr["OgrCinsiyet"].ToString();
                frm.dogTarihi = dr["OgrDogTar"].ToString();
                frm.uzantı = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrFoto"].ToString();

            }
            frm.Show();
        }
    }
}
