using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static int checkSuperUser;
        public LoginWindow()
        {
            InitializeComponent();
            //calling method of dataContext to fill the login data
            new DataContext().FillLoginData();
        }

        

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //checking if user has given input username and password
            if (LoginModel.loginDictionary.ContainsKey(txtboxUser.Text) && LoginModel.loginDictionary[txtboxUser.Text].Password.Equals(textboxPass.Password))
            {
                //checking the user's superUser
                checkSuperUser = LoginModel.loginDictionary[txtboxUser.Text].SuperUser;

                //code to view OPtionsWindow
                OptionsWindow optWindow = new OptionsWindow();
                optWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                //closing the current window.
                this.Close();
                //displaying the options window
                optWindow.ShowDialog();
            }
            else
                MessageBox.Show("Username or password is wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
            clearBtn_Click(sender, e);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            //clear the textboxes
            txtboxUser.Text = "";
            textboxPass.Password = "";
        }
    }
}
