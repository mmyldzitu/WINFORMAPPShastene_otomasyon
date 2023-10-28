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
    public partial class frmhastadetay : Form
    {
        public frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmhastadetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //ad-soyad çekme kısmı
            SqlCommand komut = new SqlCommand("select hastaad,hastasoyad from tbl_hasta where hastatc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];


            }
            bgl.baglanti().Close();

            //randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tabl_randevu where hastatc="+ tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //branşları çekme
            SqlCommand komut2 = new SqlCommand(" select bransisim from tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]); 



            }
            bgl.baglanti().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktorlisteleme
            cmbdoktor.Items.Clear();
            cmbdoktor.Text = "";
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktor where doktorbrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " + dr[1]);


            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tabl_randevu where randevubrans='" + cmbbrans.Text + "'" + "and randevudoktor='" + cmbdoktor.Text+"' and randevudurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkbilgidüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmbilgidüzenle fr = new frmbilgidüzenle();
            fr.tc = lbltc.Text;

            fr.Show();

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtıd.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tabl_randevu set randevudurum=1,hastatc=@p1,sikayet=@p2 where randevuid=@p3",bgl.baglanti());

            


            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            komut.Parameters.AddWithValue("@p2", rchsikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu alma işleminiz başarıyla gerçekleştirilmiştir..");


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tabl_randevu where hastatc=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
