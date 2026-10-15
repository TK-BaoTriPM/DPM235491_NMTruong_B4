using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpConstructorBody_After
{
    public class Employee
    {
        public string Name { get; set; }
        public string Id { get; set; }

        // REFACTORED: Tạo constructor ở lớp cha để xử lý các thuộc tính chung
        public Employee(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }

    public class Manager : Employee
    {
        public int Grade { get; set; }

        // REFACTORED: Đẩy phần khởi tạo Name và Id lên constructor của Employee qua 'base'
        public Manager(string name, string id, int grade) : base(name, id)
        {
            Grade = grade;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Pull Up Constructor Body ===");

            Manager mgr = new Manager("Nguyen Minh Truong", "EMP-001", 2);
            Console.WriteLine($"Quan ly: {mgr.Name} | ID: {mgr.Id} | Cấp: {mgr.Grade}");

            Console.ReadKey();
        }
    }
}