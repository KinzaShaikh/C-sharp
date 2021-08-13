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
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Text.RegularExpressions;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SmartReader
{
    public partial class ChooseMail : Form
    {
        Mail newmail;
        RichTextBox richTBox;
        SpeechSynthesizer spk; Mail obj = new Mail();
        int count = 1;
        public ChooseMail()
        {
            InitializeComponent();
        }
        public ChooseMail(RichTextBox richBox, SpeechSynthesizer sp) {
            InitializeComponent();
            richTBox = richBox;
            spk = sp;

        }

        private void btnTextTopdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTBox.Text != "")
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                    {

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {

                            Document doc = new Document(PageSize.A4.Rotate());
                            try
                            {
                                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                doc.Open();
                                doc.Add(new Paragraph(richTBox.Text));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                doc.Close();
                            }
                            newmail = new Mail(sfd.FileName);
                            if (count == 1)
                            {
                                newmail.LightMode();
                            }else if (count == 2)
                            {
                                newmail.DarkMode();
                            }

                            newmail.StartPosition = FormStartPosition.CenterScreen;
                            newmail.ShowDialog();
                        }

                    }
                }
                else
                {
                    spk.SpeakAsync("please Write somr thing in the text box");

                    //MessageBox.Show("Write Something!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {

            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog();

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void DarkMode() {
            count = 2; 
            this.BackColor = Color.DarkSlateGray;
            this.panel1.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.label2.ForeColor=Color.White;
            this.label3.ForeColor = Color.White;
            //newmail.DarkMode();
            obj.DarkMode();
            
        }
        public void LightMode() {
            count = 1;
            this.BackColor = Color.White;
            this.panel1.BackColor = Color.LightSteelBlue;
            this.label1.ForeColor = Color.Black;
            this.label2.ForeColor = Color.Black;
            this.label3.ForeColor = Color.Black;
            //newmail.LightMode();
            obj.LightMode();
        }
        private void ChooseMail_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
