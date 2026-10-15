using System;

namespace DPM235491_NMTruong_B4_DealGen_CollapseHierarchy_After
{
    // REFACTORED: Gộp NonSalesEmployee vào trực tiếp lớp Employee
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[EMPLOYEE] Ten: {Name} | Luong: {Salary:N0} USD");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Collapse Hierarchy ===");

            // Khởi tạo trực tiếp đối tượng Employee mà không qua lớp con rỗng
            Employee emp = new Employee("Nguyen Minh Truong", 3000.0);
            emp.DisplayInfo();

            Console.ReadKey();
        }
    }
}