using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem
{
    class Payroll
    {

        //creating autoImplemented properties.
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int WorkedHours { get; set; }
        public double HourlyRate { get; set; }
        public String Date { get; set; }

        //creating constructor
        public Payroll(int id, int employeeId, int workedhours, double hourlyRate, String date)
        {
            this.Id = id;
            this.EmployeeId = employeeId;
            this.WorkedHours = workedhours;
            this.HourlyRate = hourlyRate;
            this.Date = date;
        }

    }
}
