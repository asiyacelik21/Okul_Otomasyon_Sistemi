using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Helpers;

namespace WindowsFormsApp1
{
    public partial class FrmVeliler : Form
    {
        public FrmVeliler()
        {
            InitializeComponent();
        }
        dbOkulEntities db=new dbOkulEntities();

        void listele()
        {

            var liste = from item in db.Tbl_Veliler
                        select new { item.VeliId, item.VeliAnne, item.VeliBaba, item.VeliTel1, item.VeliTel2, item.VeliMail };
            gridControl1.DataSource = liste.ToList();

        }
        void temizle()
        {
            txtId.Text = "";
            txtAnne.Text = "";
            txtBabaAd.Text = "";
            txtMail.Text = "";
            mskTel1.Text="";
            mskTel2.Text = "";
        }

        private void FrmVeliler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Veliler veliler = new Tbl_Veliler();
            veliler.VeliAnne = txtAnneAd.Text;
            veliler.VeliBaba=txtBabaAd.Text;
            veliler.VeliTel1=mskTel1.Text;
            veliler.VeliTel2= mskTel2.Text;
            veliler.VeliMail=txtMail.Text;
            db.Tbl_Veliler.Add(veliler);
            db.SaveChanges();
            listele();
            temizle();

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            txtId.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VeliId").ToString();
            txtAnne.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliAnne").ToString();
            txtBabaAd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliBaba").ToString();
            mskTel1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliTel1").ToString();
            mskTel2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliTel2").ToString();
            txtMail.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliMail").ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int Id=Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliId").ToString());
            //var İtem=db.Tbl_Veliler.Find(Id);
           // İtem.VeliAnne=txtAnneAd.Text;
            //İtem.VeliBaba=txtBabaAd.Text;
           // İtem.VeliTel1=mskTel1.Text;
            //İtem.VeliTel2=mskTel2.Text;
           // İtem.VeliMail=txtMail.Text;
            //db.SaveChanges();
            //listele();
            //temizle();
            using(dbOkulEntities db=new dbOkulEntities())
            {
                var İtem=db.Tbl_Veliler.FirstOrDefault(x=> x.VeliId==Id);
                İtem.VeliAnne=txtAnne.Text;
                İtem.VeliBaba=txtBabaAd.Text;
                İtem.VeliTel1=mskTel1.Text;
                İtem.VeliTel2 = mskTel2.Text;
                İtem.VeliMail=txtMail.Text;
                db.SaveChanges();
                listele();
                temizle();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VeliId").ToString());
            //var İtem = db.Tbl_Veliler.Find(Id);
            //db.Tbl_Veliler.Remove(İtem);
            //db.SaveChanges();
            //listele();
           // temizle();
           using (dbOkulEntities db = new dbOkulEntities())
            {
                var İtem=db.Tbl_Veliler.FirstOrDefault(x=> x.VeliId==Id);
                db.Tbl_Veliler.Remove(İtem);
                db.SaveChanges();
                listele();
                temizle();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
