using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ParameterizeMethod_Before
{
    public class Employee
    {
        public double Salary { get; set; } = 1000.0;

        // CODE SMELL: Các phương thức trùng lặp logic, chỉ khác hệ số phần trăm tăng
        public void TenPercentRaise()
        {
            Salary *= 1.10;
        }

        public void FivePercentRaise()
        {
            Salary *= 1.05;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Parameterize Method ===");

            Employee emp = new Employee();
            Console.WriteLine($"Luong ban dau: {emp.Salary:N0} USD");

            emp.TenPercentRaise();
            Console.WriteLine($"Luong sau khi tang 10%: {emp.Salary:N0} USD");

            Console.ReadKey();
        }
    }
}