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
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }
        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
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
        private void QuitMenu_GotFocus(object sender, RoutedEventArgs e)
        {
            //to change the foreground color when get focus
            QuitMenu.Foreground = Brushes.Black;
        }

        private void QuitMenu_LostFocus(object sender, RoutedEventArgs e)
        {

            //to change the foreground color when lost focus
            QuitMenu.Foreground = Brushes.White;
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            //close the current window
            this.Close();
        }
        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            //CustomersWindow cw = new CustomersWindow();
            //cw.Show();
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
            //FlightsWindow flw = new FlightsWindow();
            //flw.Show();
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            //AirlinesWindow airw = new AirlinesWindow();
            //airw.Show();
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            //PassengersWindow pw = new PassengersWindow();
            //pw.Show();
        }

        //method to reuse and show error message 
        private void ErrorMessage()
        {

            MessageBox.Show("Operations are not allowed", "Pay Attention", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
