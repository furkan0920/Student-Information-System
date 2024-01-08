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

namespace E_okul
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSI-GL65\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");


        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Orange;
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_KULUPLER ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglanti.Close();
            
           
        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
            
          
            ds.OgrenciEkle(txtad.Text,txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("Ogrenci Ekleme Yapildi");

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtıd.Text = cmbkulup.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtıd.Text));
            //MessageBox.Show("Ogrenci Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
           // ds.OgrenciGuncelle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c, int.Parse(txtıd.Text));
        }

        private void rdkız_CheckedChanged(object sender, EventArgs e)
        {
            if (rdkız.Checked == true)
            {
                c = "Kız";
            }
        }

        private void rderkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rderkek.Checked == true)
            {
                c = "Erkek";
            }
           
        }

        private void btnara_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.OgrenceBul(txtara.Text);
        }
    }
}
