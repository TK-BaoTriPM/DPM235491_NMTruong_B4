using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceConstructorWithFactoryMethod_Before
{
    public class Employee
    {
        public const int ENGINEER = 0;
        public const int SALESMAN = 1;
        public const int MANAGER = 2;

        public int Type { get; set; }
        public double BaseSalary { get; set; }

        // CODE SMELL: Constructor nhận mã số loại nhân viên, thiếu tính rõ ràng và không tự mô tả
        public Employee(int type, double baseSalary)
        {
            Type = type;
            BaseSalary = baseSalary;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Constructor with Factory Method ===");

            // Caller phải nhớ truyền mã hằng số hợp lệ
            Employee eng = new Employee(Employee.ENGINEER, 2000.0);
            Employee mgr = new Employee(Employee.MANAGER, 3500.0);

            Console.WriteLine($"Nhan vien 1 (Loai {eng.Type}): Luong {eng.BaseSalary:N0} USD");
            Console.WriteLine($"Nhan vien 2 (Loai {mgr.Type}): Luong {mgr.BaseSalary:N0} USD");

            Console.ReadKey();
        }
    }
}