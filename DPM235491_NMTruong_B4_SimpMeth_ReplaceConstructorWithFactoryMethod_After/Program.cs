using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceConstructorWithFactoryMethod_After
{
    public class Employee
    {
        public const int ENGINEER = 0;
        public const int SALESMAN = 1;
        public const int MANAGER = 2;

        public int Type { get; private set; }
        public double BaseSalary { get; private set; }

        // REFACTORED: Chuyển constructor về private để ngăn chặn khởi tạo trực tiếp
        private Employee(int type, double baseSalary)
        {
            Type = type;
            BaseSalary = baseSalary;
        }

        // REFACTORED: Cung cấp các Static Factory Methods với tên gọi diễn tả rõ mục đích
        public static Employee CreateEngineer(double baseSalary)
        {
            return new Employee(ENGINEER, baseSalary);
        }

        public static Employee CreateSalesman(double baseSalary)
        {
            return new Employee(SALESMAN, baseSalary);
        }

        public static Employee CreateManager(double baseSalary)
        {
            return new Employee(MANAGER, baseSalary);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Constructor with Factory Method ===");

            // Gọi các Factory Method tường minh, mã nguồn trong sạch và tự giải thích
            Employee eng = Employee.CreateEngineer(2000.0);
            Employee mgr = Employee.CreateManager(3500.0);

            Console.WriteLine($"Ky su: Luong {eng.BaseSalary:N0} USD");
            Console.WriteLine($"Quan ly: Luong {mgr.BaseSalary:N0} USD");

            Console.ReadKey();
        }
    }
}