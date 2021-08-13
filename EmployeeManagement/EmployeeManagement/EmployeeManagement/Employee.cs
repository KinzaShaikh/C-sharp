using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem
{
    class Employee
    {
        //creating auto implemented properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        //creating constructor
        public Employee(int id, string name, string address, string email, string phoneNo, string role)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNo;
            this.Role = role;
        }
    }
}
