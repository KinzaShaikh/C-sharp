using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartReader
{
  
    public partial class LoginAndAccount : Form
    {
        LoginAccount LogAcc = new LoginAccount();
        Profile prof = new Profile();
        public LoginAndAccount()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            this.Hide();
            prof.ShowDialog();
        }
        
        private void LoginAndAccount_Load(object sender, EventArgs e)
        {

            
        }
        public void DarkMode()
        {

            this.BackColor = Color.DarkSlateGray;
            this.panel1.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;
            LogAcc.DarkMode();
            prof.DarkMode();
        }
        public void LightMode()
        {
            this.BackColor = Color.White;
            this.panel1.BackColor = Color.LightSteelBlue;
            this.label1.ForeColor = Color.Black;
            this.label2.ForeColor = Color.Black;
            this.label3.ForeColor = Color.Black;
            LogAcc.LightMode();
            prof.LightMode();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogAcc.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
