using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace yazproje3
{
    public partial class Form2 : Form
    {
          
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            textBox1.Text = "Lütfen toplam süreyi giriniz(Dakika)...";
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            textBox2.Text = "Müşteri gelme aralığını giriniz(Saniye)...";
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Enter += TextBox2_Enter;
            textBox2.Leave += TextBox2_Leave;
            textBox3.Text = "Verilen müşteri gelme aralığında kaç müşteri gelmelidir giriniz...";
            textBox3.ForeColor = SystemColors.GrayText;
            textBox3.Enter += TextBox3_Enter;
            textBox3.Leave += TextBox3_Leave;
            textBox4.Text = "Lütfen süreyi belirleyiniz(Dakika)...";
            textBox4.ForeColor = SystemColors.GrayText;
            textBox4.Enter += TextBox4_Enter;
            textBox4.Leave += TextBox4_Leave;
           
           

        }
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Lütfen toplam süreyi giriniz(Dakika)...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Lütfen toplam süreyi giriniz(Dakika)...";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }
        private void TextBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Lütfen süreyi belirleyiniz(Dakika)...")
            {
                textBox4.Text = "";
                textBox4.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Lütfen süreyi belirleyiniz(Dakika)...";
                textBox4.ForeColor = SystemColors.GrayText;
            }
        }
        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Müşteri gelme aralığını giriniz(Saniye)...")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Müşteri gelme aralığını giriniz(Saniye)...";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }
        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Verilen müşteri gelme aralığında kaç müşteri gelmelidir giriniz...")
            {
                textBox3.Text = "";
                textBox3.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Verilen müşteri gelme aralığında kaç müşteri gelmelidir giriniz...";
                textBox3.ForeColor = SystemColors.GrayText;
            }
        }
        private void sabitbutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void rastgelebutton_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void sabitbaslatbuton_Click(object sender, EventArgs e)
        {
           
            if (int.TryParse(textBox1.Text, out int toplamSure) &&
                int.TryParse(textBox2.Text, out int saniyedeMusteriGelme) &&
                int.TryParse(textBox3.Text, out int verilenMusteriGelme))
            {
                // Toplam süreyi dakikadan saniyeye çevirme
                int toplamSureSaniye = toplamSure * 60;

                // Saniyede kaç müşteri geldiği
                double musteriGelmeOrani = (double)verilenMusteriGelme / saniyedeMusteriGelme;

                // Toplamda kaç müşterinin geleceğini hesaplama
                double toplamMusteri = musteriGelmeOrani * toplamSureSaniye;

                // Müşterilerin masalara oturup oturmadığını kontrol etme
                int oturmayanMusteriSayisi = (int)(toplamSureSaniye / 20 * musteriGelmeOrani);
                int oturanMusteriSayisi = (int)toplamMusteri - oturmayanMusteriSayisi;

                // Masa sayısını ve çalışan sayılarını belirleme (her 4 müşteri için bir masa)
                int masaSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi / 4);
                int garsonSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi * 2 / 60.0); // Her 2 dakikada bir garson sipariş alsın
                int asciSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi * 3 / 60.0);   // Her 3 dakikada bir aşçı yemek hazırlasın

                // Müşteri başına kazancı hesaplama
                double musteriBasinaKazanc = oturanMusteriSayisi;

                // Toplam maliyeti hesaplama (her biri için 1 maliyet)
                int toplamMaliyet = masaSayisi + garsonSayisi + asciSayisi;

                // Kazancı hesaplama
                double kazanc = musteriBasinaKazanc - toplamMaliyet;

                // En iyi senaryoyu belirleyerek panel1'e yazdırma
                panel1.Visible = true;
                label1.Text = $"Masa Sayısı: {masaSayisi}\nGarson Sayısı: {garsonSayisi}\nAşçı Sayısı: {asciSayisi}\nKalkacak Müşteri Sayısı: {oturmayanMusteriSayisi}\nKazanç: {kazanc}\nToplam Müşteri: {toplamMusteri}";
            }
            else
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler giriniz.");
            }
        }


        private void rastgelebaslatbuton_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            if (int.TryParse(textBox4.Text, out int simuleSure)) // Kullanıcıdan girilen toplam süre
            {
                Random random = new Random();
                int gecenSure = 0;
                int oturanMusteriSayisi = 0;
                string rastgeleMusteri = "";
                string rastgeleSaniye = "";

                while (gecenSure < simuleSure * 60) // Belirlenen süre içinde döngü
                {
                    int gelenMusteri = random.Next(1,10 ); // Rastgele 1 ile 15 arasında müşteri sayısı
                    oturanMusteriSayisi += gelenMusteri; // Oturan müşteri sayısını güncelleme

                    int rastgeleBeklemeSure = random.Next(5, 20); // Rastgele 1 ile 5 saniye arasında bekleme süresi
                    gecenSure += rastgeleBeklemeSure;// Zamanı güncelleme

                    rastgeleMusteri += $"{gelenMusteri} müşteri, ";
                    rastgeleSaniye += $"{rastgeleBeklemeSure} sn, ";

                    // Label2'ye rastgele müşteri sayıları ve saniyeleri yazdırma
                    label2.Text += $"Gelen Müşteri: {gelenMusteri}, Kaç saniyede geldi: {rastgeleBeklemeSure} sn\n";
                }

                // Masa sayısını ve çalışan sayılarını belirleme (her 4 müşteri için bir masa)
                int masaSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi / 4);
                int garsonSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi * 2 / 60.0); // Her 2 dakikada bir garson sipariş alsın
                int asciSayisi = (int)Math.Ceiling((double)oturanMusteriSayisi * 3 / 60.0);   // Her 3 dakikada bir aşçı yemek hazırlasın

                // Müşteri başına kazancı hesaplama
                double musteriBasinaKazanc = oturanMusteriSayisi;

                // Toplam maliyeti hesaplama (her biri için 1 maliyet)
                int toplamMaliyet = masaSayisi + garsonSayisi + asciSayisi;

                // Kazancı hesaplama
                double kazanc = musteriBasinaKazanc - toplamMaliyet;

                // Kalkacak müşteri sayısını belirleme
                int kalkacakMusteriSayisi = oturanMusteriSayisi - (oturanMusteriSayisi - simuleSure * 60 / 20);

                // Panel1'e ve Label3'e yazdırma
                panel2.Visible = true;
                label3.Text = $"Masa Sayısı: {masaSayisi}\nGarson Sayısı: {garsonSayisi}\nAşçı Sayısı: {asciSayisi}\nKalkacak Müşteri Sayısı: {kalkacakMusteriSayisi}\nKazanç: {kazanc}\nToplam Müşteri: {oturanMusteriSayisi}";
            }
            else
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler giriniz.");
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

