using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Sözcük_Karıştırıcı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string acikdosya="";
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            richTextBox2.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void metinKutusu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog yazı = new FontDialog();
            yazı.MaxSize = 15;
            yazı.MinSize = 6;
            if (yazı.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = yazı.Font;
            }

        }

        private void metinKutusu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog yazı = new FontDialog();
            yazı.MaxSize = 15;
            yazı.MinSize = 6;
            if (yazı.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Font = yazı.Font;
            }

        }

        private void tümleşikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog yazı = new FontDialog();
            yazı.MaxSize = 15;
            yazı.MinSize = 6;
            if (yazı.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = yazı.Font;
                richTextBox2.Font = yazı.Font;
            }

        }

        private void içeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Title = "İçe Aktar";
            ac.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(ac.FileName);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
                acikdosya = ac.FileName;
                this.Text = ac.FileName + " - Sözcük Karıştırıcı";
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                StreamReader oku = new StreamReader(acikdosya, Encoding.Default);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
            }

        }

        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                StreamReader oku = new StreamReader(acikdosya, Encoding.Unicode);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
            }
        }

        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                StreamReader oku = new StreamReader(acikdosya, Encoding.UTF7);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
            }
        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                StreamReader oku = new StreamReader(acikdosya, Encoding.UTF8);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
            }
        }

        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                StreamReader oku = new StreamReader(acikdosya, Encoding.UTF32);
                string girdi = oku.ReadToEnd();
                richTextBox1.Text = girdi;
                oku.Close();
            }
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikdosya != "")
            {
                this.Text = "Sözcük Karıştırıcı";
                acikdosya = "";
            }
        }

        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void metin1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                yaz.Write(richTextBox1.Text);
                yaz.Close();
                MessageBox.Show("Dosya oluşturuldu.", "Sözük Karıştırıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metin2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                yaz.Write(richTextBox2.Text);
                yaz.Close();
                MessageBox.Show("Dosya oluşturuldu.", "Sözük Karıştırıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tümleşikToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                yaz.Write("ORJİNAL METİN" + Environment.NewLine + Environment.NewLine + richTextBox1.Text + Environment.NewLine + Environment.NewLine+"İŞLENMİŞ METİN"+ Environment.NewLine + Environment.NewLine+richTextBox2.Text);
                yaz.Close();
                MessageBox.Show("Dosya oluşturuldu.", "Sözük Karıştırıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) richTextBox2.ReadOnly = false;
            else richTextBox2.ReadOnly = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText ( richTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                yaz.Write(richTextBox1.Text);
                yaz.Close();
                MessageBox.Show("Dosya oluşturuldu.", "Sözük Karıştırıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Dışa Aktar";
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                File.CreateText(kaydet.FileName).Close();
                StreamWriter yaz = new StreamWriter(kaydet.FileName);
                yaz.Write(richTextBox2.Text);
                yaz.Close();
                MessageBox.Show("Dosya oluşturuldu.", "Sözük Karıştırıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            char[] bosluk = { ' ' };
            string[] kelimeler = richTextBox1.Text.Split(bosluk);
            foreach (string secilen in kelimeler)
            {
                try
                {
                    string basharf = secilen.Substring(0, 1);
                    string sonharf = secilen.Remove(0, secilen.Length - 1);
                    string yenikelime = secilen.Remove(0, 1);
                    yenikelime = yenikelime.Substring(0, yenikelime.Length - 1);

                    string karisik_kelime = "";

                    Random random = new Random();
                    int uzunluk = yenikelime.Length;
                    int index = 0;

                    for (int i = uzunluk; i > 0; i--)
                    {
                        index = random.Next(0, uzunluk);
                        karisik_kelime += yenikelime[index].ToString();
                        yenikelime = yenikelime.Remove(index, 1);
                        uzunluk = yenikelime.Length;
                    }
                    richTextBox2.Text += basharf + karisik_kelime + sonharf + " ";
                }
                catch { }
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about info = new about();
            info.ShowDialog();
        }
    }
}
