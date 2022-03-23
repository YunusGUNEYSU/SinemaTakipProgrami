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

    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }
        public List<Kisi> kisiler = new List<Kisi>();

        private void Form1_Load(object sender, EventArgs e)
        {  
            int sayac = 0;
            int x = 6;
            int y = 12;
            for (int i = 0; i < x; i++)
            {

                for (int j = 0; j < y; j++)
                {
                    sayac++;
                    Button btn = new Button
                    {
                        Name = "button" + sayac,
                        Size = new Size(50, 50),
                        Location = new Point(50 +55 * j, 30 + 60 * i),
                        Image = Image.FromFile(@"C:\Users\Yunus\Desktop\veripark\mavi.png")
                    };
                    if (i % 2 == 0)
                    {
                        if (j == 0 || j == 1 || j == 10 || j == 11)
                        {
                            btn.Visible = false;
                        } 
                    }
                    groupBox1.Controls.Add(btn);
                    btn.TabIndex = sayac;
                    btn.Click += new EventHandler(dinamik);
                }

            }
        }
        public void listeyiguncelle()
        {
            lstSeyirci.Items.Clear();
            for (int i = 0; i < kisiler.Count; i++)
            {
                string value= "\n AdSoyad: " + kisiler[i].AdSoyAd + "\t Cinsiyet:" + kisiler[i].Cinsiyet + "\t tc:" + kisiler[i].Tc.ToString();
                lstSeyirci.Items.Add(value);

            }

        }
       public Button dinamikbutton = new Button();
        public void dinamik(object sender, EventArgs e)
        {
            form2 = new Form2();
            dinamikbutton = (sender as Button);
            form2.form1 = this;
            foreach (var kisi in kisiler)
            {
                if (kisi.KisiId == dinamikbutton.TabIndex)
                {
                    form2.txtAdSoyAd.Text = kisi.AdSoyAd;
                    form2.txtTc.Text = kisi.Tc.ToString();
                    break;
                }
                form2.txtAdSoyAd.Text = "";
                form2.txtTc.Text = "";
            }
            form2.Show();
          

        }



        private void btnRapor_Click(object sender, EventArgs e)
        {
            int toplam = lstSeyirci.Items.Count;
            MessageBox.Show("Toplamseyircisayısı: " + toplam.ToString());
        }
    }
}
