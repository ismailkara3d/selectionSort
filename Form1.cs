using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace selectionSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> sayilar = new List<int>();
        List<Button> butonlar = new List<Button>();
        List<Button> siraliButon = new List<Button>();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (int.TryParse(txtSayi.Text, out a))
            {
                sayilar.Add(int.Parse(txtSayi.Text));
                DiziOlustur(int.Parse(txtSayi.Text));
            }
            txtSayi.Clear();
        }

        void DiziOlustur(int sayi)
        {

            Button btn = new Button();
            btn.Name = sayi.ToString();
            btn.SetBounds(butonlar.Count > 0 ? butonlar.Last().Left + 75 : 50, 200, 50, 50);
            btn.Text = sayi.ToString();
            btn.Show();
            butonlar.Add(btn);
            this.Controls.Add(btn);
        }

        void ButonOlustur(List<int> dizi, int top)
        {

            for (int i = 0; i < siraliButon.Count; i++)
            {
                this.Controls.Remove(siraliButon[0]);
            }
            siraliButon.Clear();
            for (int i = 0; i < dizi.Count; i++)
            {
                Button btn = new Button();
                btn.Name = dizi[i].ToString();
                btn.SetBounds(siraliButon.Count > 0 ? siraliButon.Last().Left + 75 : 50, top, 50, 50);
                btn.Text = dizi[i].ToString();
                btn.Show();
                siraliButon.Add(btn);
                siraliButon[i].BackColor = Color.FromArgb(i * (128 / dizi.Count) + 100, 20, 20);
                this.Controls.Add(btn);

            }


        }
  
        void SecmeSiralamasi(List<int> liste)
        {

            int temp = 0;
            for (int i = 0; i < liste.Count; i++)
            {

                for (int j = i + 1; j < liste.Count; j++)
                {
                   
                    if (liste[j] < liste[i])
                    {                       
                        temp = liste[i];
                        liste[i] = liste[j];
                        liste[j] = temp;                        
                    }
               
                   
                }
            }
            ButonOlustur(liste, 300);
        }

        private void btnSirala_Click(object sender, EventArgs e)
        {
            SecmeSiralamasi(sayilar);           
        }
    }
}
