using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EmployeeMangment.Program;

namespace EmployeeMangment
{
    public class Employee
    {
        int Id;
        public string Name;
        string Age;
        public decimal Salary;
        public short Score = 1;
        Department Department;
        DateTime EmploymentDate;
        Statue statue;

        public Employee(string name, string age, decimal salary, Department department,short score)
        {
            Id = GetHashCode();
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
            EmploymentDate = DateTime.Now;
            statue = Statue.Active;
            Score = score;
        }
        public void promoted(decimal newSalary)
        {
            Score++;
            Salary = newSalary;
        }
        public void Transfer(Department department)
        {
            Department = department;
        }
        public void terminate()
        {
            statue = Statue.Terminated;
        }

        public override string ToString()
        {
            return $"ID: {Id}, \t Name: {Name}, \t Age: {Age}," +
                $"\n\tSalary: {Salary}, Department: {Department.Name}, EmploymentDate: {EmploymentDate}," +
                $"\n\tStatus: {statue}";
        }


        public static string GetEmployeeInput()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter Employee like this (name, age, salary, score) - q to exit");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static void CreateEmployee(List<Employee> employees, Department department)
        {
            string input = GetEmployeeInput();
            while (input != null && input.Trim() != "q")
            {
                var items = input.Trim().Split(",");
                if (items.Length != 0 && items.Length == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee Created Successfully");
                    Console.ResetColor();
                    decimal salary;
                    short score;
                    if (decimal.TryParse(items[2].ToString(), out salary) && short.TryParse(items[3], out score))
                    {
                        employees.Add(new Employee(items[0], items[1], salary, department, score));
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
                input = Console.ReadLine();
            }
        }

        public static void EditEmployee(List<Employee> employees, Department department)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Editing Employee, choose number to edit...");
            Console.ResetColor();
            int index = 0;
            foreach (Employee Employee in employees)
            {
                Console.WriteLine($"{index++} - {Employee.Name}");
            }
            string EmployeeNumber = Console.ReadLine();

            if (int.TryParse(EmployeeNumber, out index) && index < employees.Count)
            {
                string input = GetEmployeeInput();
                var items = input.Trim().Split(",");
                decimal salary;
                short score;
                if (items.Length != 0 && items.Length == 4 && decimal.TryParse(items[2].ToString(), out salary) && short.TryParse(items[3], out score))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee Updated Successfully");
                    Console.ResetColor();
                    employees[index].Name = items[0];
                    employees[index].Age = items[1];
                    employees[index].Salary = salary;
                    employees[index].Score = score;
                    employees[index].Department = department;
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

        public static void DeleteEmployee(List<Employee> employees)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Deleting Employee, choose number to delete...");
            Console.ResetColor();
            int index = 0;
            foreach (Employee Employee in employees)
            {
                Console.WriteLine($"{index++} - {Employee.Name}");
            }
            string EmployeeNumber = Console.ReadLine();
            while (EmployeeNumber != null && EmployeeNumber != "q" && employees.Count > 0)
            {
                if (int.TryParse(EmployeeNumber, out index) && index < employees.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Employee {employees[index].Name} Deleted Successfully");
                    Console.ResetColor();
                    employees.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                EmployeeNumber = Console.ReadLine();
            }
        }

        public static void ListEmployees(List<Employee> employees)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Avalable Employees....");
            Console.ResetColor();

            foreach (Employee Employee in employees)
            {
                Console.WriteLine(Employee.ToString());
            }
        }

    }
}
