using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpConstructorBody_Before
{
    public class Employee
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Manager : Employee
    {
        public int Grade { get; set; }

        // CODE SMELL: Thân constructor tự gán Name và Id trùng lặp
        public Manager(string name, string id, int grade)
        {
            Name = name;
            Id = id;
            Grade = grade;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Pull Up Constructor Body ===");

            Manager mgr = new Manager("Nguyen Minh Truong", "EMP-001", 2);
            Console.WriteLine($"Quan ly: {mgr.Name} | ID: {mgr.Id} | Cấp: {mgr.Grade}");

            Console.ReadKey();
        }
    }
}