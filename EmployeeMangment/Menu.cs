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
        EmployeMenu,
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


        public static DepartmentOperation DepartmentListMenu()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"================= Company({Program.company.Name}): Departments ==================");
            Console.ResetColor();
            Console.WriteLine("1 - Create Department \t 2 - Delete Department \t 3 - Edit Department \t 4 - List Departments");
            Console.WriteLine("5 - Use Department");
            Console.WriteLine("6 - Employee Menu");
            Console.WriteLine("7 - exit");
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


        public static EmployeeOperation EmployeeListMenu(Department department = null)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            if (department != null)
            {
                Console.WriteLine($"================= Department({department.Name}): Employees ==================");
            }
            else
            {
                Console.WriteLine($"================= Company({Program.company.Name}): Employees ==================");

            }
            Console.ResetColor();
            Console.WriteLine("1 - Create Employee \t 2 - Delete Employee \t 3 - Edit Employee \t 4 - List Employees");
            Console.WriteLine("5 - Use Employee");
            Console.WriteLine("6 - exit");
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
