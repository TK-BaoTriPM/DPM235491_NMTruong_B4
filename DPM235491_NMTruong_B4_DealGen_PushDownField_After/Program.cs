using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownField_After
{
    public abstract class Employee
    {
        public string Name { get; set; }
        // REFACTORED: Đã loại bỏ SalesQuota khỏi lớp cha Employee
    }

    public class Engineer : Employee
    {
        // Lớp Engineer không còn thuộc tính SalesQuota thừa
    }

    public class Salesman : Employee
    {
        // REFACTORED: Chuyển trường SalesQuota xuống đúng lớp con Salesman
        public double SalesQuota { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Push Down Field ===");

            Salesman sales = new Salesman { Name = "Le Van A", SalesQuota = 50000.0 };
            Engineer eng = new Engineer { Name = "Nguyen Minh Truong" };

            Console.WriteLine($"Salesman: {sales.Name} | Quota: {sales.SalesQuota:N0} USD");
            Console.WriteLine($"Engineer: {eng.Name}");

            // eng.SalesQuota = 100; // LỖI BIÊN DỊCH: Engineer không còn thuộc tính này nữa!

            Console.ReadKey();
        }
    }
}