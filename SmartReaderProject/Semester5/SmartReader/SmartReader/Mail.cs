using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace SmartReader
{
    public partial class Mail : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public Mail()
        {
            InitializeComponent();
        }
        public Mail(string attachmnt) {
            InitializeComponent();
            Attachment.Text = attachmnt;
            Attachment.Enabled = false;
            btnAttach.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(txtUserName.Text, txtPass.Text);
            client = new SmtpClient(txtSmtp.Text);
            client.Port = Convert.ToInt32(txtPort.Text);
            client.EnableSsl = true;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(txtUserName.Text + txtSmtp.Text.Replace("smtp.", "@"), "Kinza", Encoding.UTF8) };
            msg.To.Add(new MailAddress(txtTo.Text));
            if (!string.IsNullOrEmpty(txtCC.Text))
                msg.To.Add(new MailAddress(txtCC.Text));
            msg.Subject = txtSubject.Text;
            msg.Body = txtMessage.Text;
            msg.Attachments.Add(new Attachment(Attachment.Text));
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
            string userstate = "Sending....";
            client.SendAsync(msg, userstate);
        }
        private static void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Mial sent Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                string path = opd.FileName.ToString();
                Attachment.Text = path;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void DarkMode()
        {
            this.BackColor = Color.DarkSlateGray;
            this.panel1.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;
            this.label4.ForeColor = Color.White;
            this.label5.ForeColor = Color.White;
            this.label6.ForeColor = Color.White;
            this.label7.ForeColor = Color.White;
            this.label8.ForeColor = Color.White;
            this.label9.ForeColor = Color.White;
        }
        public void LightMode()
        {

            this.BackColor = Color.White;
            this.panel1.BackColor = Color.LightSteelBlue;
            this.label1.ForeColor = Color.Black;
            this.label2.ForeColor = Color.Black;
            this.label3.ForeColor = Color.Black;
            this.label4.ForeColor = Color.Black;
            this.label5.ForeColor = Color.Black;
            this.label6.ForeColor = Color.Black;
            this.label7.ForeColor = Color.Black;
            this.label8.ForeColor = Color.Black;
            this.label9.ForeColor = Color.Black;
        }
        private void Mail_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
