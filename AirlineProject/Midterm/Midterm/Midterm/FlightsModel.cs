using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
   public class FlightsModel
    {
        //creating auto implemented properties
        public int ID { get; set; }
        public int AirlineID { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureDate { get; set; }
        public double FlightTime { get; set; }

        //creating list of FlightsModel to store the collection of these objects

        public List<FlightsModel> flightsList = new List<FlightsModel>();

        //creating constructors
        public FlightsModel() { }

        public FlightsModel(int id, int airlineId, string departureCity, string destinationCity, string departureDate, double flightTime)
        {


            ID = id;
            AirlineID = airlineId;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
            DepartureDate = departureDate;
            FlightTime = flightTime;


        }

    }
}
