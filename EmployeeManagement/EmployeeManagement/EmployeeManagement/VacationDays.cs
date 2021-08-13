using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem
{
    class VacationDays
    {
        //creating autoImplemented properties.
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int NumberOfDays { get; set; }

        //creating constructor.
        public VacationDays(int id, int employeeId, int noOfDays)
        {
            this.Id = id;
            this.EmployeeId = employeeId;
            this.NumberOfDays = noOfDays;
        }
    }
}
