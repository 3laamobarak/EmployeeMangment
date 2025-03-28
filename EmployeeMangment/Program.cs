namespace EmployeeMangment
{
    public class Program
    {
        public static Company company = new Company("Company 1", "Generic Company for jobs");
        public static List<Department> departments = new List<Department>();
        public static List<Employee> employees = new List<Employee>();
        public static int currentDepartmentIndex = 0;
        public static int currentEmployeeIndex = 0;

    
        static void Main(string[] args)
        {
            SampleData.LoadSampleData();
            RunProgram();
        }


        public static void RunProgram()
        {
            RunDepartments();
        }

       public static void RunDepartments()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================================");
            Console.WriteLine(company.ToString());
            Console.WriteLine("====================================");
            Console.ResetColor();
            DepartmentOperation operation = Menu.DepartmentListMenu();
            while(operation != DepartmentOperation.Exit)
            {
                switch (operation)
                {
                    // department
                    case DepartmentOperation.CreateDepartment:
                        Department.CreateDepartment();
                        break;
                    case DepartmentOperation.DeleteDepartment:
                        Department.DeleteDepartment();
                        break;
                    case DepartmentOperation.EditDepartment:
                        Department.EditDepartment();
                        break;
                    case DepartmentOperation.ListDepartments:
                        Department.ListDepartments();
                        break;
                    case DepartmentOperation.UseDepartment:
                        Department.ListDepartmentsToChoose();
                        string input = Console.ReadLine();
                        int index = 0;
                        if (int.TryParse(input, out index) && index < departments.Count)
                        {
                            RunEmployees(departments[index]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        break;
                    case DepartmentOperation.EmployeMenu:
                        RunEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
                operation = Menu.DepartmentListMenu();
            }
        }

        public static void RunEmployees(Department department = null)
        {
            EmployeeOperation operation = Menu.EmployeeListMenu(department);
            while(operation != EmployeeOperation.Exit)
            {
                switch (operation)
                {
                    // Employees
                    case EmployeeOperation.CreateEmployee:
                        Employee.CreateEmployee();
                        break;
                    case EmployeeOperation.DeleteEmployee:
                        Employee.DeleteEmployee();
                        break;
                    case EmployeeOperation.EditEmployee:
                        Employee.EditEmployee();
                        break;
                    case EmployeeOperation.ListEmployee:
                        Employee.ListEmployees(department);
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
