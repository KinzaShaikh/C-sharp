using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    public class CustomerModel
    {

        //creating auto implemented properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //creating list of CustomerModel to store the collection of these objects

        public List<CustomerModel> customerList = new List<CustomerModel>();

        //creating constructors

        public CustomerModel() { }

        public CustomerModel(int id, string name, string address, string email, string phoneNo)
        {

            ID = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phoneNo;

        }

    }
}
