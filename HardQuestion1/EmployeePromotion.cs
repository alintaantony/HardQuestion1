using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardQuestion1
{
    class EmployeePromotion
    {
        List<Employee> employeeList = new List<Employee>();
        Dictionary<int,Employee> employees = new Dictionary<int, Employee>();
        public void DisplayMenu()
        {
            int option;
            try
            {

                Console.WriteLine($"Please enter the option \n 1. Add an employee \n 2. Modify an employee detail \n 3. Print all employees' details \n 4. Print an employee detail \n 5. Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EmployeeDetails();
                        break;
                    case 2:
                        ModifyEmployeeDetail();
                        break;
                    case 3:
                        PrintAllEmployeeDetails();
                        break;
                    case 4:
                        PrintSelectedEmployeeDetail();
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Enter the Correct Option");
                        DisplayMenu();
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Sorry !! Something Went Wrong !! Please Try Again !!");
                Console.WriteLine(e);
                DisplayMenu();
            }
        }
        public void EmployeeDetails()
        {
            int input = 1;
            
            
            try
            {
                while (input == 1)
                {
                    Employee employeeClassObject = new Employee();
                    employeeClassObject.TakeEmployeeDetailsFromUser();
                    employees.Add(employeeClassObject.Id, employeeClassObject);
                    Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                foreach (var employeeDictObject in employees)
                {
                    employeeList.Add(employeeDictObject.Value);
                }
                if (input == 0)
                {
                    DisplayMenu();
                }
                else
                {
                    Console.WriteLine("Please Enter 1 or 0 only !! Thank You");
                    EmployeeDetails();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry !! Something Went Wrong !! Please Try Again !!");
                Console.WriteLine(e);
                DisplayMenu();
            }
           
        }
        public void ModifyEmployeeDetail()
        {
            int employeeIdToModify;
            string modifiedName;
            int modifiedAge;
            double modifiedSalary;
            try
            {
                if (employeeList.Count == 0)
                {
                    Console.WriteLine("Please Add Employee Details");
                }
                else
                {
                    Console.WriteLine("Please enter the employee ID");
                    employeeIdToModify = Convert.ToInt32(Console.ReadLine());
                    if (!employees.ContainsKey(employeeIdToModify))
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                    }
                    Console.WriteLine("The employee details:");
                    
                    foreach (var employeeListToModify in employeeList)
                    {
                        if (employeeListToModify.Id == employeeIdToModify)
                        {
                            Console.WriteLine(employeeListToModify);
                            Console.WriteLine("Please enter the updated employee details");
                            Console.WriteLine("Please enter the employee name");
                            modifiedName = Console.ReadLine();
                            employeeListToModify.Name = modifiedName;
                            Console.WriteLine("Please enter the employee age");
                            modifiedAge = Convert.ToInt32(Console.ReadLine());
                            employeeListToModify.Age = modifiedAge;
                            Console.WriteLine("Please enter the employee salary");
                            modifiedSalary = Convert.ToDouble(Console.ReadLine());
                            employeeListToModify.Salary = modifiedSalary;
                        }
                    }
                }
                DisplayMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry !! Something Went Wrong !! Please Try Again !!");
                Console.WriteLine(e);
                DisplayMenu();
            }
        }

        public void PrintAllEmployeeDetails()
        {
            try
            {
                if (employeeList.Count == 0)
                {
                    Console.WriteLine("Please Add Employee Details");
                }
                else
                {
                    foreach (var employeeListObject in employeeList)
                    {
                        Console.WriteLine(employeeListObject);
                    }
                }
                DisplayMenu();
            }catch(Exception e)
            {
                Console.WriteLine("Sorry !! Something Went Wrong !! Please Try Again !!");
                Console.WriteLine(e);
                DisplayMenu();
            }
        }
        public void PrintSelectedEmployeeDetail()
        {
            int employeeIdToModify;
            try
            {
                if (employeeList.Count == 0)
                {
                    Console.WriteLine("Please Add Employee Details");
                }
                else
                {

                    Console.WriteLine("Please enter the employee ID");

                    employeeIdToModify = Convert.ToInt32(Console.ReadLine());
                    if (!employees.ContainsKey(employeeIdToModify))
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                    }
                    else
                    {
                        var filteredResult = from empFilteredList in employeeList where empFilteredList.Id == employeeIdToModify select empFilteredList;
                        Console.WriteLine("The employee details:");
                        foreach (var filteredEmployeeListObject in filteredResult)
                        {
                            Console.WriteLine(filteredEmployeeListObject);
                        }
                    }
                   
                }
                DisplayMenu();
            }catch(Exception e)
            {
                Console.WriteLine("Sorry !! Something Went Wrong !! Please Try Again !!");
                Console.WriteLine(e);
                DisplayMenu();
            }
        }
    }
}
