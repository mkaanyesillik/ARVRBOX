using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanalOtobusSofor
{
    public partial class DosyaEkle : Form
    {
        public int buttonbackcolorR = 129;//
        public int buttonbackcolorG = 212;//Uygulamanın butonlarının bekleme halinde ki renk skalası(RGB Olarak)
        public int buttonbackcolorB = 250;//

        public int buttonforecolorR = 1;//
        public int buttonforecolorG = 87;//Uygulama butonlarının bekleme halinde ki font renk skalası(RGB Olarak)
        public int buttonforecolorB = 155;//

        public int buttonyayinibaslatR = 129;//
        public int buttonyayinibaslatG = 212;//Uygulama Yayını Başlat, Yayını Durdur ve Dosyaları Durdur Butonlarının Beklerken ki Renk Skalası(RGB Olarak)
        public int buttonyayinibaslatB = 250;//

        public int buttonclickbackcolorR = 179;//
        public int buttonclickbackcolorG = 229;//Uygulama Butonlarının Tıklandıktan Sonra ki Renk Skalası(RGB Olarak)
        public int buttonclickbackcolorB = 252;//

        public int buttonclickforecolorR = 0;//
        public int buttonclickforecolorG = 0;//Uygulama Butonlarının Tıklandıktan Sonra ki Font Renk Skalası(RGB Olarak)
        public int buttonclickforecolorB = 0;//

        public int buttonclickyayinibaslatR = 229;//
        public int buttonclickyayinibaslatG = 57;//Uygulama Yayını Başlat, Yayını Durdur ve Dosyaları Durdur Butonlarının Tıkladıktan Sonra ki Renk Skalası(RGB Olarak)
        public int buttonclickyayinibaslatB = 53;//



        public int formbackgroundcolorR = 0;
        public int formbackgroundcolorG = 47;
        public int formbackgroundcolorB = 108;

        public int panel1backgroundcolorR = 1;
        public int panel1backgroundcolorG = 87;
        public int panel1backgroundcolorB = 155;

        public int dgvDosyalarBackgroundColorR = 0;
        public int dgvDosyalarBackgroundColorG = 47;
        public int dgvDosyalarBackgroundColorB = 108;

        public int dgvSesDosyalarBackgroundColorR = 0;
        public int dgvSesDosyalarBackgroundColorG = 47;
        public int dgvSesDosyalarBackgroundColorB = 108;

        public string imagePause = "PauseBlue.png";
        public string imagePlay = "PlayBlue.png";
        public string imageMute = "MusicOffBlue.png";
        public string imageSoundDown = "SoundDownBlue.png";
        public string imageSoundUp = "MusicBlue.png";
        public string imageStop = "StopBlue.png";
        public string imageStream = "YayinlaBlue.png";
        public string imageBackward = "BackwardBlue.png";
        public string imageForward = "ForwardBlue.png";
        public string imageLogo = "LogoMyTek.png";
        public string appPath = Application.StartupPath;

        public DosyaEkle()
        {
            InitializeComponent();
        }
        public string FlashAdı;
       
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                btnBelgeEkle.Enabled = true;
                btnFotografEkle.Enabled = true;
                btnVideoEkle.Enabled = true;
                btnVideoEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
                btnFotografEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
                btnBelgeEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
                //string destFile = System.IO.Path.Combine(@"C:\Yayinlar", "DJI_0002.MP4");

                //foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                //{
                //    if (driveInfo.DriveType == DriveType.Removable)
                //    {
                //        string falan = driveInfo.Name.ToString()+"\\DCIM\\100MEDIA";
                //        try
                //        {
                //            if (Directory.Exists(falan))
                //            {
                //                string[] files = System.IO.Directory.GetFiles(falan);

                //                foreach (string s in files)
                //                {
                //                    destFile = System.IO.Path.Combine(@"C:\Yayinlar", "DJI_0002.mp4");

                //                    System.IO.File.Copy(s, destFile, true);
                //                }
                //            }
                //        }
                //        catch (Exception)
                //        {

                //            throw;
                //        }
                //        //Directory aa = Directory.GetDirectories(driveInfo.Name.ToString();
                //        //MessageBox.Show("Filaş bellek taktınız! Dosya Yolu ise "+driveInfo.Name.ToString());
                //        //if (Directory.GetDirectories(driveInfo.Name.ToString())==falan)
                //        //{
                //        //   MessageBox.Show(falan);
                //        //}
                //    }

                //}

            }
            base.WndProc(ref m);
        }

        private void DosyaEkle_Load(object sender, EventArgs e)
        {
            background.BackColor = Color.FromArgb(formbackgroundcolorR, formbackgroundcolorG, formbackgroundcolorB);
            this.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnVideoEkle.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
            btnFotografEkle.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
            btnBelgeEkle.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
            btnVideoEkle.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);
            btnFotografEkle.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);
            btnBelgeEkle.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);


        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnVideoEkle_MouseHover(object sender, EventArgs e)
        {
            btnVideoEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);

        }

        private void btnVideoEkle_MouseLeave(object sender, EventArgs e)
        {
            btnVideoEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

        }

        private void btnFotografEkle_MouseHover(object sender, EventArgs e)
        {
            btnFotografEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);

        }

        private void btnFotografEkle_MouseLeave(object sender, EventArgs e)
        {
            btnFotografEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

        }

        private void btnBelgeEkle_MouseHover(object sender, EventArgs e)
        {
            btnBelgeEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);

        }

        private void btnBelgeEkle_MouseLeave(object sender, EventArgs e)
        {
            btnBelgeEkle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

        }

        private void btnBelgeEkle_Click(object sender, EventArgs e)
        {
            btnBelgeEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);

        }

        private void btnFotografEkle_Click(object sender, EventArgs e)
        {
            btnFotografEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);

        }

        private void btnVideoEkle_Click(object sender, EventArgs e)
        {
            btnVideoEkle.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.DriveType == DriveType.Removable)
                {
                    string[] dosyalar = Directory.GetFiles(driveInfo.Name.ToString() + "DCIM\\100MEDIA");
                    foreach (var item in dosyalar)
                    {
                        listBox1.Items.Add(item);
                    }
                    foreach (string s in listBox1.Items)
                    {

                        File.Copy(s, Path.Combine(@"C:\Yayinlar", "DJI_0002.mp4"), true);
                    }
                }
            }
        }

        private void timerDosyalariCek_Tick(object sender, EventArgs e)
        {

        }
    }
}
