using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            DisplayMenu();
        }

        public static void DisplayMenu()
        {

            List<Employee> employees = new List<Employee>{
            new Employee(100,"John","Canada","John@gmail.com","+1 (647) 123-1234","Manager"),
            new Employee(101,"Ashly","Canada","Ashly@gmail.com","+1 (647) 234-5678","Employee"),
            new Employee(102,"James","Canada","James@gmail.com","+1 (647) 456-7891","Employee"),
            new Employee(103,"Luke","Canada","Luke@gmail.com","+1 (647) 011-1234","Employee"),
            new Employee(104,"Jason","Canada","Jason@gmail.com","+1 (647) 141-5161","Employee")
            };
            List<Payroll> payrolls = new List<Payroll> {
            new Payroll(10,100,7,7.7,DateTime.Today.ToString("dd-MM-yyyy")),
            new Payroll(11,101,8,8.8,DateTime.Today.ToString("dd-MM-yyyy")),
            new Payroll(12,102,9,9.9,DateTime.Today.ToString("dd-MM-yyyy")),
            new Payroll(13,103,8,8.8,DateTime.Today.ToString("dd-MM-yyyy")),
            new Payroll(14,104,7,7.7,DateTime.Today.ToString("dd-MM-yyyy")),
            };
            List<VacationDays> vacationDays = new List<VacationDays> {
            new VacationDays(1,100,14),
            new VacationDays(2,101,14),
            new VacationDays(3,102,14),
            new VacationDays(4,103,14),
            new VacationDays(5,104,14),
            };


            int choice;
            choice = 1;
            int menu2Choice, menu3Choice, menu4Choice;
            while (choice != 4)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("___Employee Management System____");
                Console.WriteLine("------------WELCOME--------------");
                Console.WriteLine("___Press 1 to modify employees___");
                Console.WriteLine("-----Press 2 to add payroll------");
                Console.WriteLine("__Press 3 to view vacation days__");
                Console.WriteLine("-----Press 4 to exit program-----");
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    menu2Choice = 1;
                    while (menu2Choice != 5)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("___Press 1 to list all employees____");
                        Console.WriteLine("___Press 2 to add a new employee____");
                        Console.WriteLine("___Press 3 to update an employees___");
                        Console.WriteLine("___Press 4 to delete an employees___");
                        Console.WriteLine("___Press 5 to return to main menu___");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        menu2Choice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        if (menu2Choice == 1)
                        {
                            Console.WriteLine();
                            if (employees.Count == 0)
                                Console.WriteLine("Empty List");

                            else
                                DisplayEmployee(employees);
                            Console.WriteLine();
                        }
                        else if (menu2Choice == 2)
                        {


                            Employee emp = AddEmployee();
                            var employee = from empl in employees
                                           where empl.ID == emp.ID
                                           select empl;
                            if (employee.Any())
                            {
                                Console.WriteLine("___Employee with this id already exists___");
                            }
                            else
                            {
                                employees.Add(emp);
                                VacationDays vac = AddVacationDays(emp);

                                var vDays = from v in vacationDays
                                            where v.Id == vac.Id
                                            select v;
                                while (vDays.Any())
                                {
                                    Console.WriteLine("____Vacation Id Already Exists_____");

                                    vac = AddVacationDays(emp);
                                }


                                vacationDays.Add(vac);

                                Payroll payroll = InsertPayroll(emp.ID);

                                var payrollCheck = from p in payrolls
                                                   where p.Id == payroll.Id
                                                   select p;
                                while (payrollCheck.Any())
                                {
                                    Console.WriteLine("Payroll Id Already exists!");
                                    payroll = InsertPayroll(emp.ID);

                                }
                                payrolls.Add(payroll);

                            }
                        }
                        else if (menu2Choice == 3)
                        {
                            UpdateEmployee(employees);

                        }
                        else if (menu2Choice == 4)
                        {
                            DeleteEmployee(employees,vacationDays,payrolls);
                        }
                    }

                }
                else if (choice == 2)
                {
                    menu3Choice = 1;
                    while (menu3Choice != 3)
                    {
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("____________Press 1 to insert new payroll entry_____________");
                        Console.WriteLine("_______Press 2 to view payroll history of an employee_______");
                        Console.WriteLine("________________Press 3 return to main menu_________________");
                        Console.WriteLine("------------------------------------------------------------");
                        menu3Choice = Convert.ToInt32(Console.ReadLine());

                        if (menu3Choice == 1)
                        {
                            InsertNewPayroll(employees, payrolls, vacationDays);
                        }
                        else if (menu3Choice == 2)
                        {
                            ViewPayrollHistiry(payrolls);
                        }
                    }

                }

                else if (choice == 3)
                {
                    menu4Choice = 1;
                    while (menu4Choice != 3)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("___Press 1 to view Vacation days of an employee____");
                        Console.WriteLine("_______Press 2 to view list of vacation days_______");
                        Console.WriteLine("____________Press 3 return to main menu____________");
                        Console.WriteLine("---------------------------------------------------");
                        menu4Choice = Convert.ToInt32(Console.ReadLine());

                        if (menu4Choice == 1)
                        {
                            if (vacationDays.Count != 0)
                            {
                                DisplayVacationDays(vacationDays);
                            }
                            else
                            {
                                Console.WriteLine("List is empty");
                            }
                        }
                        else if (menu4Choice == 2)
                        {
                            if (vacationDays.Count != 0)
                            {
                                DisplayListOfVacationDays(vacationDays);
                            }
                            else
                            {
                                Console.WriteLine("List is empty!");
                            }
                        }
                    }
                }
            }
            static Employee AddEmployee()
            {
                int id;
                string name, address, email, phoneNo, role;
                Console.WriteLine("___Enter Employee id____");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("___Enter Employee name____");
                name = Console.ReadLine();
                Console.WriteLine("___Enter Employee address____");
                address = Console.ReadLine();
                Console.WriteLine("___Enter Employee email____");
                email = Console.ReadLine();
                Console.WriteLine("___Enter Employee phone number____");
                phoneNo = Console.ReadLine();
                Console.WriteLine("___Enter Employee role____");
                role = Console.ReadLine();

                return new Employee(id, name, address, email, phoneNo, role);
            }
            static void DisplayEmployee(List<Employee> empList)
            {
                Console.WriteLine();
                Console.WriteLine("----List of Employees----");
                Console.WriteLine();
                foreach (Employee e in empList)
                {

                    Console.WriteLine(string.Format("Employee Id: {0}, Name: {1}, Address: {2}, Email: {3}, PhoneNo: {4}, Role: {5}", e.ID, e.Name, e.Address, e.Email, e.PhoneNumber, e.Role));
                }

            }

            static void UpdateEmployee(List<Employee> employees)
            {
                int empid;
                Console.WriteLine("___Enter Employee id that you want to update____");
                empid = Convert.ToInt32(Console.ReadLine());
                var find = (from e in employees
                            where e.ID == empid
                            select e).SingleOrDefault();
                if (find != null)
                {
                    Console.WriteLine("___Enter Employee name____");
                    find.Name = Console.ReadLine();
                    Console.WriteLine("___Enter Employee address____");
                    find.Address = Console.ReadLine();
                    Console.WriteLine("___Enter Employee email____");
                    find.Email = Console.ReadLine();
                    Console.WriteLine("___Enter Employee phone number____");
                    find.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("___Enter Employee role____");
                    find.Role = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("UPDATED!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Employee with this id does not exist");
                }

            }

            static void DeleteEmployee(List<Employee> employees,List<VacationDays> vacationDays,List<Payroll> payrolls)
            {

                int empid;
                Console.WriteLine("___Enter Employee id that you want to Delete____");
                empid = Convert.ToInt32(Console.ReadLine());

                var find = (from employee in employees
                            where employee.ID == empid
                            select employee).SingleOrDefault();

                if (find != null)
                {
                    employees.Remove(find);
                    var vDays = (from vacDays in vacationDays
                                 where vacDays.EmployeeId == empid
                                 select vacDays).SingleOrDefault();
                    vacationDays.Remove(vDays);
                    var payroll = (from payrol in payrolls
                                   where payrol.EmployeeId == empid
                                   select payrol).SingleOrDefault();
                    payrolls.Remove(payroll);
                    Console.WriteLine("DELETED!");
                }
                else
                {
                    Console.WriteLine("Employee with this id does not exist");
                }
            }

            static VacationDays AddVacationDays(Employee emp)
            {
                int id, vacationdays;
                Console.WriteLine("___Enter Vacation id____");
                id = Convert.ToInt32(Console.ReadLine());
                vacationdays = 14;
                return new VacationDays(id, emp.ID, vacationdays);
            }


            static void DisplayVacationDays(List<VacationDays> vacationDays)
            {

                int id;
                Console.WriteLine("___Enter Employee id____");
                id = Convert.ToInt32(Console.ReadLine());

                var days = (from vacDays in vacationDays
                            where vacDays.EmployeeId == id
                            select vacDays).SingleOrDefault();
                if (days != null)
                {
                    Console.WriteLine(string.Format("Id: {0}, Employee ID: {1}, Number of days: {2}", days.Id, days.EmployeeId, days.NumberOfDays));

                }
                else
                {
                    Console.WriteLine("Employee with this id dose not exit");
                }

            }

            static void DisplayListOfVacationDays(List<VacationDays> vacationDays)
            {

                Console.WriteLine();
                Console.WriteLine("----List of Vacation days----");
                Console.WriteLine();
                
                foreach (VacationDays days in vacationDays)
                {
                    Console.WriteLine(string.Format("Id: {0}, Employee ID: {1}, Number of days: {2}", days.Id, days.EmployeeId, days.NumberOfDays));
                }
            }
            static Payroll InsertPayroll(int id)
            {
                int pId, wHours;
                double hourlyRate;
                string date;
                Payroll newItem;

                Console.WriteLine("_____Enter Payroll id_____");
                pId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("___Enter Employee Worked hours____");
                wHours = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("___Enter Employee Hourly rate____");
                hourlyRate = Convert.ToDouble(Console.ReadLine());
                date = DateTime.Today.ToString("dd-MM-yyyy");
                newItem = new Payroll(pId, id, wHours, hourlyRate, date);
                return newItem;
            }

            static void InsertNewPayroll(List<Employee> employees, List<Payroll> payrolls, List<VacationDays> vacationDays)
            {
                int id;
                Console.WriteLine("___Enter Employee id____");
                id = Convert.ToInt32(Console.ReadLine());

                var emp = (from employee in employees
                           where employee.ID == id
                           select employee).SingleOrDefault();
                if (emp != null)
                {
                    var payroll = (from payrol in payrolls
                                   where payrol.EmployeeId == id
                                   select payrol).SingleOrDefault();
                    if (payroll != null)
                    {
                        Console.WriteLine("___Enter Employee Worked hours____");
                        payroll.WorkedHours = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("___Enter Employee Hourly rate____");
                        payroll.HourlyRate = Convert.ToDouble(Console.ReadLine());
                        payroll.Date = DateTime.Today.ToString("dd-MM-yyyy");

                        var vacDays = vacationDays.SingleOrDefault(vdays => vdays.EmployeeId == id);
                        if (vacDays != null)
                        {
                            vacDays.NumberOfDays += 1;
                        }

                        Console.WriteLine("New Entry is Entered!");
                    }
                }
                else
                {
                    Console.WriteLine("Employee with this id does not exists");
                }

            }

            static void ViewPayrollHistiry(List<Payroll> payrolls)
            {

                int id;
                Console.WriteLine("___Enter Employee Id____");
                id = Convert.ToInt32(Console.ReadLine());
                var pay = (from payroll in payrolls
                           where payroll.EmployeeId == id
                           select payroll).SingleOrDefault();
                if (pay != null)
                {
                     Console.WriteLine(string.Format("ID: {0}, Employee ID: {1}, hours worked: {2}, hourly rate: {3}, date: {4}", pay.Id, pay.EmployeeId, pay.WorkedHours, pay.HourlyRate, pay.Date));

                }
                else
                {
                    Console.WriteLine("Employee with this id does not exist");
                }
            }
        }
    }
}

