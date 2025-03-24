using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeMangment.Program;

namespace EmployeeMangment
{
    internal class Employee
    {
        int Id;
        string Name;
        string Age;
        decimal Salary;
        Department Department;
        DateTime EmploymentDate;
        Statue statue;
        public Employee(string name, string age, decimal salary, Department department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
            EmploymentDate = DateTime.Now;
            statue = Statue.Active;
        }
        public void promoted(Employee employee, decimal newSalary)
        {
            employee.Salary = newSalary;
        }
        public void Transfer(Department department)
        {
            Department = department;
        }
        public void terminate()
        {
            statue = Statue.Terminated;
        }





    }
}
