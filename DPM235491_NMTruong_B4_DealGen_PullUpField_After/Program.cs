using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpField_After
{
    public abstract class Employee
    {
        // REFACTORED: Chuyển trường Name lên lớp cha Employee
        public string Name { get; set; }
    }

    public class Engineer : Employee
    {
        // Lớp con thừa hưởng trường Name từ Employee, không cần khai báo lại
    }

    public class Salesman : Employee
    {
        // Lớp con thừa hưởng trường Name từ Employee, không cần khai báo lại
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Pull Up Field ===");

            Engineer eng = new Engineer { Name = "Nguyen Minh Truong" };
            Salesman sales = new Salesman { Name = "Le Van A" };

            Console.WriteLine($"Ky su: {eng.Name}");
            Console.WriteLine($"Nhan vien ban hang: {sales.Name}");

            Console.ReadKey();
        }
    }
}