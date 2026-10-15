using System;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceDelegationWithInheritance_After
{
    public class Person
    {
        public string Name { get; set; }

        public string GetLastName()
        {
            if (string.IsNullOrWhiteSpace(Name)) return "";
            string[] parts = Name.Split(' ');
            return parts[parts.Length - 1];
        }
    }

    // REFACTORED: Cho Employee kế thừa trực tiếp từ Person
    public class Employee : Person
    {
        // Loại bỏ hoàn toàn trường _person và các phương thức ủy quyền thừa
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Delegation with Inheritance ===");

            Employee emp = new Employee { Name = "Nguyen Minh Truong" };

            // Thừa hưởng trực tiếp Name và GetLastName() từ Person
            Console.WriteLine($"Nhan vien: {emp.Name}");
            Console.WriteLine($"Ten (Last Name): {emp.GetLastName()}");

            Console.ReadKey();
        }
    }
}