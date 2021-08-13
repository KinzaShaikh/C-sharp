using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    public class PassengerModel
    {

        //creating auto implemented properties.
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int FlightsID { get; set; }

        //creating list of PassengerModel to store the collection of these objects
        public List<PassengerModel> passengerList = new List<PassengerModel>();

        //craeting constructors.
        public PassengerModel() { }
        public PassengerModel(int id, int customerId, int flightsId)
        {
            ID = id;
            CustomerID = customerId;
            FlightsID = flightsId;
        }

    }
}
