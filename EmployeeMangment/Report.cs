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

        public static void TestReport()
        {
            Department department1 = new Department(name: "IT", departmentHead: "IT");
            Employee emp1 = new Employee(name: "Ahmed Ali", age: "22", salary: 3000, department1, 1);
            Employee emp2 = new Employee(name: "Mohamed Ali", age: "23", salary: 5000, department1, 2);
            Employee emp3 = new Employee(name: "Khalid Ali", age: "30", salary: 7000, department1, 3);
            Employee emp4 = new Employee(name: "Ali Ali", age: "33", salary: 9000, department1, 4);

            emp1.promoted(3500);
            emp1.promoted(4000);
            emp1.promoted(5000);
            emp2.promoted(6000);

            department1.AddEmployee([emp1, emp2, emp3, emp4]);
            Report.ListDepartmentEmployees([department1]);
            Report.SalaryDistribution([department1]);
            Report.TopPerformanceEmployees([department1]);
        }

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

        public static void TopPerformanceEmployees(List<Department> departments)
        {
            List<Employee> employees = getDepartmentEmployees(departments);
            var topPerformers = employees
                .OrderByDescending(emp => emp.Score)
                .Take(5); // Get the top 5 employees
            Console.WriteLine("==========================");
            Console.WriteLine("Top Performance Employees");
            foreach (var emp in topPerformers)
            {
                Console.WriteLine($"\nName: {emp.Name}, Score: {emp.Score}");
            }

        }

       

        public static void SalaryDistribution(List<Department> departments)
        {
            List<Employee> employees = getDepartmentEmployees(departments);
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
