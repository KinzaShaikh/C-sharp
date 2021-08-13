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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void ViewAirlinesBtn_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow airWin = new AirlinesWindow();
            airWin.ShowDialog();
        }

        private void ViewPassengersBtn_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow win = new PassengerWindow();
            win.ShowDialog();
        }

        private void ViewFlightsBtn_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow fw = new FlightWindow();
            fw.ShowDialog();
        }

        private void ViewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerwin = new CustomerWindow();
            customerwin.ShowDialog();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            //when closing with show message that user has logged out
            MessageBox.Show("You have successfully logged out!");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //when user close window ask him he/she wants to close or not
            MessageBoxResult result = MessageBox.Show("sure? do you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                //open login window
                LoginWindow logn = new LoginWindow();
                logn.Show();
            }
            else
                e.Cancel = true;
        }
        private void MenuHelp_Click(object sender, RoutedEventArgs e)
        {
            //open about window
            AboutWindow aboutWin = new AboutWindow();
            aboutWin.Show();
        }
        private void QuitMenu_GotFocus(object sender, RoutedEventArgs e)
        {
            //change the foregroundcolor when item get focus
            QuitMenu.Foreground = Brushes.Black;
        }

        private void QuitMenu_LostFocus(object sender, RoutedEventArgs e)
        {
            //change the foregroundcolor when item lost focus
            QuitMenu.Foreground = Brushes.White;
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            //close current window
            this.Close();
        }
        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            //to view the customers using button
            ViewCustomerBtn_Click(sender, e);
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
            //to view flights using button
            ViewFlightsBtn_Click(sender, e);
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            //to view airlines using button
            ViewAirlinesBtn_Click(sender, e);
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            //to view passengers using button
            ViewPassengersBtn_Click(sender, e);
        }

        private void InsertMenu_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage();
        }

        private void UpdateMenu_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage();
        }

        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage();
        }

        //method to reuse and show error message 
        private void ErrorMessage()
        {
            
            MessageBox.Show("Operations are not allowed", "Pay Attention", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
