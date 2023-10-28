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
    public partial class frmhastagiris : Form
    {
        public frmhastagiris()
        {
            InitializeComponent();
        }

        private void lnkhastaüyelik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhastakayit fr = new frmhastakayit();
            fr.Show();
           
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnhastagiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_hasta where hastatc=@p1 and hastasifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MSKTC.Text);
            komut.Parameters.AddWithValue("@p2", txthastasifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frmhastadetay frm = new frmhastadetay();
                frm.tc = MSKTC.Text;
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı şifre veya TC");
            }
            bgl.baglanti().Close();
        }
    }
}
