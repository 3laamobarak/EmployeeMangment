using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment
{
    public class Department
    {
        public string Name;
        public string DepartmentHead;
        public List<Employee> employees = new List<Employee>();
        public Department(string name, string departmentHead)
        {
            Name = name;
            DepartmentHead = departmentHead;
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void AddEmployee(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                AddEmployee(employee);
            }
        }
        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Department Head: {DepartmentHead}, Number of Employees: ({employees.Count})";
        }

        public static void ListDepartmentsToChoose(List<Department> departments)
        {
            int index = 0;
            foreach (Department department in departments)
            {
                Console.WriteLine($"{index++} - {department.Name}");
            }
        }

        public static string GetDepartmentInput()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter Department like this (name, head) - q to exit");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static void CreateDepartment(List<Department> departments)
        {
            string input = GetDepartmentInput();
            while (input != null && input.Trim() != "q")
            {
                var items = input.Trim().Split(",");
                if (items.Length != 0 || items.Length == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Department Created Successfully");
                    Console.ResetColor();
                    departments.Add(new Department(items[0], items[1]));
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                input = Console.ReadLine();
            }
        }

        public static void EditDepartment(List<Department> departments)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Editing Department, choose number to edit...");
            Console.ResetColor();
            int index = 0;
            foreach (Department Department in departments)
            {
                Console.WriteLine($"{index++} - {Department.Name}");
            }
            string DepartmentNumber = Console.ReadLine();

            if (int.TryParse(DepartmentNumber, out index) && index < departments.Count)
            {
                string input = GetDepartmentInput();
                var items = input.Trim().Split(",");
                if (items.Length != 0 || items.Length == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Department Updated Successfully");
                    Console.ResetColor();
                    departments[index].Name = items[0];
                    departments[index].DepartmentHead = items[1];
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        public static void DeleteDepartment(List<Department> departments)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Deleting Department, choose number to delete...");
            Console.ResetColor();
            int index = 0;
            foreach (Department Department in departments)
            {
                Console.WriteLine($"{index++} - {Department.Name}");
            }
            string DepartmentNumber = Console.ReadLine();
            while (DepartmentNumber != null && DepartmentNumber != "q" && departments.Count > 0)
            {
                if (int.TryParse(DepartmentNumber, out index) && index < departments.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Department {departments[index].Name} Deleted Successfully");
                    Console.ResetColor();
                    departments.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                DepartmentNumber = Console.ReadLine();
            }
        }

        public static void ListDepartments(List<Department> departments)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Avalable Departments....");
            Console.ResetColor();

            foreach (Department Department in departments)
            {
                Console.WriteLine(Department.ToString());
            }
        }
    }
}
