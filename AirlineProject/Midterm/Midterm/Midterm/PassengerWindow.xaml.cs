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
    /// Interaction logic for PassengerWindow.xaml
    /// </summary>
    public partial class PassengerWindow : Window
    {
        public PassengerWindow()
        {
            InitializeComponent();
        }
        public List<CustomerModel> customerList = new List<CustomerModel>();
        public List<FlightsModel> flightsList = new List<FlightsModel>();
        public List<PassengerModel> passengerList = new List<PassengerModel>();


        //here texboxes names are listboxCustomers and listBoxFlights for ease
        private void Menu_GotFocus(object sender, RoutedEventArgs e)
        {
            //to change the foreColor when get focus
            QuitMenu.Foreground = Brushes.Red;
        }

        private void Menu_LostFocus(object sender, RoutedEventArgs e)
        {
            //to change the foreColor when lost focus
            QuitMenu.Foreground = Brushes.Black;
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            //to close the current window
            this.Close();
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWin = new AboutWindow();
            aboutWin.Show();
        }

        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cust = new CustomerWindow();
            cust.Show();
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow fw = new FlightWindow();
            fw.Show();
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow airw = new AirlinesWindow();
            airw.Show();
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
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

        private void listBoxPassengers_Loaded(object sender, RoutedEventArgs e)
        {
            //to load data into the passenger listbox
            passengerList = new DataContext().FillPassengerData();
            var data = from pas in passengerList
                       orderby pas.ID
                       select pas;
            listBoxPassengers.DataContext = data;

            customerList = new DataContext().FillCustomerData();
            flightsList = new DataContext().FillFlightsData();
            

        }

        private void listBoxPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PassengerModel selectedPas = (PassengerModel)listBoxPassengers.SelectedItem;
                //if selected item from listbox is not null
                if (selectedPas != null)
                {
                    //get dat from customer list using join
                    var data = (from c in customerList
                                join ps in passengerList
                                on c.ID equals ps.CustomerID
                                join fl in flightsList
                                on ps.FlightsID equals fl.ID
                                where ps.ID == selectedPas.ID
                                select new List<int> { c.ID, fl.ID }).First();

                    listBoxCustomers.Text = data[0].ToString();
                    listBoxFlights.Text = data[1].ToString();
                    
                }
            }
            catch
            {
                //if there is some problem in flights window.
                MessageBox.Show("Something wrong while opening window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking if user is super user or not
                if (LoginWindow.checkSuperUser == 0)
                {
                    //if customer is not super user he can not insert data
                    //show error message
                    MessageBox.Show("You are not allowed to insert Passenger, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                //checking if user has selected flights or customers
                if (listBoxFlights.Text != "" && listBoxCustomers.Text != "")
                {
                    //inserting data
                    var id = (from pas in passengerList
                              orderby pas.ID descending
                              select pas.ID).First();

                    listBoxPassengers.DataContext = null;
                    passengerList.Add(new PassengerModel(id + 1, Int32.Parse(listBoxCustomers.Text), Int32.Parse(listBoxFlights.Text)));
                    
                    //adding data in the lists because of the foreign keys
                    customerList.Add(new CustomerModel(Int32.Parse(listBoxCustomers.Text), "","","",""));
                    flightsList.Add(new FlightsModel(Int32.Parse(listBoxFlights.Text), 1 ,"","","",1.00));
                    //updating listbox of passenger
                    var newdata = from ps in passengerList
                                  orderby ps.ID
                                  select ps;
                    listBoxPassengers.DataContext = newdata;
                }
                else
                    MessageBox.Show("Please Select Customer and Flights", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                //if there is some problem in pssenger window.
                MessageBox.Show("Something wrong while opening window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking for super user
                if (LoginWindow.checkSuperUser == 0)
                {
                    //if customer is not super user he can not insert data
                    //show error message
                    MessageBox.Show("You are not allowed to update pssenger, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                //checking if user has selected something
                if (listBoxPassengers.SelectedItem == null)
                {
                    MessageBox.Show("No record is selected, please select one from listboxes", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PassengerModel selectedPas = (PassengerModel)listBoxPassengers.SelectedItem;
                //checking for same id
                var data = (from pas in passengerList
                            where pas.ID == selectedPas.ID
                            select pas).First();

                //if no dta found
                if (data == null)
                {
                    MessageBox.Show("passenger id not Found", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (listBoxPassengers.SelectedItem != null)
                    {
                        if (MessageBox.Show("Are you sure you want to update record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            var data1 = (from cust in customerList
                                        where cust.ID == Int32.Parse(listBoxCustomers.Text)
                                         select cust).First();
                            var data2 = (from fly in flightsList
                                         where fly.ID == Int32.Parse(listBoxFlights.Text)
                                         select fly).First();
                            if (data1 != null && data2!=null)
                            {
                                //updating records
                                listBoxPassengers.DataContext = null;
                                //remove data from list
                                passengerList.Remove(data);
                                //add updated data into list

                                passengerList.Add(new PassengerModel(data.ID, Int32.Parse(listBoxCustomers.Text), Int32.Parse(listBoxFlights.Text)));
                                //show updated list into listbox
                                var newdata = from ps in passengerList
                                              orderby ps.ID
                                              select ps;
                                listBoxPassengers.DataContext = newdata;
                            }
                            else {
                                MessageBox.Show("Kindly enter flights and customer id that are available", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No changes", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
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
                //if there is some problem in passenger window.
                MessageBox.Show("Kindly enter flights and customer id that are available", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //checking user is super user or not
                if (LoginWindow.checkSuperUser == 0)
                {
                    //if customer is not super user he can not insert data
                    //show error message
                    MessageBox.Show("You are not allowed to Delete Passenger, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                PassengerModel selPass = (PassengerModel)listBoxPassengers.SelectedItem;

                //if user does not select any data
                if (selPass == null)
                {
                    MessageBox.Show("No Flight is selected, please select from Flights list", "Null", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //selecting data from passenger list
                var data = (from pas in passengerList
                                where pas.ID == selPass.ID && pas.CustomerID == selPass.CustomerID && pas.FlightsID == selPass.FlightsID
                                select pas).First();


                //if record is not null
                if (data != null)
                {
                    //deleting data
                    if (MessageBox.Show("Are you sure you want to Delete record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        listBoxPassengers.DataContext = null;
                        //delete data from list
                        passengerList.Remove(data);
                        //show data in listbox after deletion
                        listBoxPassengers.DataContext = passengerList;
                        listBoxFlights.Text = "";
                        listBoxCustomers.Text = "";
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

        private void listBoxCustomers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBoxFlights_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
