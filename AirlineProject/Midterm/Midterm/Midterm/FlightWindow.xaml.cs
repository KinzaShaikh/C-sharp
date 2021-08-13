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
using System.Linq;
namespace Midterm
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        public FlightWindow()
        {
            InitializeComponent();
        }
        public List<AirlinesModel> airlineList = new List<AirlinesModel>();
        public List<FlightsModel> flightsList = new List<FlightsModel>();

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
            CustomerWindow cs = new CustomerWindow();
            cs.Show();
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow airw = new AirlinesWindow();
            airw.Show();
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow pw = new PassengerWindow();
            pw.Show();
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
            flightsList = new DataContext().FillFlightsData();
            airlineList = new DataContext().FillAirlinesData();
            var data = from air in airlineList
                       orderby air.ID
                       select air;
            listBoxAirlines.DataContext = data;
        }

        private void listBoxAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AirlinesModel selAirline = (AirlinesModel)listBoxAirlines.SelectedItem;
                listBoxFlights.DataContext = null;
                if (selAirline != null)
                {
                    var data = from fl in flightsList
                               join air in airlineList
                               on fl.AirlineID equals air.ID
                               where fl.AirlineID == selAirline.ID
                               select fl;
                    listBoxFlights.DataContext = data;
                }
            }
            catch
            {
                MessageBox.Show("Something wrong in opening Flights Window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listBoxFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                FlightsModel selFlight = (FlightsModel)listBoxFlights.SelectedItem;

                if (selFlight != null)
                {
                    var data = (from fl in flightsList
                                where fl.ID == selFlight.ID && fl.AirlineID == selFlight.AirlineID
                                select fl).First();

                    txtFlightID.Text = data.ID.ToString();
                    txtDepartureCity.Text = data.DepartureCity;
                    txtDestinationCity.Text = data.DestinationCity;
                    txtDepartureDate.Text = data.DepartureDate;
                    txtFlightTime.Text = data.FlightTime.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Something wrong in opening Flightss Window", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.checkSuperUser == 0)
            {
                MessageBox.Show("You can't insert flights, Ask SuperUser", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            try
            {
                if (txtFlightID.Text != "" && txtDepartureCity.Text != "" && txtDestinationCity.Text != "" && txtDepartureDate.Text != "" && txtFlightTime.Text != "" && listBoxAirlines.SelectedItem != null)
                {
                    int id = int.Parse(txtFlightID.Text);
                    var d = (from fl in flightsList
                             where fl.ID == id
                             select fl);
                    if (d.Count() > 0)
                    {
                        var aid = (from fl in flightsList
                                   orderby fl.ID descending
                                   select fl.ID).First();
                        MessageBox.Show("Duplicate ID, Try again ", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        listBoxFlights.DataContext = null;
                        int AirID = (int)listBoxAirlines.SelectedValue;
                        flightsList.Add(new FlightsModel(id, AirID, txtDepartureCity.Text, txtDestinationCity.Text, txtDepartureDate.Text, double.Parse(txtFlightTime.Text)));
                        var newdata = from fl in flightsList
                                      where fl.AirlineID == AirID
                                      select fl;
                        listBoxFlights.DataContext = newdata;
                    }
                }
                else
                    MessageBox.Show("Kindly enter all fields, Please Fill/select data", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Something wrong in opening Flightss Window", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoginWindow.checkSuperUser == 0)
                {
                    MessageBox.Show("You can not update flights, Ask SuperUser", "Unauthorized access", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                if (txtFlightID.Text == "" || listBoxAirlines.SelectedItem == null || listBoxFlights.SelectedItem == null)
                {
                    MessageBox.Show("No Flights record is selected, please select one from left listboxes", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                AirlinesModel selAirline = (AirlinesModel)listBoxAirlines.SelectedItem;
                FlightsModel selFlight = (FlightsModel)listBoxFlights.SelectedItem;

                int id = int.Parse(txtFlightID.Text);
                var flight = from fl in flightsList
                             where fl.ID == selFlight.ID && fl.AirlineID == selAirline.ID
                             select fl;

                if (flight.Count() == 0)
                {
                    MessageBox.Show(" flight ID not found, Try again", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var dupID = from flid in flightsList
                                where flid.ID == id && id != selFlight.ID
                                select flid;
                    if (dupID.Count() > 0)
                    {
                        MessageBox.Show("Flights ID is duplicated, please try another", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (txtFlightID.Text != "" && txtDepartureCity.Text != "" && txtDestinationCity.Text != "" && txtDepartureDate.Text != "" && txtFlightTime.Text != "" && listBoxAirlines.SelectedItem != null && listBoxFlights.SelectedItem != null)
                    {
                        if (MessageBox.Show("Do you want to UPDATE this record?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            listBoxFlights.DataContext = null;
                            flightsList.Remove(flight.First());
                            flightsList.Add(new FlightsModel(id, (int)listBoxAirlines.SelectedValue, txtDepartureCity.Text, txtDestinationCity.Text, txtDepartureDate.Text, double.Parse(txtFlightTime.Text)));
                            var newdata = from fl in flightsList
                                          where fl.AirlineID == (int)listBoxAirlines.SelectedValue
                                          select fl;
                            listBoxFlights.DataContext = newdata;
                        }
                        else
                        {
                            MessageBox.Show("No changes made", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    }
                    else
                        MessageBox.Show("Every field in the form is mandatory, please fill all", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong please try again opening Flights Window", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoginWindow.checkSuperUser == 0)
                {
                    MessageBox.Show("You are not allowed to perform this operation, Ask SuperUser for help", "Unauthorized access", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                FlightsModel selFlight = (FlightsModel)listBoxFlights.SelectedItem;

                if (selFlight == null)
                {
                    MessageBox.Show("No Flights is selected, please select one from Flights list", "Null reference", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var data = (from fl in flightsList
                            where fl.ID == selFlight.ID && fl.AirlineID == selFlight.AirlineID
                            select fl).First();
                if (data != null)
                {
                    if (MessageBox.Show("Do you want to DELETE this record?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        listBoxFlights.DataContext = null;
                        flightsList.Remove(data);
                        var newdata = from fl in flightsList
                                      where fl.AirlineID == selFlight.AirlineID
                                      select fl;
                        listBoxFlights.DataContext = newdata;
                        txtFlightID.Text = "";
                        txtDepartureCity.Text = "";
                        txtDestinationCity.Text = "";
                        txtDepartureDate.Text = "";
                        txtFlightTime.Text = "";
                    }
                    else
                        return;
                }
            }
            catch
            {
                MessageBox.Show("Unable to delete the record", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txt_Keyup(object sender, KeyEventArgs e)
        {
            TextBox txtbox = new TextBox();
            try
            {
                txtbox = (TextBox)sender;
                if (txtbox == txtFlightID)
                    int.Parse(txtbox.Text);
                else if (txtbox == txtFlightTime)
                    double.Parse(txtFlightTime.Text);
            }
            catch
            {
                MessageBox.Show("Invalid input. value should be positive number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                if (txtbox == txtFlightID)
                    txtFlightID.Text = "";
                else if (txtbox == txtFlightTime)
                    txtFlightTime.Text = "";
            }
        }
    }
}
