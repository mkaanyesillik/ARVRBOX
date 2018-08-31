using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WMPLib;
using System.Diagnostics;
using Microsoft.Win32;

namespace SanalOtobusSofor
{
    public partial class Form1 : Form
    {
        public string ProgramAdi = "SanalOtobus";
        public int buton = 2;//Ses Dosyalarının aktif olması için fotoğraf listele butonu gerekmekte fotograf listele butonuna basılıp basılmadığını kontrol etmek için yazıldı.
        public int sayac = 1;//Ses Kısma ve Ses Açma için if döngüsü kontrolünde kullanılmakta.
        public string secilendosyaadi;//Dosyaları Önizleme ve Yayınlama için DataGridView içerisinden seçilen dosya yolunu içerisine atıyoruz.
        public int buttononizle = 1;//Uygulama açılır açılmaz dosya seçmeden Önizle butonuna basılmasını engellemek için if döngüsü içerisinde kullanıyoruz.
        public int onizlemesesi = 1;//Önizleme Sesinin Aç Kapat Butonunun kontrolü için gerekli olan değişken.
        public int yayinsesi = 1;//Yayın Sesini Ayarlamak İçin Kullanılan Değişken.

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



        public Form1()
        {

            InitializeComponent();

        }
        private void btnYayiniBaslat_Click(object sender, EventArgs e)
        {
            picVideo.Visible = false;//solda ki picturebox'ın görüntüsünü kaldırıp yayını izlemenizi sağlıyor.

            if (btnYayiniBaslat.Text == "BAŞLAT")
            {
                btnYayiniBaslat.Text = "BAŞLADI";
                btnYayiniBaslat.ForeColor = Color.Black;
                btnYayiniBaslat.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
                timer2.Enabled = true;
                timer2.Interval = 7000;
                Process.Start("bg.jpg");
                SendKeys.Send("{F9}");
                axVLCPlugin21.playlist.stop();
                axVLCPlugin21.playlist.items.remove(0);
                SendKeys.Send("{F11}");
            }
            else
            {
                SendKeys.Send("{F12}");
                btnYayiniBaslat.Text = "BAŞLAT";
                btnYayiniBaslat.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);
                btnYayiniBaslat.BackColor = Color.FromArgb(buttonyayinibaslatR, buttonyayinibaslatG, buttonyayinibaslatB);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");
            axWindowsMediaPlayer1.uiMode = "none";//Media Player Embedin Kontrol elemanlarını kapatıyor.
            axWindowsMediaPlayer2.settings.volume = 100;//Ses için embed olan mediaplayerin sesini %100 yapıyor.
            axWindowsMediaPlayer1.settings.volume = 0;//Önizleme için gömülmüş media playerin sesini %0 yapıyor.
            SendKeys.Send("6");
            this.BackColor = Color.FromArgb(formbackgroundcolorR, formbackgroundcolorG, formbackgroundcolorB);
            panel1.BackColor = Color.FromArgb(panel1backgroundcolorR, panel1backgroundcolorG, panel1backgroundcolorB);
            dgvDosyaListesi.BackgroundColor = Color.FromArgb(dgvDosyalarBackgroundColorR, dgvDosyalarBackgroundColorG, dgvDosyalarBackgroundColorB);
            dgvSesDosyalari.BackgroundColor = Color.FromArgb(dgvSesDosyalarBackgroundColorR, dgvSesDosyalarBackgroundColorG, dgvSesDosyalarBackgroundColorB);
            ///////////////////////////////////////////////Önizleme/////////////////////////////////////////////////////
            btnOnizlemeDuraklat.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePause);
            btnOnizlemeDurdur.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageStop);
            btnOnizlemeGeriSar.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageBackward);
            btnOnizlemeIleriSar.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageForward);
            btnOnizlemeOynat.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePlay);
            btnOnizlemeSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageMute);
            /////////////////////////////////////////////////Ses////////////////////////////////////////////////////////
            btnSesiArttir.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageSoundUp);
            btnSesiDevamEttir.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePlay);
            btnSesiDuraklat.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePause);
            btnSesiDurdur.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageStop);
            btnSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageMute);
            btnSesiYayinla.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageStream);
            //////////////////////////////////////////////////Yayına Al/////////////////////////////////////////////////
            btnYayiniGeriSar.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageBackward);
            btnYayiniIleriSar.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageForward);
            btnYayinSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageMute);
            btnYayiniDevamEttir.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePlay);
            btnYayiniDuraklat.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imagePause);
            btnYayiniDurdur.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageStop);
            picFotoOnizleme.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageLogo);
            picVideo.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageLogo);
            picLogo.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageLogo);
        }

        private void btnOnizlemeDuraklat_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            btnOnizlemeDuraklat.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnOnizlemeOynat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnOnizlemeDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
        }

        private void btnOnizlemeOynat_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            btnOnizlemeOynat.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnOnizlemeDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnOnizlemeDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
        }

        private void btnOnizlemeSesiKis_Click(object sender, EventArgs e)
        {
            if (onizlemesesi == 1)
            {
                axWindowsMediaPlayer1.settings.volume = 100;
                btnOnizlemeSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageMute);
                onizlemesesi++;
            }
            else if (onizlemesesi == 2)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
                btnOnizlemeSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageSoundUp);
                onizlemesesi--;
            }
        }

        private void btnOnizlemeIleriSar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }

        private void btnOnizlemeGeriSar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }

        private void btnOnizlemeDurdur_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            btnOnizle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnOnizlemeOynat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnOnizlemeDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnOnizlemeDurdur.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
        }

        private void btnYayiniDuraklat_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");//Dışarda ki VLC Playerin Kısayol Tuşunu Gönderiyor.
            btnYayiniDuraklat.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnYayiniDevamEttir.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnYayiniDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
        }

        private void btnYayiniOynat_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");//Dışarda ki VLC Playerin Kısayol Tuşunu Gönderiyor.
            btnYayiniDevamEttir.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnYayiniDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnYayiniDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
        }

        private void btnYayinSesiKapat_Click(object sender, EventArgs e)
        {
            if (yayinsesi == 1)
            {
                SendKeys.Send("2");//Dışarda ki VLC Playerin Kısayol Tuşunu Gönderiyor.
                btnYayinSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageMute);

                yayinsesi = 2;
            }
            else
            {
                SendKeys.Send("2");
                btnYayinSesiKis.BackgroundImage = Image.FromFile(appPath.ToString() + "\\Resources\\" + imageSoundUp);
                yayinsesi = 1;
            }
        }

        private void btnYayinIleriSar_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");//Dışarda ki VLC Playerin Kısayol Tuşunu Gönderiyor.
        }

        private void btnYayinGeriSar_Click(object sender, EventArgs e)
        {
            SendKeys.Send("ü");//Dışarda ki VLC Playerin Kısayol Tuşunu Gönderiyor.
        }

        private void btnYayiniDurdur_Click(object sender, EventArgs e)
        {
            Process.Start("bg.jpg");//bg.jpg dosyasını açarak yayın ekranına dilediğimiz resmi basıyoruz.
            btnYayinaAl.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnYayiniDevamEttir.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnYayiniDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnYayiniDurdur.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.add("rtmp://192.168.1.20:1935/app&buffer=1&forceObjectEncoding=0");//RTPM Yayının URL Linkini buraya vererek Yayını bizimde izlememizi sağlıyoruz.
            axVLCPlugin21.playlist.play();
        }

        private void btnSesiYayinla_Click(object sender, EventArgs e)
        {

            if (dgvSesDosyalari.Rows != null)
            {
                btnSesiYayinla.Enabled = true;
                string deger = dgvSesDosyalari.CurrentRow.Cells["SesYolu"].Value.ToString();
                axWindowsMediaPlayer2.URL = deger.ToString();
                axWindowsMediaPlayer2.settings.setMode("loop", true);
                btnSesiYayinla.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
                btnSesiDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);


            }
            else
            {
                btnSesiYayinla.Enabled = false;
                btnSesiYayinla.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

            }
        }

        private void btnSesiDuraklat_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            btnSesiDuraklat.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnSesiDevamEttir.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnSesiDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

        }

        private void btnSesiDevamEttir_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
            btnSesiDevamEttir.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnSesiDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnSesiDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);


        }

        private void btnSesiKis_Click(object sender, EventArgs e)
        {
            if (sayac == 1)
            {
                axWindowsMediaPlayer2.settings.volume = 100;
                sayac++;
            }
            else if (sayac == 2)
            {
                axWindowsMediaPlayer2.settings.volume = 90;
                sayac++;
            }
            else if (sayac == 3)
            {
                axWindowsMediaPlayer2.settings.volume = 80;
                sayac++;
            }
            else if (sayac == 4)
            {
                axWindowsMediaPlayer2.settings.volume = 70;
                sayac++;
            }
            else if (sayac == 5)
            {
                axWindowsMediaPlayer2.settings.volume = 60;
                sayac++;
            }
            else if (sayac == 6)
            {
                axWindowsMediaPlayer2.settings.volume = 50;
                sayac++;
            }
            else if (sayac == 7)
            {
                axWindowsMediaPlayer2.settings.volume = 40;
                sayac++;
            }
            else if (sayac == 8)
            {
                axWindowsMediaPlayer2.settings.volume = 30;
                sayac++;
            }
            else if (sayac == 9)
            {
                axWindowsMediaPlayer2.settings.volume = 20;
                sayac++;
            }
            else if (sayac == 10)
            {
                axWindowsMediaPlayer2.settings.volume = 10;
                sayac++;
            }
            else if (sayac == 11)
            {
                axWindowsMediaPlayer2.settings.volume = 0;
            }
            else
            {
                axWindowsMediaPlayer2.settings.volume = 0;
            }
        }

        private void btnSesArttir_Click(object sender, EventArgs e)
        {
            if (sayac == 11)
            {
                axWindowsMediaPlayer2.settings.volume = 0;
                sayac--;
            }
            else if (sayac == 10)
            {
                axWindowsMediaPlayer2.settings.volume = 10;
                sayac--;
            }
            else if (sayac == 9)
            {
                axWindowsMediaPlayer2.settings.volume = 20;
                sayac--;
            }
            else if (sayac == 8)
            {
                axWindowsMediaPlayer2.settings.volume = 30;
                sayac--;
            }
            else if (sayac == 7)
            {
                axWindowsMediaPlayer2.settings.volume = 40;
                sayac--;
            }
            else if (sayac == 6)
            {
                axWindowsMediaPlayer2.settings.volume = 50;
                sayac--;
            }
            else if (sayac == 5)
            {
                axWindowsMediaPlayer2.settings.volume = 60;
                sayac--;
            }
            else if (sayac == 4)
            {
                axWindowsMediaPlayer2.settings.volume = 70;
                sayac--;
            }
            else if (sayac == 3)
            {
                axWindowsMediaPlayer2.settings.volume = 80;
                sayac--;
            }
            else if (sayac == 2)
            {
                axWindowsMediaPlayer2.settings.volume = 90;
                sayac--;
            }
            else if (sayac == 1)
            {
                axWindowsMediaPlayer2.settings.volume = 100;
            }
            else
            {
                axWindowsMediaPlayer2.settings.volume = 100;
            }
        }

        private void btnSesiDurdur_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
            btnSesiYayinla.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnSesiDevamEttir.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnSesiDuraklat.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnSesiDurdur.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);

        }

        private void btnVideoListele_Click(object sender, EventArgs e)
        {
            //dgvKlasorListesi.Rows.Clear();
            buttononizle = 1;
            btnOnizle.Text = "ÖNİZLE";
            axWindowsMediaPlayer1.Visible = true;

            btnFotografListele.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnFotografListele.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);
            btnVideoListele.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnVideoListele.ForeColor = Color.FromArgb(buttonclickforecolorR, buttonclickforecolorG, buttonclickforecolorB);
            buton = 2;
            dgvDosyaListesi.Rows.Clear();
            string[] dosyalar = Directory.GetDirectories(@"c:\Yayinlar\Videolar\");
            foreach (var item in dosyalar)
            {
                //dgvKlasorListesi.Rows.Add(Path.GetFileNameWithoutExtension(item), item);
            }
            dgvSesDosyalari.Visible = false;
            btnSesiArttir.Visible = false;
            btnSesiDuraklat.Visible = false;
            btnSesiDurdur.Visible = false;
            btnSesiKis.Visible = false;
            btnSesiYayinla.Visible = false;
            btnSesiDevamEttir.Visible = false;
        }

        private void btnFotografListele_Click_1(object sender, EventArgs e)
        {
            buttononizle = 1;
            btnOnizle.Text = "ÖNİZLE";
            btnVideoListele.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            btnVideoListele.ForeColor = Color.FromArgb(buttonforecolorR, buttonforecolorG, buttonforecolorB);
            btnFotografListele.BackColor = Color.FromArgb(buttonclickbackcolorR, buttonclickbackcolorG, buttonclickbackcolorB);
            btnFotografListele.ForeColor = Color.FromArgb(buttonclickforecolorR, buttonclickforecolorG, buttonclickforecolorB);
            buton = 1;
            //dgvKlasorListesi.Rows.Clear();
            axWindowsMediaPlayer1.Visible = false;
            picFotoOnizleme.Visible = true;
            dgvDosyaListesi.Rows.Clear();
            string[] dosyalar = Directory.GetDirectories(@"c:\Yayinlar\Fotograflar\");
            foreach (var item in dosyalar)
            {
                // dgvKlasorListesi.Rows.Add(Path.GetFileNameWithoutExtension(item), item);
            }

        }

        private void btnYayinaAl_Click(object sender, EventArgs e)
        {
            SendKeys.Send("9");
            SendKeys.Send("{F12}");
            string deger = dgvDosyaListesi.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            btnYayinaAl.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
            btnYayiniDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
            lblYayinlanan.Text = dgvDosyaListesi.CurrentRow.Cells["DosyaAdi"].Value.ToString().ToUpper();


            //btnYayinla.Enabled = false;
            Process.Start(deger.ToString());
            SendKeys.Send("3");
        }

        private void btnOnizle_Click_1(object sender, EventArgs e)
        {
            if (buttononizle == 1)
            {
                btnYayinaAl.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
                picFotoOnizleme.Visible = false;
                axWindowsMediaPlayer1.Visible = true;

                string deger = dgvDosyaListesi.CurrentRow.Cells["DosyaYolu"].Value.ToString();
                axWindowsMediaPlayer1.URL = deger.ToString();
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                btnOnizle.Text = "ÖNİZLE";
                secilendosyaadi = dgvDosyaListesi.CurrentRow.Cells["DosyaYolu"].Value.ToString();
                btnOnizle.BackColor = Color.FromArgb(buttonclickyayinibaslatR, buttonclickyayinibaslatG, buttonclickyayinibaslatB);
                btnOnizlemeDurdur.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);



                if (dgvDosyaListesi.Rows == null)
                {
                    btnOnizle.Text = "LÜTFEN MEDYA SEÇİNİZ!";
                }
                else
                {
                    if (buton == 1)
                    {

                        int position = dgvDosyaListesi.CurrentRow.Cells["DosyaAdi"].Value.ToString().IndexOf("_0");
                        string fileName = dgvDosyaListesi.CurrentRow.Cells["DosyaAdi"].Value.ToString().Substring(0, position);
                        dgvSesDosyalari.Rows.Clear();
                        lblOnizlenen.Text = fileName.ToString().ToUpper();

                        string[] dosyalar = Directory.GetFiles(@"c:\Yayinlar\Fotograflar\Manisa", fileName + "*.mp3");
                        if (fileName != "")
                        {
                            dgvSesDosyalari.Visible = true;
                            btnSesiArttir.Visible = true;
                            btnSesiDuraklat.Visible = true;
                            btnSesiDurdur.Visible = true;
                            btnSesiKis.Visible = true;
                            btnSesiYayinla.Visible = true;
                            btnSesiDevamEttir.Visible = true;
                        }
                        foreach (var item in dosyalar)
                        {
                            dgvSesDosyalari.Rows.Add(Path.GetFileNameWithoutExtension(item), item);
                        }
                    }



                }
            }
            else
            {
                btnOnizle.Text = "LÜTFEN LİSTE SEÇİNİZ!";
            }

        }

        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            //Process.Start("shutdown", "/s /f /t 0");
            Application.Exit();
        }

        private void dgvSesDosyalari_SelectionChanged(object sender, EventArgs e)
        {
            btnSesiYayinla.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnOnizle.BackColor = Color.FromArgb(buttonbackcolorR, buttonbackcolorG, buttonbackcolorB);
        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            DosyaEkle dosyaekle = new DosyaEkle();
            dosyaekle.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //secilendosyaadi = dgvKlasorListesi.CurrentRow.Cells["KlasorYolu"].Value.ToString();
            dgvDosyaListesi.Rows.Clear();
            string[] dosyalar = Directory.GetFiles(secilendosyaadi);
            foreach (var item in dosyalar)
            {
                if (item.ToString().Substring(item.ToString().Length - 3, 3) == "jpg" || item.ToString().Substring(item.ToString().Length - 3, 3) == "m4v")
                {
                    dgvDosyaListesi.Rows.Add(Path.GetFileNameWithoutExtension(item), item);

                }
            }
        }

        private void btnFotoGaleri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Özellik Şu An İçin Aktif Değildir!", "Sanal Otobüs MyTek");
        }

        private void btnVideoGaleri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Özellik Şu An İçin Aktif Değildir!", "Sanal Otobüs MyTek");

        }

        private void cmbiller_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgvDosyaListesi.Rows.Clear();

            switch (cmbiller.Text == "Manisa")
            {

                default:

                    dgvDosyaListesi.Rows.Clear();
                    //string[] dosyalar = Directory.GetFiles(@"c:\Yayinlar\Videolar\");
                    altdizinarama(@"c:\Yayinlar\");
                    break;
            }
        }
        private void altdizinarama(String yol)
        {
            string[] dosya = Directory.GetFiles(yol, "*.*");
            for (int i = 0; i < 1; i++)
            {
                dgvDosyaListesi.Rows.Add(dosya);
                string[] dizin;
                dizin = Directory.GetDirectories(yol);
                for (int s = 0; s < dizin.Length; s++)
                {
                    altdizinarama(dizin[s]);
                }
            }
        }

        private void cmbMekanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label1.Visible = false;
            switch (cmbiller.Text)
            {
                case "Tüm Mekanlar":
                    dgvDosyaListesi.Rows.Clear();
                    //string[] dosyalar = Directory.GetFiles(@"c:\Yayinlar\Videolar\");

                    int position = dgvDosyaListesi.CurrentRow.Cells["DosyaAdi"].Value.ToString().IndexOf(".");
                    string fileName = dgvDosyaListesi.CurrentRow.Cells["DosyaAdi"].Value.ToString().Substring(0, position);

                    altdizinarama(@"c:\Yayinlar\");
                    break;

                default:

                    dgvDosyaListesi.Rows.Clear();
                    //string[] dosyalar = Directory.GetFiles(@"c:\Yayinlar\Videolar\");
                    altdizinarama(@"c:\Yayinlar\");
                    break;
               
            }


        }
      

        private void altdizinaramamekanfarki(String yol)
        {
            

            string[] dosya = Directory.GetFiles(yol, "*.*");
            for (int i = 0; i < 1; i++)
            {
                dgvDosyaListesi.Rows.Add(dosya);
                string[] dizin;
                dizin = Directory.GetDirectories(yol);
                for (int s = 0; s < dizin.Length; s++)
                {
                    altdizinaramamekanfarki(dizin[s]);
                }
            }
        }
    }
}

