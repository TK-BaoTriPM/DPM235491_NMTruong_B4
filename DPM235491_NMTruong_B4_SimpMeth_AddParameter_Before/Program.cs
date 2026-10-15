using System;

namespace DPM235491_NMTruong_B4_SimpMeth_AddParameter_Before
{
    public class Customer
    {
        public string Name { get; set; }

        // CODE SMELL: Hàm tính hóa đơn chỉ dùng giá mặc định, không tính được ngày khuyến mãi hoặc hệ số
        public double GetContactBill()
        {
            double baseRate = 100.0;
            return baseRate;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Add Parameter ===");

            Customer customer = new Customer { Name = "Nguyen Minh Truong" };
            Console.WriteLine($"Hoa don cua {customer.Name}: {customer.GetContactBill():N0} USD");

            Console.ReadKey();
        }
    }
}