using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_okul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr=new FrmKulup();
            fr.Show();
            this.Hide();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void btnders_Click(object sender, EventArgs e)
        {
            FrmDersler fr=new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void btnogrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr=new FrmOgrenci();
            fr.Show();
        }

        private void btnsınavnotlar_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr=new FrmSınavNotlar();
            fr.Show();
            this.Hide();
        }
    }
}
