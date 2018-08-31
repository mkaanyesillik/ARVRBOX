using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SanalOtobusSofor
{
    public partial class Baslangic : Form
    {
        int sayac = 2;
        public string imageLogo = "LogoMyTek.png";
        public string appPath = Application.StartupPath;

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData,
 int dwExtraInfo);
        public Baslangic()
        {
            InitializeComponent();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            //XSplit Programını El İle Açtırtmak için bu kod yapısını kullanıyoruz.
            Process.Start(@"C:\Program Files (x86)\SplitmediaLabs\XSplit Broadcaster\x64\XSplit.Core.exe");
            label1.BorderStyle = BorderStyle.Fixed3D;
            sayac = 2;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (sayac == 2)
            {
                //Ana Kontrolcü Formuna geçiş yapmak için yeni form class'ı oluşturup bu formu gizleyerek ana formumuzu öne getiriyoruz.

                label2.BorderStyle = BorderStyle.Fixed3D;
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblError.Text == "")
            {
                lblError.Text = "Lütfen Önce Sunucuyu Açınız!";
            }
            else
            {
                lblError.Text = "";

            }
        }
        private void Baslangic_Load(object sender, EventArgs e)
        {
            picLogo.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageLogo);
        }
    }
}
