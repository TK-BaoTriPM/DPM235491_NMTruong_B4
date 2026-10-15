using System;

namespace DPM235491_NMTruong_B4_DealGen_CollapseHierarchy_Before
{
    // Lớp cha
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[EMPLOYEE] Ten: {Name} | Luong: {Salary:N0} USD");
        }
    }

    // CODE SMELL: Lớp con NonSalesEmployee rỗng, hoàn toàn không có thêm thuộc tính hay hành vi khác biệt so với lớp cha
    public class NonSalesEmployee : Employee
    {
        public NonSalesEmployee(string name, double salary) : base(name, salary)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Collapse Hierarchy ===");

            NonSalesEmployee emp = new NonSalesEmployee("Nguyen Minh Truong", 3000.0);
            emp.DisplayInfo();

            Console.ReadKey();
        }
    }
}