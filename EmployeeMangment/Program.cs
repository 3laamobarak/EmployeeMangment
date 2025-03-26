namespace EmployeeMangment
{
    internal class Program
    {
        public enum Statue
        {
            Active,
            Terminated
        }
        static void Main(string[] args)
        {
            RunProgram();
        }


        public static void RunProgram()
        {
           List<Company> companies = new List<Company>();
            while (true)
            {
                CompanyOperation oper = Menu.CompanyListMenu();
                switch (oper)
                {
                    case CompanyOperation.CreateCompany:
                        Company.CreateCompany(companies);
                        break;
                    case CompanyOperation.DeleteCompany:
                        Company.DeleteCompany(companies);
                        break;
                    case CompanyOperation.EditCompany:
                        Company.CreateCompany(companies);
                        break;
                    case CompanyOperation.ListCompanies:
                        Company.ListCompanies(companies);
                        break;
                    case CompanyOperation.UseCompany:
                        Company.ListCompaniesToChoose(companies);
                        string input = Console.ReadLine();
                        int index = 0;
                        if (int.TryParse(input, out index) && index < companies.Count)
                        {
                            RunDepartments(companies[index]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        break;
                    case CompanyOperation.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
            }
        }

       public static void RunDepartments(Company company)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(company.ToString());
            Console.ResetColor();
            DepartmentOperation operation = Menu.DepartmentListMenu(company);
            while(operation != DepartmentOperation.Exit)
            {
                switch (operation)
                {
                    // department
                    case DepartmentOperation.CreateDepartment:
                        Department.CreateDepartment(company.Departments);
                        break;
                    case DepartmentOperation.DeleteDepartment:
                        Department.DeleteDepartment(company.Departments);
                        break;
                    case DepartmentOperation.EditDepartment:
                        Department.CreateDepartment(company.Departments);
                        break;
                    case DepartmentOperation.ListDepartments:
                        Department.ListDepartments(company.Departments);
                        break;
                    case DepartmentOperation.UseDepartment:
                        Department.ListDepartmentsToChoose(company.Departments);
                        string input = Console.ReadLine();
                        int index = 0;
                        if (int.TryParse(input, out index) && index < company.Departments.Count)
                        {
                            RunEmployees(company.Departments[index]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
                operation = Menu.DepartmentListMenu(company);
            }
        }

        public static void RunEmployees(Department department, Department newDepartment = null)
        {
            if (newDepartment == null)
            {
                newDepartment = department;
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(department.ToString());
            Console.ResetColor();
            EmployeeOperation operation = Menu.EmployeeListMenu(department);
            while(operation != EmployeeOperation.Exit)
            {
                switch (operation)
                {
                    // Employees
                    case EmployeeOperation.CreateEmployee:
                        Employee.CreateEmployee(department.employees, department);
                        break;
                    case EmployeeOperation.DeleteEmployee:
                        Employee.DeleteEmployee(department.employees);
                        break;
                    case EmployeeOperation.EditEmployee:
                        Employee.EditEmployee(department.employees, newDepartment);
                        break;
                    case EmployeeOperation.ListEmployee:
                        Employee.ListEmployees(department.employees);
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
                operation = Menu.EmployeeListMenu(department);
            }
        }

    }
}
