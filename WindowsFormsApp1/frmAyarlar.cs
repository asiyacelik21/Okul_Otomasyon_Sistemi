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
using DevExpress.XtraLayout.Converter;

namespace WindowsFormsApp1
{
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        dbOkulEntities db=new dbOkulEntities();

        // ado.net öğretmen şifre bilgileri
        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("execute AyarlarOgretmenler",bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;

            
        }
        void OgrListele()
        {
            gridControl2.DataSource = db.AyarlarOgrenciler();
        }
        void temizle()
        {
            txtOgrtId.Text = "";
            txtOgrId.Text = "";
            txtBrans.Text = "";
            txtSinif.Text = "";
            txtOgrtSifre.Text = "";
            txtOgrSifre.Text = "";
            mskOgrtTc.Text = "";
            mskOgrTc.Text = "";
            pictureEdit2.Text = "";
            pictureEdit1.Text = "";
            lookUpEdit2.Properties.NullText = "ÖĞRETMEN SEÇİNİZ";
            lookUpEdit1.Properties.NullText = "ÖĞRENCİ SEÇİNİZ";

        }
        // ado.net ile lookupedit aracı getirme
        void ogretmenlistesi()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select OgrtId,(OgrtAd+' '+OgrtSoyad)as 'OgrtAdSoyad',OgrtBrans from Tbl_Ogretmenler", bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit2.Properties.ValueMember = "OgrtId";
            lookUpEdit2.Properties.DisplayMember = "OgrtAdSoyad";
            lookUpEdit2.Properties.NullText = "ÖĞRETMEN SEÇİNİZ";
            lookUpEdit2.Properties.DataSource = dt2;
        }
        void OgrenciListesi()
        {
            var deger = from item in db.Tbl_Ogrenciler
                        select new
                        {
                            OgrId = item.OgrId,
                            OgrAdSoyad = item.OgrAd + " " + item.OgrSoyad,
                            OgrSinif = item.OgrSinif,
                        };
            lookUpEdit1.Properties.ValueMember = "OgrId";
            lookUpEdit1.Properties.DisplayMember = "OgrSoyad";
            lookUpEdit1.Properties.NullText = "ÖĞRENCİ SEÇİNİZ";
            lookUpEdit1.Properties.DataSource = deger.ToList();

        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            ogretmenlistesi();
            OgrListele();
            OgrenciListesi();
            temizle();
        }
        public string yeniyol;
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr=gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtOgrtId.Text = dr["AyarlarId"].ToString();
                lookUpEdit2.Text = dr["OgrtAdSoyad"].ToString();
                txtBrans.Text = dr["OgrtBrans"].ToString();
                mskOgrtTc.Text = dr["OgrtTc"].ToString();
                txtOgrtSifre.Text = dr["OgrtSifre"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr["OgrtFoto"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);
            }
        }

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtOgrtSifre.Text = "";
            SqlCommand komut = new SqlCommand("select*from Tbl_Ogretmenler where OgrtId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lookUpEdit2.ItemIndex+1);
            SqlDataReader dr3=komut.ExecuteReader();
            while (dr3.Read())
            {
                txtOgrtId.Text = dr3["OgrtId"].ToString();
                txtBrans.Text = dr3["OgrtBrans"].ToString();
                mskOgrtTc.Text = dr3["OgrtTc"].ToString();
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + dr3["OgrtFoto"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);
            }
            bgl.baglanti().Close();

        }

        private void btnOgrtKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2= new SqlCommand("insert into Tbl_Ayarlar(AyarlarId,OgrtSifre)values (@p1,@p2)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",txtOgrtId.Text);
            komut2.Parameters.AddWithValue("@p2", txtOgrtSifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ŞİFRE OLUŞTURULDU","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnOgrtGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update Tbl_Ayarlar set OgrtSifre=@p1 where AyarlarId=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtOgrtSifre.Text);
            komut3.Parameters.AddWithValue("@p2", txtOgrtId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ŞİFRE GÜNCELLENDİ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnOgrtTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            txtOgrId.Text=gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"AyarlarOgrId").ToString();
            lookUpEdit1.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OgrAdSoyad").ToString();
            txtSinif.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OgrSinif").ToString();
            mskOgrTc.Text= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OgrTc").ToString();
            txtOgrSifre.Text= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OgrSifre").ToString();
            string uzanti= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OgrFoto").ToString();
            yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + uzanti;
            pictureEdit1.Image=Image.FromFile(yeniyol);
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtOgrSifre.Text = "";
            using (dbOkulEntities db=new dbOkulEntities())
            {
                Tbl_Ogrenciler sorgu = db.Tbl_Ogrenciler.Find(lookUpEdit1.ItemIndex + 1);
                txtOgrId.Text=sorgu.OgrId.ToString();
                txtSinif.Text=sorgu.OgrSinif;
                mskOgrTc.Text = sorgu.OgrTc;
                yeniyol = "C:\\Users\\asiya\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1" + "\\resimler\\" + sorgu.OgrFoto;
                pictureEdit1.Image=Image.FromFile(yeniyol);
            }
        }

        private void btnOgrKaydet_Click(object sender, EventArgs e)
        {
            Tbl_OgrAyarlar komut=new Tbl_OgrAyarlar();
            komut.AyarlarOgrId = Convert.ToInt32("txtOgrId.Text");
            komut.OgrSifre = txtOgrSifre.Text;
            db.Tbl_OgrAyarlar.Add(komut);
            db.SaveChanges();
            MessageBox.Show("ŞİFRE OLUŞTURULDU","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            OgrListele();
            temizle();
        }

        private void btnOgrGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AyarlarOgrId"));
            var item=db.Tbl_OgrAyarlar.FirstOrDefault(x=>x.AyarlarOgrId == id);
            item.OgrSifre=txtOgrSifre.Text;
            db.SaveChanges();
            MessageBox.Show("ŞİFRE GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OgrListele();
            temizle();
        }

        private void btnOgrTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
