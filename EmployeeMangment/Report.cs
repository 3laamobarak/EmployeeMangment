using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment
{
    public class Report
    {

        public Report() { }
        public static void ListDepartmentEmployees(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                Console.WriteLine("============================");
                Console.WriteLine($"Department ({department.Name}) Employees: ");
                int index = 1;
                foreach (Employee employee in department.employees)
                {
                    Console.WriteLine($"{index++} - {employee.ToString()}");
                }
                Console.WriteLine("============================");
            }
        }

        public static List<Employee> getDepartmentEmployees(List<Department> departments)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Department department in departments)
            {
                foreach (Employee employee in department.employees)
                {
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public static void TopPerformanceEmployees()
        {
            var topPerformers = Program.employees
                .OrderByDescending(emp => emp.Score)
                .Take(5); // Get the top 5 employees
            Console.WriteLine("==========================");
            Console.WriteLine("Top Performance Employees");
            foreach (var emp in topPerformers)
            {
                Console.WriteLine($"\nName: {emp.Name}, Score: {emp.Score}");
            }

        }

        public static void SalaryDistribution()
        {
            List<Employee> employees = getDepartmentEmployees(Program.departments);
            var salaryData = employees
                .GroupBy(emp => emp.Salary <= 5000 ? "0-5000" :
                                emp.Salary <= 10000 ? "5001-10000" : "10001+")
                .Select(group => new { Range = group.Key, Count = group.Count() });
            Console.WriteLine("===============================");
            Console.WriteLine($"Salary Distribution:");
            foreach (var data in salaryData)
            {
                Console.WriteLine($"\t{data.Range}: {data.Count} employees");
            }

        }

    }
}
