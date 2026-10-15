using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ParameterizeMethod_After
{
    public class Employee
    {
        public double Salary { get; set; } = 1000.0;

        // REFACTORED: Gộp thành một phương thức duy nhất nhận tham số 'factor' (hệ số tăng)
        public void Raise(double factor)
        {
            Salary *= (1.0 + factor);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Parameterize Method ===");

            Employee emp = new Employee();
            Console.WriteLine($"Luong ban dau: {emp.Salary:N0} USD");

            // Gọi hàm với các tham số linh hoạt khác nhau
            emp.Raise(0.10); // Tăng 10%
            Console.WriteLine($"Luong sau khi tang 10%: {emp.Salary:N0} USD");

            emp.Raise(0.05); // Tăng thêm 5%
            Console.WriteLine($"Luong sau khi tang them 5%: {emp.Salary:N0} USD");

            Console.ReadKey();
        }
    }
}