using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastene_otomasyon
{
    class sqlbaglantisi
    {

        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-5VAB06RE\\SQLEXPRESS;Initial Catalog=hasteneproje;Integrated Security=True");
            baglan.Open();
            return baglan;


        }
    }
}
