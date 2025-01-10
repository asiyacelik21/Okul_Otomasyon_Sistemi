using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmKimlikKarti : Form
    {
        public FrmKimlikKarti()
        {
            InitializeComponent();
        }
        public string ad,soyad,tc,cinsiyet,dogTarihi,uzantı;

        private void FrmKimlikKarti_Load(object sender, EventArgs e)
        {
            lblAd.Text = ad;
            lblSoyad.Text = soyad;
            lblCinsiyet.Text = cinsiyet;
            lblTc.Text = tc;
            LblDogTr.Text = dogTarihi;
            pictureEdit1.Image = Image.FromFile(uzantı);

        }
       
    }
}
