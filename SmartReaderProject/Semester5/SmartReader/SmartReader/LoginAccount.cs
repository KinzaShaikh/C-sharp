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
    public partial class LoginAccount : Form
    {
        string user, pass;
        string fntName, fntColor, fntSize, fontStyle, mode, voiceType;
        string defaultSize = "8.25";
        string defaultMode= "Light", defaultFont="Microsoft Sans Serif", defaultFontstyle="Regular",defaultFontColor="Black", defaultVoiceType="Male";
        public LoginAccount()
        {
            InitializeComponent();
        }
        public LoginAccount(string fname, string fcolor, string fsize, string fstyle, string mod, string voice)
        {
            InitializeComponent();
            
            fntName = fname;
            fntColor = fcolor;
            fntSize = fsize;
            fontStyle = fstyle;
            mode = mod;
            voiceType = voice;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Enter username and pass");

            }
            else
            {
                user = textBoxUsername.Text;
                pass = textBoxPass.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users where Username=' " + user + " ' AND Password=' " + pass + " '";
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    if (reader.Read())
                    {
                        connection.Close();
                        reader.Close();
                        StateInfo(user, pass);
                    }
                }
                else
                {
                    connection.Close();
                    reader.Close();
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Enter username and pass");

            }
            else
            {
                user = textBoxUsername.Text;
                pass = textBoxPass.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlConnection selectConn = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = selectConn;
                selectCommand.CommandText = "SELECT Username FROM Users where Username=' " + user + " ' AND Password=' " + pass + " '";
                selectConn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string check = reader.GetString(0).Trim();
                        MessageBox.Show(check + " " + user);
                    if (check==user)
                    {      
                            MessageBox.Show("User Already exists");
                    }
                    }
                }
                else
                {
                    reader.Close();
                    selectConn.Close();
             //       connection.Open();
                    command.CommandText = "Insert Users(Username,Password,Mode,FontStyle,Font,FontColor,VoiceType,FontSize) " +
                   "values (' " + user + " ',' " + pass + " ',' " + defaultMode + " ',' " + defaultFontstyle + " ',' " + defaultFont + " ',' " + defaultFontColor + " ',' " + defaultVoiceType + " ',' " + defaultSize + " ')";
                    connection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                         StateInfo(user, pass);
                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Username and password");

                    }
                }
                reader.Close();
                selectConn.Close();
               connection.Close();
            }

        

        }
        public void StateInfo(string usern,string passs) {

            string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Users where Username=' " + user + " ' AND Password=' " + pass + " '";
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {

                if (reader.Read())
                {
                    string mode = reader.GetString(3).Trim(), 
                        Fstyle= reader.GetString(4).Trim(),
                        fontt= reader.GetString(5).Trim(), 
                        fColor= reader.GetString(6).Trim()
                        , voiceType= reader.GetString(7).Trim(),
                        fSize= reader.GetString(8).Trim();
                    //MessageBox.Show(mode+ Fstyle+ fontt+ fColor+ voiceType+ fSize);
                    Form1 obj = new Form1(mode, Fstyle, fontt, fColor, voiceType, fSize,user,pass);
                    obj.ShowDialog();
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
        }
        private void button2Cancel_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void LoginAccount_Load(object sender, EventArgs e)
        {

        }
        public void DarkMode()
        {
            this.BackColor = Color.DarkSlateGray;
            this.panel1.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.labelUser.ForeColor = Color.White;
            this.labelPass.ForeColor = Color.White;

        }
        public void LightMode()
        {

            this.BackColor = Color.White;
            this.panel1.BackColor = Color.LightSteelBlue;
            this.label1.ForeColor = Color.Black;
            this.labelUser.ForeColor = Color.Black;
            this.labelPass.ForeColor = Color.Black;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginAndAccount ob = new LoginAndAccount();
            ob.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Enter username and pass");

            }
            else
            {
                user = textBoxUsername.Text;
                pass = textBoxPass.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["EditorConString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users where Username=' " + user + " ' AND Password=' " + pass + " '";
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {

                    if (reader.Read())
                    {
                        connection.Close();
                        reader.Close();
                        MessageBox.Show("Done");   
                    }
                }
                else {
                    connection.Close();
                    reader.Close();
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
        }
        }
}
