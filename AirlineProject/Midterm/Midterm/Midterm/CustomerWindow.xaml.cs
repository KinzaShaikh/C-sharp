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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>

    public partial class CustomerWindow : Window
    {
        public List<CustomerModel> customerList = new List<CustomerModel>();
        public CustomerWindow()
        {
            InitializeComponent();
        }
        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ViewFlights_Click(object sender, RoutedEventArgs e)
        {
           FlightWindow flw = new FlightWindow();
            flw.Show();
        }

        private void ViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow airWin = new AirlinesWindow();
            airWin.ShowDialog();
        }

        private void ViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow pw = new PassengerWindow();
            pw.Show();
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            //to show about window
            AboutWindow aboutWin = new AboutWindow();
            aboutWin.Show();
        }
        private void QuitMenu_GotFocus(object sender, RoutedEventArgs e)
        {
            //to change the foreColor when get focus
            QuitMenu.Foreground = Brushes.Red;
        }

        private void QuitMenu_LostFocus(object sender, RoutedEventArgs e)
        {
            //to change the foreColor when lost focus
            QuitMenu.Foreground = Brushes.Black;
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            //to close the current window
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

        private void listBoxCustomerName_Loaded(object sender, RoutedEventArgs e)
        {
            //fill data in listbox
            customerList = new DataContext().FillCustomerData();
            var data = from cust in customerList
                       orderby cust.ID
                       select cust;
            listBoxCustomerName.DataContext = data;
        }

        private void listBoxCustomerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //when user select item from list show data in text fields
                CustomerModel selectedCust = (CustomerModel)listBoxCustomerName.SelectedItem;
                if (selectedCust != null)
                {
                    var custdata = (from cust in customerList
                             where cust.ID == selectedCust.ID && cust.Name == selectedCust.Name
                             select cust).First();

                    textboxCustomerID.Text = custdata.ID.ToString();
                    textboxCustomerName.Text = custdata.Name;
                    textboxCustomerAddr.Text = custdata.Address;
                    textboxCustomerEmail.Text = custdata.Email;
                    textboxCustomerPhone.Text = custdata.Phone;
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong please try again opening Customers Window", "Error code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            //checking if user is super user or not
            if (LoginWindow.checkSuperUser == 0)
            {
                //if customer is not super user he can not insert data
                //show error message
                MessageBox.Show("You are not allowed to insert customer, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            try
            {
                //checking if the super user has enter data in all textboxes or not
                if (textboxCustomerID.Text != "" && textboxCustomerName.Text != "" && textboxCustomerAddr.Text != "" && textboxCustomerEmail.Text != "" && textboxCustomerPhone.Text != "")
                {
                    int id = int.Parse(textboxCustomerID.Text);
                    //getting customer data where id is same as input id
                    var custData = (from cust in customerList
                             where cust.ID == id
                             select cust);
                    //if we get data in custData
                    if (custData.Count() > 0)
                    {
                        //checking if we already have data with same id
                        var cId = (from cust in customerList
                                   orderby cust.ID descending
                                   select cust.ID).First();
                        MessageBox.Show("Customer ID is already available Kindly change your id: ", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        //else add data into the customer list
                        listBoxCustomerName.DataContext = null;
                        customerList.Add(new CustomerModel(id, textboxCustomerName.Text, textboxCustomerAddr.Text, textboxCustomerEmail.Text, textboxCustomerPhone.Text));
                        listBoxCustomerName.DataContext = customerList;
                    }
                }
                else
                    //if user does not enter all fields show error message
                    MessageBox.Show("Kindly fill all fields", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                //if there is some problem in customer window.
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
                    MessageBox.Show("You are not allowed to update customer, Ask SuperUser", "Access denied", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                //checking if customer has selected something
                if (textboxCustomerID.Text == "" || listBoxCustomerName.SelectedItem == null)
                {
                    MessageBox.Show("Kindly select customer record from listbox", "Pay Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //seleced item from listbox
                CustomerModel selCust = (CustomerModel)listBoxCustomerName.SelectedItem;

                int id = int.Parse(textboxCustomerID.Text);
                //getting record from list where id matches
                var cust = from cs in customerList
                           where cs.ID == selCust.ID
                           select cs;
                //if no data found
                if (cust.Count() == 0)
                {
                    MessageBox.Show("Customer id not Found", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //if the id is duplicate
                    var dupID = from cid in customerList
                                where cid.ID == id && id != selCust.ID
                                select cid;
                    if (dupID.Count() > 0)
                    {
                        MessageBox.Show("Duplicate ID, kindly try again", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    //checking that user has enter all fields
                    if (textboxCustomerID.Text != "" && textboxCustomerName.Text != "" && textboxCustomerAddr.Text != "" && textboxCustomerEmail.Text != "" && textboxCustomerPhone.Text != "")
                    {
                        if (MessageBox.Show("Are you sure you want to update record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            listBoxCustomerName.DataContext = null;
                            //remove data from list
                            customerList.Remove(cust.First());
                            //add updated data into list
                            customerList.Add(new CustomerModel(id, textboxCustomerName.Text, textboxCustomerAddr.Text, textboxCustomerEmail.Text, textboxCustomerPhone.Text));
                            //show updated list into listbox
                            listBoxCustomerName.DataContext = customerList;
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
                //if there is some problem in customer window.
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
                CustomerModel selCust = (CustomerModel)listBoxCustomerName.SelectedItem;
                if (selCust == null)
                {

                    MessageBox.Show("Kindly select customer record from listbox", "NULL", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var custdata = (from cs in customerList
                         where cs.ID == selCust.ID && cs.Name == selCust.Name
                         select cs).First();
                if (custdata != null)
                {
                    //deleting data
                    if (MessageBox.Show("Are you sure you want to Delete record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        listBoxCustomerName.DataContext = null;
                        //delete data from list
                        customerList.Remove(custdata);
                        //show data in listbox after deletion
                        listBoxCustomerName.DataContext = customerList;
                        textboxCustomerID.Text = "";
                        textboxCustomerName.Text = "";
                        textboxCustomerAddr.Text = "";
                        textboxCustomerEmail.Text = "";
                        textboxCustomerPhone.Text = "";
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

        private void txt_Keyup(object sender, KeyEventArgs e)
        {
            //creating textBox
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
                if (txtbox == textboxCustomerID)
                    textboxCustomerID.Text = "";

            }
        }
    }
}
