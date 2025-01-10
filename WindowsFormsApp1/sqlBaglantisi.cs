using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraBars;

namespace WindowsFormsApp1
{
    class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection(@"Data Source=LAPTOP-JDTPBNUR;Initial Catalog=dbo.OkulOtomasyonSistemi;Integrated Security=True;Encrypt=False");
            baglan.Open();
            return baglan;
        }

    }
}
