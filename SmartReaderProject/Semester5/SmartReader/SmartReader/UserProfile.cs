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
    public partial class UserProfile : Form
    {
        string mode,fStyle,fontt,fColor,voiceT,fsize;
        string username, pass;
        public UserProfile()
        {
            InitializeComponent();
        }
        public UserProfile(string mode, string fStyle, string fontt, string fColor, string voiceT, string fsize,string user,string pass)
        {
            InitializeComponent();
            this.mode = mode;
            this.fStyle = fStyle;
            this.fontt = fontt;
            this.fColor = fColor;
            this.voiceT = voiceT;
            this.fsize = fsize;
            this.username = user;
            this.pass = pass;
        }

        private void buttonViewState_Click(object sender, EventArgs e)
        {



            panel3.Visible = true;
            

            string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Users where Username=' " + username + " ' AND Password=' " + pass + " '";
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {

                if (reader.Read())
                {
                    string mode = reader.GetString(3).Trim(),
                        Fstyle = reader.GetString(4).Trim(),
                        fontt = reader.GetString(5).Trim(),
                        fColor = reader.GetString(6).Trim()
                        , voiceType = reader.GetString(7).Trim(),
                        fSize = reader.GetString(8).Trim();
                    labelfont.Text = "Font :              " + fontt;
                    labelfontColor.Text = "Font Color:          " + fColor;
                    labelFontSize.Text = "Font Size:          " + fSize;
                    labelFontStyle.Text = "Font Style:         " + Fstyle;
                    labelMode.Text = "Mode:               " + mode + " Mode";
                    labelvoiceType.Text = "Voice Type:          " + voiceType;
                    connection.Close();
                    reader.Close();
                }

            }
            else
            {
                MessageBox.Show("Error");
                connection.Close();
                reader.Close();
                MessageBox.Show("Incorrect Username or Password");
            }
            connection.Close();
            reader.Close();
        }

        private void buttonUpdateState_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            command.CommandText =

            " UPDATE Users set Mode = ' " + this.mode + " ', FontStyle =' " + this.fStyle + " ', Font =' " + this.fontt + " ', FontColor =' " + this.fColor + " ', VoiceType =' " + this.voiceT + " ', FontSize = ' " + this.fsize + " ' where Username = ' " + username + " ';";
            int response = command.ExecuteNonQuery();
            if (response == 1)
            {
                MessageBox.Show("Your State is SuccessFully Updated!");
            }
            else {
                MessageBox.Show("state not updated!");

            }
            connection.Close();
        }

        private void buttonDeleteProf_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            connection.Open();
            command.CommandText = "Delete From Users Where Username=' " + username + " '";
            int response = command.ExecuteNonQuery();
            if (response == 1)
            {
                this.buttonCurrState.Enabled = false;
                this.buttonUpdateState.Enabled = false;
                this.buttonViewState.Enabled = false;
                MessageBox.Show("Your Account is Deleted!");
            }
            else
            {
                MessageBox.Show("Acount not Deleted!");

            }
        }

        private void buttonCurrState_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            labelfont.Text = "Font :              " + fontt;
            labelfontColor.Text = "Font Color:          " + fColor;
            labelFontSize.Text = "Font Size:          " + fsize;
            labelFontStyle.Text = "Font Style:         " + fStyle;
            labelMode.Text = "Mode:               " + mode + " Mode";
            labelvoiceType.Text = "Voice Type:          " + voiceT;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginAccount log = new LoginAccount();
            this.Hide();
            log.ShowDialog();
        }

        private void guna2ToggleSwitchOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (this.guna2ToggleSwitchOptions.Checked)
            {
                panel2.Visible = true;
            }
            else {
                panel2.Visible = false;
            }

        }
        public void DarkMode()
        {
            this.BackColor = Color.Black;
            this.panel1.BackColor = Color.DarkSlateGray;
            this.panel2.BackColor = Color.DarkSlateGray;
            this.panel3.BackColor = Color.DarkSlateGray;
            this.label1.ForeColor = Color.White;
            this.labelfont.ForeColor = Color.White;
            this.labelfontColor.ForeColor = Color.White;
            this.labelFontSize.ForeColor = Color.White;
            this.labelFontStyle.ForeColor = Color.White;
            this.labelMode.ForeColor = Color.White;
            this.labelOptions.ForeColor = Color.White;
            this.labelUser.ForeColor = Color.White;
            this.labelvoiceType.ForeColor = Color.White;
        }
        public void LightMode()
        {
            this.BackColor = Color.White;
            this.panel1.BackColor = Color.LightSteelBlue;
            this.panel2.BackColor = Color.LightSteelBlue;
            this.panel3.BackColor = Color.LightSteelBlue;
            this.label1.ForeColor = Color.Black;
            this.labelfont.ForeColor = Color.Black;
            this.labelfontColor.ForeColor = Color.Black;
            this.labelFontSize.ForeColor = Color.Black;
            this.labelFontStyle.ForeColor = Color.Black;
            this.labelMode.ForeColor = Color.Black;
            this.labelOptions.ForeColor = Color.Black;
            this.labelUser.ForeColor = Color.Black;
            this.labelvoiceType.ForeColor = Color.Black;
        }
        private void UserProfile_Load(object sender, EventArgs e)
        {
            this.labelUser.Text = username;
            panel2.Visible = false;
            panel3.Visible = false;
        }
    }
}
