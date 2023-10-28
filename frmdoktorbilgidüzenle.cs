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

namespace hastene_otomasyon
{
    public partial class frmdoktorbilgidüzenle : Form
    {
        public frmdoktorbilgidüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string dtc;
        private void btnbilgigüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update  tbl_doktor set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p3,doktorsifre=@p4 where doktortc=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbnrans.Text);
            komut.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut.Parameters.AddWithValue("@p5", msktc.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı");
            bgl.baglanti().Close();
        }

        private void frmdoktorbilgidüzenle_Load(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand(" select bransisim from tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbnrans.Items.Add(dr2[0]);



            }
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("select * from tbl_doktor where doktortc=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",dtc );
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbnrans.Text = dr[3].ToString();
                msktc.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();

                


            }
            bgl.baglanti().Close();
        }
    }
}
