using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaTakipProgramı
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public Form2()
        {
            InitializeComponent();

        }
        bool isChecked;
        private void btnOnay_Click(object sender, EventArgs e)
        {
            form1.Owner = this;
            Kisi izleyen = new Kisi
            {
                AdSoyAd = txtAdSoyAd.Text,
                Tc = Convert.ToInt64(txtTc.Text)
            };
            isChecked = rdbBay.Checked;
            if (isChecked)
            {
                izleyen.Cinsiyet = rdbBay.Text;
            }
            else
            {
                izleyen.Cinsiyet = rdbBayan.Text;
            }
            form1.dinamikbutton.Image = Image.FromFile(@"C:\Users\Yunus\Desktop\veripark\kirmizi.png");
            izleyen.KisiId = form1.dinamikbutton.TabIndex;
            form1.kisiler.Add(izleyen);
            form1.listeyiguncelle();
            this.Hide();
            

        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
         
            for (int i = 0; i < form1.kisiler.Count; i++)
            {
                if (txtAdSoyAd.Text == form1.kisiler[i].AdSoyAd && txtTc.Text == form1.kisiler[i].Tc.ToString())
                {
                    txtAdSoyAd.Clear();
                    txtTc.Clear();
                    rdbBay.Checked = false;
                    rdbBayan.Checked = false;
                    form1.kisiler.Remove(form1.kisiler[i]);

                    if (label4.Text != null)
                    {
                        label4.Text = " ";
                    }
                    btnOnay.Enabled = true;
                    form1.listeyiguncelle();
                }
                form1.dinamikbutton.Image = Image.FromFile(@"C:\Users\Yunus\Desktop\veripark\mavi.png");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (txtAdSoyAd.Text!= "")
            {
                btnOnay.Enabled = false;
            }
        }
    }
}
