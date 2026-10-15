using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSuperclass_Before
{
    // Lớp Employee độc lập
    public class Employee
    {
        public string Name { get; set; } // CODE SMELL: Trùng Name với Department
        public int Id { get; set; }
        public double AnnualCost { get; set; } // CODE SMELL: Trùng AnnualCost với Department

        public Employee(string name, int id, double annualCost)
        {
            Name = name;
            Id = id;
            AnnualCost = annualCost;
        }
    }

    // Lớp Department độc lập
    public class Department
    {
        public string Name { get; set; } // CODE SMELL: Trùng Name với Employee
        public double AnnualCost { get; set; } // CODE SMELL: Trùng AnnualCost với Employee
        public int StaffCount { get; set; }

        public Department(string name, double annualCost, int staffCount)
        {
            Name = name;
            AnnualCost = annualCost;
            StaffCount = staffCount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Extract Superclass ===");

            Employee emp = new Employee("Nguyen Minh Truong", 101, 15000.0);
            Department dept = new Department("Phong CNTT", 120000.0, 8);

            Console.WriteLine($"Nhan vien: {emp.Name} | Chi phi nam: {emp.AnnualCost:N0} USD");
            Console.WriteLine($"Phong ban: {dept.Name} | Chi phi nam: {dept.AnnualCost:N0} USD");

            Console.ReadKey();
        }
    }
}