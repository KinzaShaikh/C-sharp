using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace SmartReader
{
    public partial class Profile : Form
    {
        string user, pass; 
        string fntName, fntColor, fntSize, fontStyle, mode, voiceType;

        public Profile()
        {
            InitializeComponent();
        }
        public Profile(string fname, string fcolor, string fsize, string fstyle, string mod, string voice)
        {
            InitializeComponent();
            fntName = fname;
            fntColor = fcolor;
            fntSize = fsize;
            fontStyle = fstyle;
            mode = mod;
            voiceType = voice;
        }
        
        public void DarkMode()
        {

            this.BackColor = Color.DarkSlateGray;
            this.panel1Profile.BackColor = Color.Black;
            this.labelCreateAccount.ForeColor = Color.White;
            this.labelUserName.ForeColor = Color.White;
            this.labelPassword.ForeColor = Color.White;

        }
        public void LightMode()
        {

            this.BackColor = Color.White;
            this.panel1Profile.BackColor = Color.LightSteelBlue;
            this.labelCreateAccount.ForeColor = Color.Black;
            this.labelUserName.ForeColor = Color.Black;
            this.labelPassword.ForeColor = Color.Black;

        }
        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

            this.Hide();
            LoginAndAccount ob = new LoginAndAccount();
            ob.ShowDialog();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Enter username and pass");

            }
            else {
                user = textBoxUser.Text;
                pass = textBoxPass.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "Insert Users(Username,Password) values (' " +user+ " ',' " +pass+ " ')";
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
