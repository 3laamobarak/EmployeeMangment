using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
