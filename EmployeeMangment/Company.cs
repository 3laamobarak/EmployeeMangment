using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment
{
   
    
    public class Company
    {
        int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public Company(string name, string description) {
            ID = GetHashCode();
            Name = name;
            Description = description;
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddDepartment(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                AddDepartment(department);
            }
        }


        public void ListDepartments()
        {
            foreach (Department department in Departments)
            {
                AddDepartment(department);
            }
        }

        public override string ToString()
        {
            return $"id: {ID}, Name: {Name}, Description: {Description}, Number of Department: ({Departments.Count})";
        }

        public static string GetCompanyInput()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter Company like this (name, desciption) - q to exit");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static  void CreateCompany(List<Company> companies)
        {
            string input = GetCompanyInput();
            while (input!= null && input.Trim() != "q")
            {
                var items = input.Trim().Split(",");
                if (items.Length != 0 || items.Length == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Company Created Successfully");
                    Console.ResetColor();
                    companies.Add(new Company(items[0], items[1]));
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                input = Console.ReadLine();
            }
        }

        public static void EditCompany(List<Company> companies)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Editing Company, choose number to edit...");
            Console.ResetColor();
            int index = 0;
            foreach (Company company in companies)
            {
                Console.WriteLine($"{index++} - {company.Name}");
            }
            string companyNumber = Console.ReadLine();

            if (int.TryParse(companyNumber, out index) && index < companies.Count)
            {
                string input = GetCompanyInput();
                var items = input.Trim().Split(",");
                if (items.Length != 0 || items.Length == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Company Updated Successfully");
                    Console.ResetColor();
                    companies[index].Name = items[0];
                    companies[index].Description = items[1];
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

        public static void ListCompaniesToChoose(List<Company> companies)
        {
            int index = 0;
            foreach (Company company in companies)
            {
                Console.WriteLine($"{index++} - {company.Name}");
            }
        }

        public static void DeleteCompany(List<Company> companies)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Deleting Company, choose number to delete...");
            Console.ResetColor();
            ListCompaniesToChoose(companies);
            int index = 0;
            string companyNumber = Console.ReadLine();
            while (companyNumber != null && companyNumber != "q" && companies.Count > 0)
            {
                if (int.TryParse(companyNumber, out index) && index < companies.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Company {companies[index].Name} Deleted Successfully");
                    Console.ResetColor();
                    companies.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                companyNumber = Console.ReadLine();
            }
        }

        public static void ListCompanies(List<Company> companies)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Avalable Companies....");
            Console.ResetColor();

            foreach (Company company in companies)
            {
                Console.WriteLine(company.ToString());
            }
        }
    }
}
