using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
   public class AirlinesModel
    {
        //creating auto implemented properties.
        public int ID { get; set; }
        public string Name { get; set; }
        public string Airplane { get; set; }
        public int SeatsAvailable { get; set; }
        public string MealAvailable { get; set; }

        //creating list of AirlineModel to store the collection of these objects
        public List<AirlinesModel> airlineList = new List<AirlinesModel>();

        //creating constructors 
        public AirlinesModel() { }

        public AirlinesModel(int id, string name, string airplane, int seatsAvailable, string mealAvailable)
        {
            ID = id;
            Name = name;
            Airplane = airplane;
            SeatsAvailable = seatsAvailable;
            MealAvailable = mealAvailable;
        }

    }
}
