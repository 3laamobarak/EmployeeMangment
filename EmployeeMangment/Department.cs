﻿using System;
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

    }
}
