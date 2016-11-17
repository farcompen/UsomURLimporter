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
using System.Web;
using System.Net;


namespace UsomTxtVeriCekme
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            indirme();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           

            script_olustur();
            button4.Visible = true;
        }

        public void indirme()

        {
            try
            {
                string indirme_yolu = "https://www.usom.gov.tr/url-list.txt";
                string pc_yolu = "C:\\";
                string dosya_adi = "usom_list.txt";
                WebClient webClient = new WebClient();

                webClient.DownloadFileAsync(new Uri(indirme_yolu), pc_yolu + dosya_adi);
                MessageBox.Show("Veri alındı ");
            }


            catch (Exception hata)
            {
                throw hata;
            }
        }
        public void script_olustur()

        {
            try
            {
                richTextBox2.Text = " config firewall address \n               edit ";
                string dosya_yolu = "C:\\usom_list.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader SR = new StreamReader(fs);
                string yazi = SR.ReadLine();


                while (yazi != null)
                {
                    richTextBox2.Text = richTextBox2.Text + "''" + yazi + "''" + "\n    " + "                          set type fqdn   \n                              set fqdn "+ "''" + yazi+"''" + " \n               next      \n               edit ";
                    yazi = SR.ReadLine();
                }
                fs.Close();
                SR.Close();
                richTextBox2.Text = richTextBox2.Text + "\n               end \n                 \n ";
            }
            catch (Exception eror)
            {
                throw eror;
            }
            
        }
        public void txt_dosya_getir()
        {

            try
            {
                richTextBox1.Text = " ";
                string dosya_yolu = "C:\\usom_list.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader SR = new StreamReader(fs);
                string yazi = SR.ReadLine();


                while (yazi != null)
                {
                    richTextBox1.Text = richTextBox1.Text +  yazi  + "\n";
                    yazi = SR.ReadLine();
                }
                fs.Close();
                SR.Close();
            }
            catch (Exception eror)
            {
                throw eror;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            txt_dosya_getir();
            button1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kaydet();
           
            MessageBox.Show("Başarılı şekilde kaydedildi  ");

        }

        public void kaydet()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Metin Dosyası|*.txt";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter yazici = new StreamWriter(save.FileName);
                yazici.WriteLine(richTextBox2.Text);
                yazici.Flush();
               
                yazici.Close();
              

            }

        }

    }
}
