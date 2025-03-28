using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment
{
    class SampleData
    {
        public static void LoadSampleData()
        {
            LoadSampleDepartmentData();
            LoadSampleEmployeesData();
        }

        public static void LoadSampleDepartmentData()
        {
            string filePath = "departments.csv";

            using (StreamReader reader = new StreamReader(filePath))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    if(index != 0)
                    {
                        Program.departments.Add(new Department(values[1], values[2], int.Parse(values[0])));
                    }

                    // Process the values here
                    //Console.WriteLine(string.Join(" | ", values));
                    index++;
                }
            }

            //Department.ListDepartments();
        }

        public static void LoadSampleEmployeesData()
        {
            string filePath = "employees.csv";

            using (StreamReader reader = new StreamReader(filePath))
            {
                Department department;
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    if (index != 0)
                    {
                        department = Program.departments.FirstOrDefault(x => x.Id == int.Parse(values[4]));
                        Program.employees.Add(new Employee(name: values[1], age: values[2], 
                            salary:Convert.ToDecimal(values[3]), 
                            department: department, score: float.Parse(values[5]), 
                            id: int.Parse(values[0])));
                    }

                    // Process the values here
                    //Console.WriteLine(string.Join(" | ", values));
                    index++;
                }
            }

            //Employee.ListEmployees();
        }
       
    }
}
