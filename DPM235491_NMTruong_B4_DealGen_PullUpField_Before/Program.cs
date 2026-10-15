using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpField_Before
{
    public abstract class Employee
    {
        // Lớp cha rỗng, chưa chứa thuộc tính chung
    }

    public class Engineer : Employee
    {
        // CODE SMELL: Trường Name bị trùng lặp ở lớp con Engineer
        public string Name { get; set; }
    }

    public class Salesman : Employee
    {
        // CODE SMELL: Trường Name tiếp tục bị lặp lại ở lớp con Salesman
        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Pull Up Field ===");

            Engineer eng = new Engineer { Name = "Nguyen Minh Truong" };
            Salesman sales = new Salesman { Name = "Le Van A" };

            Console.WriteLine($"Ky su: {eng.Name}");
            Console.WriteLine($"Nhan vien ban hang: {sales.Name}");

            Console.ReadKey();
        }
    }
}