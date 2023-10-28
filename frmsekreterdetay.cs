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
    public partial class frmsekreterdetay : Form
    {
        public frmsekreterdetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        private void yenileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //branşları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" select bransid as Id, bransisim as İSİM from tbl_brans", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //doktorları aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorad+ ' ' +doktorsoyad) as Doktorlar,doktorbrans as Branşları from tbl_doktor", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //branşları getime
            SqlCommand komut2 = new SqlCommand(" select bransisim from tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbrans.Items.Add(dr2[0]);



            }
            bgl.baglanti().Close();

        }
        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();

            }
            bgl.baglanti().Close();

            //branşları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" select bransid as Id, bransisim as İSİM from tbl_brans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //doktorları aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorad+ ' ' +doktorsoyad) as Doktorlar,doktorbrans as Branşları from tbl_doktor",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //branşları getime
            SqlCommand komut2 = new SqlCommand(" select bransisim from tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbrans.Items.Add(dr2[0]);



            }
            bgl.baglanti().Close();





        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tabl_randevu (randevutarih,randevusaat,randevubrans,randevudoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Kaydı Gerçekleşti..");
            



        }

        private void cmbrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbdoktor.Items.Clear();
            cmbdoktor.Text = "";
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktor where doktorbrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);


            }
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" select bransid as Id, bransisim as İSİM from tbl_brans", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyuru (duyurum) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchduyuru.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Duyuru Başarıyla Oluşturuldu..");
            bgl.baglanti().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmdoktorpaneli fr = new frmdoktorpaneli();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmbrans fr = new frmbrans();
            fr.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmrandevulistesi fr = new frmrandevulistesi();
            fr.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmduyurular fr = new frmduyurular();
            fr.Show();
            
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmdeneme fr = new frmdeneme();
            fr.Show();
        }
    }
}
