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
    public partial class frmdoktorpaneli : Form
    {
        public frmdoktorpaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_doktor(doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre) values(@dr1,@dr2,@dr3,@dr4,@dr5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@dr1", txtad.Text);
            komut.Parameters.AddWithValue("@dr2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@dr3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@dr4", msktc.Text);
            komut.Parameters.AddWithValue("@dr5", txtsifre.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Doktor Bilgisi Başarıyla Eklendi");
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            bgl.baglanti().Close();
        }

        private void frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select bransisim from tbl_brans",bgl.baglanti());
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);



            }
            bgl.baglanti().Close();

            //doktorları aktar
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_doktor where doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Kaydı Başarıyla Silindi");
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_doktor set doktorad=@c1, doktorsoyad=@c2, doktorbrans=@c3,doktorsifre=@c4 where doktortc=@c5",bgl.baglanti());
            komut2.Parameters.AddWithValue("@c1", txtad.Text);
            komut2.Parameters.AddWithValue("@c2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@c3", cmbbrans.Text);
            komut2.Parameters.AddWithValue("@c4", txtsifre.Text);
            komut2.Parameters.AddWithValue("@c5", msktc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Başarıyla Güncellendi..");
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
    }
}
