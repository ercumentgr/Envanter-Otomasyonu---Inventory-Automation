using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon_v4_user_
{
    //public partial class Form1 : Form
    //{
    //    private Giris girişControl;
    //    private Rapor raporControl;
    //    private Siparis siparisControl;

    //    public Form1()
    //    {
    //        InitializeComponent();
    //        // UserControl'leri oluşturun
    //        girişControl = new Giris();
    //        raporControl = new Rapor();
    //        siparisControl = new Siparis();
    //        girişControl.Dock = DockStyle.Fill;  // Giriş UserControl'ü paneli tamamen dolduracak
    //        raporControl.Dock = DockStyle.Fill; // Sipariş UserControl'ü de paneli tamamen dolduracak
    //        siparisControl.Dock = DockStyle.Fill;
    //        // Panel'e ilk UserControl'ü ekleyin
    //        panel1.Controls.Add(girişControl);
    //        panel1.Dock = DockStyle.Fill;
    //        girişControl.btnRaporClicked += GirişControl_BtnRaporClicked;
    //        // Panel'e Siparis Ekle
    //        panel1.Controls.Add(siparisControl);
    //        panel1.Dock = DockStyle.Fill;
    //        girişControl.btnSiparisClicked += SiparisControl_BtnRaporClicked;


    //    }
    //    private void GirişControl_BtnRaporClicked(object sender, EventArgs e)
    //    {
    //        // Giriş UserControl'ü panelden kaldırın
    //        panel1.Controls.Clear();
    //        // Sipariş UserControl'ü panel üzerine ekleyin
    //        panel1.Controls.Add(raporControl);
    //    }
    //    private void SiparisControl_BtnRaporClicked(object sender, EventArgs e)
    //    {
    //        // Giriş UserControl'ü panelden kaldırın
    //        panel1.Controls.Clear();
    //        // Sipariş UserControl'ü panel üzerine ekleyin
    //        panel1.Controls.Add(siparisControl);
    //    }
    //    private void OpenRapor()
    //    {
    //        Rapor raporControl = new Rapor();
    //        raporControl.BackToGiris += (s, e) => LoadUserControl(new Giris()); // Giriş'e dönüş event'i
    //        LoadUserControl(raporControl);
    //    }
    //    private void LoadUserControl(UserControl newControl)
    //    {
    //        // Paneli temizle
    //        panel1.Controls.Clear();

    //        // Yeni UserControl'ü ekle ve ekran boyutuna göre hizala
    //        newControl.Dock = DockStyle.Fill;
    //        panel1.Controls.Add(newControl);
    //    }

    //    private void Form1_Load(object sender, EventArgs e)
    //    {

    //    }
    //}
    public partial class Form1 : Form
    {
        private Giris girişControl;
        private Rapor raporControl;
        private Siparis siparisControl;
        private GirisAnimasyon animasyonControl;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(46, 44, 47);
            // UserControl'leri oluştur
            girişControl = new Giris();
            raporControl = new Rapor();
            siparisControl = new Siparis();
            animasyonControl = new GirisAnimasyon();

            // Giriş event'lerini bağla
            girişControl.btnRaporClicked += GirişControl_BtnRaporClicked;
            girişControl.btnSiparisClicked += GirişControl_BtnSiparisClicked;

            // Rapor'dan Giriş'e dönüş event'i
            raporControl.BackToGiris += (s, e) => LoadUserControl(girişControl);

            // Sipariş'ten Giriş'e dönüş event'i
            siparisControl.BackToGiris += (s, e) => LoadUserControl(girişControl);

            // Panel'i doldur
            panel1.Dock = DockStyle.Fill;

            // Giriş Animasyon UserControl'ünü ilk olarak yükle
            LoadUserControl(animasyonControl);

            animasyonControl.AnimationCompleted += AnimasyonControl_AnimationCompleted;

        }
        private void AnimasyonControl_AnimationCompleted(object sender, EventArgs e)
        {
            // Animasyon tamamlandığında Giriş UserControl'ünü yükle
            LoadUserControl(girişControl);
        }

        private void GirişControl_BtnRaporClicked(object sender, EventArgs e)
        {
            // Rapor UserControl'ünü yükle
            LoadUserControl(raporControl);
        }

        private void GirişControl_BtnSiparisClicked(object sender, EventArgs e)
        {
            // Sipariş UserControl'ünü yükle
            LoadUserControl(siparisControl);
        }


        private void LoadUserControl(UserControl newControl)
        {
            // Panel'i temizle ve yeni kontrolü yükle
            panel1.Controls.Clear();
            newControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(newControl);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
    

