using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment
{
    enum CompanyOperation
    {
        InvalidOperation,
        CreateCompany,
        DeleteCompany,
        EditCompany,
        ListCompanies,
        UseCompany,
        Exit
    }

    enum DepartmentOperation
    {
        InvalidOperation,
        CreateDepartment,
        DeleteDepartment,
        EditDepartment,
        ListDepartments,
        UseDepartment,
        Exit
    }

    enum EmployeeOperation
    {
        InvalidOperation,
        CreateEmployee,
        DeleteEmployee,
        EditEmployee,
        ListEmployee,
        UseEmployee,
        Exit
    }

    class Menu
    {

        
        public static CompanyOperation CompanyListMenu()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("================= Main Menu (Companies) ==================");
            Console.ResetColor();
            Console.WriteLine("1 - Create Company \t 2 - Delete Company \t 3 - Edit Company \t 4 - List Compnaies");
            Console.WriteLine("5 - Use Company");
           Console.WriteLine("q - exit");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result != 0)
            {
                //Console.WriteLine($"The input is a valid integer: {result}");
                return (CompanyOperation)result;
            }
            else
            {
                //Console.WriteLine("The input is not a valid integer.");
                return 0;
            }
        }


        public static DepartmentOperation DepartmentListMenu(Company company)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"================= Company({company.Name}): Departments ==================");
            Console.ResetColor();
            Console.WriteLine("1 - Create Department \t 2 - Delete Department \t 3 - Edit Department \t 4 - List Departments");
            Console.WriteLine("5 - Use Department");
            Console.WriteLine("q - exit");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result != 0)
            {
                return (DepartmentOperation)result;
            }
            else
            {
                return 0;
            }
        }


        public static EmployeeOperation EmployeeListMenu(Department department)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"================= Department({department.Name}): Employees ==================");
            Console.ResetColor();
            Console.WriteLine("1 - Create Employee \t 2 - Delete Employee \t 3 - Edit Employee \t 4 - List Employees");
            Console.WriteLine("5 - Use Employee");
            Console.WriteLine("q - exit");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result != 0)
            {
                //Console.WriteLine($"The input is a valid integer: {result}");
                return (EmployeeOperation)result;
            }
            else
            {
                //Console.WriteLine("The input is not a valid integer.");
                return 0;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Xml.Linq;

class Program
{

    static void Main()
    {
        Employee Emp = new Employee("Shahenda ", 22);
        // Emp.PerformanceRating = 10;
        PerformanceReview.Promote(Emp);
        // Menu.ShowMenu();
        //unique ID, name, age, salary, department, and employment date.
    }

    //class Employee
    //{
    //   private int ID;
    //    private string Name;
    //    private int Age;
    //    private decimal Salary;
    //    private string Department;
    //    private DateTime HiringDate; // EmploymentDate


    //}

    // My Part of The Project 

    class Menu
    {
        public static void ShowMenu()
        {
            while (true) // Keeps the menu running : The menu loops continuously until the user exits
            {
                Console.WriteLine("\n===== Employee Management System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Add Department");
                Console.WriteLine("4. View Departments");
                // Console.WriteLine("4. Transfer Employee");
                Console.WriteLine("5. Promote Employee");
                Console.WriteLine("6. Generate Reports");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":

                        Menu.AddEmployee();
                        break;

                    case "2":
                        Menu.ViewEmployees();
                        break;
                    case "3":
                        Menu.AddDepartment();
                        break;
                    case "4":
                        Menu.ViewDepartments();
                        // Call method to transfer an employee
                        break;
                    case "5":
                        // Call method to promote an employee
                        break;
                    case "6":
                        // Call method to generate reports
                        break;
                    case "7":
                        // Console.WriteLine("Exiting system...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please enter a number from 1 to 7.");
                        break;
                }
            }
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public static void AddEmployee()
        {
            Console.Write("Enter Employee Name : ");
            string Name = Console.ReadLine();

            Console.Write("Enter Employee Age : ");
            int Age = Convert.ToInt32(Console.ReadLine());

            Employee NewEmployee = new Employee(Name, Age);

            Employees.Add(NewEmployee);

            Console.WriteLine("Employee added successfully!");

        }

        public static List<Employee> Employees = new List<Employee>();

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        public static void ViewEmployees()
        {

            if (Employees.Count == 0)
            {
                Console.WriteLine("No Employees Yet");
            }

            else
            {
                foreach (var employee in Employees)
                {
                    Console.WriteLine(employee.Name + " " + employee.Age);
                }
            }


        }
        ////////////////////////////////////////////////////////////////////////////////////////

        public static void AddDepartment()
        {
            Console.Write("Enter Department Name : ");

            string Department = Console.ReadLine();



            Department NewDepartment = new Department(Department);

            Departments.Add(NewDepartment);

            Console.WriteLine("Department added successfully!");

        }

        public static List<Department> Departments = new List<Department>();

        /////////////////////////////////////////////////////////////////////////////////////////

        public static void ViewDepartments()
        {

            if (Departments.Count == 0)
            {
                Console.WriteLine("No Departments Yet");
            }

            else
            {
                foreach (var department in Departments)
                {
                    Console.WriteLine(department.DepartmentName);
                }
            }


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }


    public class Employee
    {
        public string Name;
        public int Age;
        public decimal salary;
        public string JobTitle;
        //public int PerformanceRating;
        List<int> PerformanceRating;

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Promote()


    }

    public class Department
    {
        public string DepartmentName;

        public Department(string department)
        {
            DepartmentName = department;

        }
    }

    public class PerformanceReview
    {
        public static void Promote(Employee Emp)
        {

            if (Emp.PerformanceRating >= 10)
            {
                Console.WriteLine("Employee Promoted");
            }
        }
    }

}
