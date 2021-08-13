using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AirlinesWindow.xaml
    /// </summary>
    public partial class AirlinesWindow : Window
    {
        public List<AirlinesModel> airlinesList = new List<AirlinesModel>();
        private string airplaneRadio = "";
        private string mealRadio = "";
        public AirlinesWindow()
        {
            InitializeComponent();
        }
        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow custonerWin = new CustomerWindow();
            custonerWin.Show();
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow flw = new FlightWindow();
            flw.Show();
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow pw = new PassengerWindow();
            pw.Show();
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWin = new AboutWindow();
            aboutWin.Show();
        }
        private void Menu_GotFocus(object sender, RoutedEventArgs e)
        {
            //change foreColor when get focus
            QuitMenu.Foreground = Brushes.Red;
        }
        private void Menu_LostFocus(object sender, RoutedEventArgs e)
        {
            //change foreColor when button lost focus
            QuitMenu.Foreground = Brushes.Black;
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            //close the current window
            this.Close();
        }

        private void InsertMenu_Click(object sender, RoutedEventArgs e)
        {
            insertBtn_Click(sender, e);
        }

        private void UpdateMenu_Click(object sender, RoutedEventArgs e)
        {
            updateBtn_Click(sender, e);
        }

        private void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            deleteBtn_Click(sender, e);
        }
        
        private void listBoxAirlines_Loaded(object sender, RoutedEventArgs e)
        {
            //fill data into airlines list
            airlinesList = new DataContext().FillAirlinesData();
            var data = from air in airlinesList
                       orderby air.ID
                       select air;
            listBoxAirlines.DataContext = data;
        }

        private void listBoxAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AirlinesModel selectedAir = (AirlinesModel)listBoxAirlines.SelectedItem;
                //if user has selected airline from listbox
                if (selectedAir != null)
                {
                    var data = (from air in airlinesList
                                    where air.ID == selectedAir.ID && air.Name == selectedAir.Name
                                    select air).First();
                    //show data into the textboxes
                    textBoxAirID.Text = data.ID.ToString();
                    textBoxAirName.Text = data.Name;
                    textBoxSeats.Text = data.SeatsAvailable.ToString();
                    airplaneRadio = data.Airplane;
                    mealRadio = data.MealAvailable;
                    //switch for airplanes radio buttons
                    switch (airplaneRadio)
                    {
                        case "Boeing 777":
                            rbBoeing.IsChecked = true;
                            break;
                        case "Airbus 320":
                            rbAirbus.IsChecked = true;
                            break;
                        case "Bombardier Q":
                            rbBmbrdQ.IsChecked = true;
                            break;
                        default:
                            rbBoeing.IsChecked = false;
                            rbAirbus.IsChecked = false;
                            rbBmbrdQ.IsChecked = false;
                            break;
                    }
                    // switch for meals
                    switch (mealRadio)
                    {
                        case "Salad":
                            rbVeg.IsChecked = true;
                            break;
                        case "Chicken":
                            rbChicken.IsChecked = true;
                            break;
                        case "Sushi":
                            rbSushi.IsChecked = true;
                            break;
                        default:
                            rbVeg.IsChecked = false;
                            rbSushi.IsChecked = false;
                            rbChicken.IsChecked = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something wrong in airlines window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {

            //checking if user is super user or not
            if (LoginWindow.checkSuperUser == 0)
            {
                //if customer is not super user he can not insert data
                //show error message
                MessageBox.Show("You are not allowed to insert airline, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            try
            {
                //check if user has enter all fields
                if (textBoxAirID.Text != "" && textBoxAirName.Text != "" && textBoxSeats.Text != "" && mealRadio != "" && airplaneRadio != "")
                {
                    //selecting data from list
                    int id = int.Parse(textBoxAirID.Text);
                    var data = (from air in airlinesList
                                where air.ID == id
                                select air);
                    //if we have any duplicate data
                    if (data.Count() > 0)
                    {
                        var airId = (from air in airlinesList
                                   orderby air.ID descending
                                   select air.ID).First();
                        MessageBox.Show("Airline ID is already available Kindly change your id: ", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {

                        listBoxAirlines.DataContext = null;
                        //adding data into list
                        airlinesList.Add(new AirlinesModel(id, textBoxAirName.Text, airplaneRadio, int.Parse(textBoxSeats.Text), mealRadio));
                        //updating list
                        listBoxAirlines.DataContext = airlinesList;
                    }
                }
                else
                    //if user does not enter all fields show error message
                    MessageBox.Show("Kindly fill all fields", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                //if there is some problem in Airlines window.
                MessageBox.Show("Something wrong while opening window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            //checking for super user
            if (LoginWindow.checkSuperUser == 0)
            {
                //if customer is not super user he can not insert data
                //show error message
                MessageBox.Show("You are not allowed to update airlines, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            try
            {
                //check user has selected airlines or not
                if (textBoxAirID.Text == "" || listBoxAirlines.SelectedItem == null)
                {
                    MessageBox.Show("Kindly select airlines record from listbox", "Pay Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                AirlinesModel selectedAir = (AirlinesModel)listBoxAirlines.SelectedItem;

                //getting data from list where id matches
                int id = int.Parse(textBoxAirID.Text);
                var data = from air in airlinesList
                           where air.ID == selectedAir.ID
                           select air;
                //if the data is not available
                if (data.Count() == 0)
                {
                    MessageBox.Show("Airlines id not Found", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var dupID = from dair in airlinesList
                                where dair.ID == id && id != selectedAir.ID
                                select dair;
                    //if id is duplicate
                    if (dupID.Count() > 0)
                    {
                        MessageBox.Show("Duplicate ID, kindly try again", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    //check that user has enter all fields
                    if (textBoxAirID.Text != "" && textBoxAirName.Text != "" && textBoxSeats.Text != "" && mealRadio != "" && airplaneRadio != "")
                    {
                        if (MessageBox.Show("Are you sure you want to update record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //updating data in list
                            listBoxAirlines.DataContext = null;
                            //remove data from list
                            airlinesList.Remove(data.First());
                            //add updated data into list
                            airlinesList.Add(new AirlinesModel(id, textBoxAirName.Text, airplaneRadio, int.Parse(textBoxSeats.Text), mealRadio));
                            //show updated list into listbox
                            listBoxAirlines.DataContext = airlinesList;
                        }
                        else
                        {
                            MessageBox.Show("No changes", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    }
                    else
                        //if user does not enter all fields show error message
                        MessageBox.Show("Kindly fill all fields", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                //if there is some problem in airlines window.
                MessageBox.Show("Something wrong while opening window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //checking user is super user or not
            if (LoginWindow.checkSuperUser == 0)
            {
                //if customer is not super user he can not insert data
                //show error message
                MessageBox.Show("You are not allowed to Delete customer, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            try
            {
                AirlinesModel selectedAir = (AirlinesModel)listBoxAirlines.SelectedItem;
                //if user has not selected any airlines
                if (selectedAir == null)
                {
                    MessageBox.Show("Kindly select irlines record from listbox", "NULL", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var data = (from air in airlinesList
                            where air.ID == selectedAir.ID && air.Name == selectedAir.Name
                            select air).First();
                //deleting data
                if (data != null)
                {
                    if (MessageBox.Show("Are you sure you want to Delete record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        listBoxAirlines.DataContext = null;
                        //delete data from list
                        airlinesList.Remove(data);
                        listBoxAirlines.DataContext = airlinesList;
                        //show data in listbox after deletion
                        textBoxAirID.Text = "";
                        textBoxAirName.Text = "";
                        textBoxSeats.Text = "";
                        airplaneRadio = "";
                        mealRadio = "";
                    }
                    else
                        return;
                }
            }
            catch
            {
                MessageBox.Show("Unable to delete", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rbPlane_Checked(object sender, RoutedEventArgs e)
        {
            //getting data when airplane is checked
            var rb = (RadioButton)sender;
            airplaneRadio = rb.Content.ToString();
        }
        private void rbMeal_Checked(object sender, RoutedEventArgs e)
        {
            //getting data when meal is checked
            var rb = (RadioButton)sender;
            mealRadio = rb.Content.ToString();
        }

        private void txt_Keyup(object sender, KeyEventArgs e)
        {
            //checking for valid input
            TextBox txtbox = new TextBox();
            try
            {
                txtbox = (TextBox)sender;
                int.Parse(txtbox.Text);
            }
            catch
            {
                //checking for valid inputs
                MessageBox.Show("Invalid input! Kindly enter positive number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                if (txtbox == textBoxAirID)
                    textBoxAirID.Text = "";
                else if (txtbox == textBoxSeats)
                    textBoxSeats.Text = "";
            }
        }

    }
}
