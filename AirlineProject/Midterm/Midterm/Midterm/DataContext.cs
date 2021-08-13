using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class DataContext
    {
        //I have used this class to fill data in to the lists or dictionary
        // preloaded with five pieces of data for eah collection


        //creating objects of model classes.
        LoginModel loginObj = new LoginModel();
        AirlinesModel airlineObj = new AirlinesModel();
        PassengerModel passengetObj = new PassengerModel();
        FlightsModel flightsObj = new FlightsModel();
        CustomerModel customerObj = new CustomerModel();


        //creating method to fill data into login dictionary
        public void FillLoginData()
        {
            LoginModel.loginDictionary = new Dictionary<string, LoginModel> {
            //this is superUser with key 1
            { "mehrasum" , new LoginModel(1, "mehrasum", "mehrasum", 1)},
            { "john" , new LoginModel(2, "john", "john", 0)},
            { "jim" , new LoginModel(3, "jim", "jim", 0)},
            { "mary" , new LoginModel(4, "mary", "mary", 0)},
            { "ruby" , new LoginModel(5, "ruby", "ruby", 0)}

        };
        }

        //creating method to fill data in flights list.
        public List<FlightsModel> FillFlightsData()
        {
            flightsObj.flightsList.Add(new FlightsModel(1, 5, "London", "Toronto", "10 july 2020", 11.30));
            flightsObj.flightsList.Add(new FlightsModel(2, 4, "Dehli", "Mumbai", "11 april 2021", 9.00));
            flightsObj.flightsList.Add(new FlightsModel(3, 3, "London", "Toronto", "5 march 2021", 3.15));
            flightsObj.flightsList.Add(new FlightsModel(4, 2, "London", "Toronto", "19 may 2021", 1.00));
            flightsObj.flightsList.Add(new FlightsModel(5, 1, "London", "Toronto", "29 june 2020", 5.45));
            return flightsObj.flightsList;
        }


        //creating method to fill data into passenger list
        public List<PassengerModel> FillPassengerData()
        {
            passengetObj.passengerList.Add(new PassengerModel(1, 5, 3));
            passengetObj.passengerList.Add(new PassengerModel(2, 4, 5));
            passengetObj.passengerList.Add(new PassengerModel(3, 2, 1));
            passengetObj.passengerList.Add(new PassengerModel(4, 3, 2));
            passengetObj.passengerList.Add(new PassengerModel(5, 1, 4));
            return passengetObj.passengerList;
        }

        //creating method to fill data into airlines list
        public List<AirlinesModel> FillAirlinesData()
        {
            airlineObj.airlineList.Add(new AirlinesModel(1, "Canada Airlines", "Boeing 777", 40, "Salad"));
            airlineObj.airlineList.Add(new AirlinesModel(2, "India Airlines", "Airbus 320", 50, "Chicken"));
            airlineObj.airlineList.Add(new AirlinesModel(3, "British Airlines", "Boeing 777", 14, "Sushi"));
            airlineObj.airlineList.Add(new AirlinesModel(4, "Pakistan Airlines", "Airbus 320", 10, "Chicken"));
            airlineObj.airlineList.Add(new AirlinesModel(5, "abc Airlines", "Boeing 777", 25, "Salad"));
            return airlineObj.airlineList;
        }

        //creating method to fill data into customer list
        public List<CustomerModel> FillCustomerData()
        {
            customerObj.customerList.Add(new CustomerModel(1, "Susan", "Address1", "susan@gmail.com", "123 1234 12345"));
            customerObj.customerList.Add(new CustomerModel(2, "Jimmy", "Address2", "jimmy@gmail.com", "453 5674 56895"));
            customerObj.customerList.Add(new CustomerModel(3, "Smith", "Address3", "smith@gmail.com", "987 3456 12345"));
            customerObj.customerList.Add(new CustomerModel(4, "Robert", "Address4", "robert@gmail.com", "278 1234 35720"));
            customerObj.customerList.Add(new CustomerModel(5, "Rehana", "Address5", "rehana@gmail.com", "123 4729 67392"));
            return customerObj.customerList;
        }
    }
}

