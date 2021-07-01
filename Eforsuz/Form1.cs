using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFORSUZ
{
    public partial class Form1 : Form
    {
        string[] lane1 = { "░░", "███░", "██░░", "███░", "███░", "███░░", "███░", "███░", "███░", "░█░░", "█░█░", "███░", "░█░░", "░░█░", "█░░█░", "█░░░", "█████░", "█░░░█░", "███░", "█░█░", "███░", "░███░░░", "███░░", "███░", "███░", "███░", "█░░█░", "█░░█░", "█░░░█░", "█░░░█░", "█░░░█░", "█░░░█░", "███░" };
        string[] lane2 = { "░░", "█░█░", "█░█░", "█░░░", "█░░░", "█░░█░", "█░░░", "█░░░", "█░░░", "███░", "█░█░", "░█░░", "███░", "░░█░", "█░█░░", "█░░░", "█░█░█░", "██░░█░", "█░█░", "███░", "█░█░", "█░░░█░░", "█░░█░", "█░░░", "█░░░", "░█░░", "█░░█░", "░░░░░", "█░░░█░", "█░░░█░", "░█░█░░", "░█░█░░", "░░█░" };
        string[] lane3 = { "░░", "███░", "██░░", "█░░░", "█░░░", "█░░█░", "███░", "██░░", "█░█░", "█░░░", "███░", "░█░░", "░█░░", "░░█░", "██░░░", "█░░░", "█░█░█░", "█░█░█░", "█░█░", "█░█░", "███░", "█░█░█░░", "███░░", "███░", "███░", "░█░░", "█░░█░", "█░░█░", "░█░█░░", "█░█░█░", "░░█░░░", "░░█░░░", "░█░░" };
        string[] lane4 = { "░░", "█░█░", "█░█░", "█░░░", "███░", "█░░█░", "█░░░", "█░░░", "█░█░", "█░█░", "█░█░", "░█░░", "░█░░", "█░█░", "█░█░░", "█░░░", "█░░░█░", "█░░██░", "█░█░", "█░█░", "█░░░", "█░░██░░", "█░░█░", "░░█░", "░░█░", "░█░░", "█░░█░", "█░░█░", "░███░░", "█░█░█░", "░█░█░░", "░░█░░░", "█░░░" };
        string[] lane5 = { "░░", "█░█░", "██░░", "███░", "░█░░", "███░░", "███░", "█░░░", "███░", "███░", "█░█░", "███░", "███░", "███░", "█░░█░", "███░", "█░░░█░", "█░░░█░", "███░", "███░", "█░░░", "░███░█░", "█░░█░", "███░", "███░", "░█░░", "████░", "████░", "░░█░░░", "█████░", "█░░░█░", "░░█░░░", "███░" };

        char[] harfler = { ' ', 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'q', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'w', 'x', 'y', 'z' };
        int length = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Process();
            }
        }

        public void Process()
        {
            textBox2.Text = GetLane(textBox1.Text.ToLower());

            char[] karakter = textBox2.Text.ToCharArray();
            length = karakter.Length;

            Clipboard.Clear();
            Clipboard.SetText(textBox2.Text);

            if (karakter.Length > 200)
                label1.Text = "Mesajınız, 200 karakter sınırını aşmıştır. League of Legends ve Valorant gibi oyunlarda, mesajınızın tamamını göremeyebilirsiniz.";

            else if (karakter.Length >= 130)
                label1.Text = "Mesajınız, League of Legends özel mesaj kısmında düzgün gözükmeyebilir.";

            else
                label1.Text = null;
        }

        public string GetLane(string label)
        {
            string lastLabel = null;
            char[] dizi = label.ToCharArray();

            for(int lane = 1; lane <= 5; lane++)
            {
                for(int i = 0; i < dizi.Length; i++)
                {
                    lastLabel += GetCharacter(dizi[i], lane);
                }
                lastLabel += "\r\n";
            }

            return lastLabel;
        }

        public string GetCharacter(char harf, int lane)
        {
            int harfIndis = FindHarf(harf);

            if (lane == 1) return lane1[harfIndis];
            else if (lane == 2) return lane2[harfIndis];
            else if (lane == 3) return lane3[harfIndis];
            else if (lane == 4) return lane4[harfIndis];
            else if (lane == 5) return lane5[harfIndis];
            else return lane1[0];
        }

        public int FindHarf(char harf)
        {
            for(int i = 0; i < harfler.Length; i++)
            {
                if (harfler[i] == harf) return i;
            }
            return 0;
        }
    }
}
