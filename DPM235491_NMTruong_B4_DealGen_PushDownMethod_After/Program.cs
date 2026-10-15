using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownMethod_After
{
    public abstract class Employee
    {
        public string Name { get; set; }
        // REFACTORED: Đã loại bỏ GetSalesQuota() khỏi lớp cha
    }

    public class Engineer : Employee
    {
        // Chỉ chứa logic và phương thức liên quan đến Kỹ sư
    }

    public class Salesman : Employee
    {
        // REFACTORED: Chuyển GetSalesQuota() xuống đúng lớp con Salesman
        public double GetSalesQuota()
        {
            return 50000.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Push Down Method ===");

            Salesman sales = new Salesman { Name = "Le Van A" };
            Engineer eng = new Engineer { Name = "Nguyen Minh Truong" };

            Console.WriteLine($"Chi tieu cua {sales.Name}: {sales.GetSalesQuota():N0} USD");

            // eng.GetSalesQuota(); // LỖI BIÊN DỊCH: Engineer không còn chứa hàm này nữa!

            Console.ReadKey();
        }
    }
}