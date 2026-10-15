using System;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceDelegationWithInheritance_Before
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

    // CODE SMELL: Employee giữ đối tượng Person và viết vô số hàm ủy quyền
    // dù bản chất Employee CHÍNH LÀ một Person.
    public class Employee
    {
        private readonly Person _person = new Person();

        public string Name
        {
            get => _person.Name;
            set => _person.Name = value;
        }

        // Phương thức ủy quyền rườm rà (Delegating Method)
        public string GetLastName()
        {
            return _person.GetLastName();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Delegation with Inheritance ===");

            Employee emp = new Employee();
            emp.Name = "Nguyen Minh Truong";

            Console.WriteLine($"Nhan vien: {emp.Name}");
            Console.WriteLine($"Ten (Last Name): {emp.GetLastName()}");

            Console.ReadKey();
        }
    }
}