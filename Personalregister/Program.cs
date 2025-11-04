
using System;
using System.Text.Json.Serialization;
using System.Xml;

namespace Personalregister
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = true;
            try
            {
               
                do
                {
                Console.Clear();
                Console.WriteLine("1 - Lägg till en anställd");
                Console.WriteLine("2 - Visa anställda");
                Console.WriteLine("0 - utgång");
                Console.WriteLine("Vänligen gör ett val:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Ange Namn :");
                            string namn = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(namn))
                            {
                                Console.WriteLine("Fel: Namn får inte vara tomt.");
                                Console.WriteLine("Ange Namn :");
                                namn = Console.ReadLine();
                            }

                            int lon;
                            while (true)
                            {
                                Console.Write("Ange lön: ");
                                if (int.TryParse(Console.ReadLine(), out lon))
                                    break; 
                                Console.WriteLine("Fel: Ogiltig lön, försök igen!");
                            }
                            EmployeeManager.AddEmployee(namn, lon);
                        }
                        break;
                    case "2":
                        {

                            EmployeeManager.ShowEmployees();
                        }
                        break;
                    case "0": 
                        { 
                            exit = false;
                        } 
                        break;
                    default:
                        break;
                }
            } while (exit);
         
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }
    }
    internal static class EmployeeStorage
    {
        private static List<Employee> employees = new List<Employee>();
        internal static void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        internal static List<Employee> GetEmployees()
        {
            return employees;
        }
        internal static void Showloyees()
        {


            foreach (var emp in employees)

            {
                
                Console.WriteLine("Namn: " + emp.getName() + "\t Lön: " + emp.getSalary());
            }
        }
    }
    internal class Employee
    {   
        private string Name { get; set; }
        private int Salary { get; set; }

        public bool setEmployee( String name, int salary) { 
            this.Name = name;
            this.Salary = salary;
            return true;
        }
        public string getName() {
            return this.Name;
        }
        public int getSalary() {
            return this.Salary;
        }
    }
    internal static class EmployeeManager
    {
        
        internal static void AddEmployee( string name, int salary)
        {
            Employee employee = new Employee();
            if (employee.setEmployee( name, salary))
            {
                EmployeeStorage.AddEmployee(employee);
                Console.WriteLine("Anställd " + name + " lades till!");
                Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                Console.ReadKey();
            }
        }
        internal static void ShowEmployees()
        {
            EmployeeStorage.Showloyees();
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
