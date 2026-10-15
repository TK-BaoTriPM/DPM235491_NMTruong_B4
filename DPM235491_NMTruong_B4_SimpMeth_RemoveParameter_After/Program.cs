using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveParameter_After
{
    public class Customer
    {
        public string Name { get; set; }

        // REFACTORED: Loại bỏ tham số dư thừa 'dateOfBirth'
        public void DisplayContactInfo(string phone)
        {
            Console.WriteLine($"Khach hang: {Name}");
            Console.WriteLine($"So dien thoai: {phone}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Remove Parameter ===");

            Customer customer = new Customer { Name = "Nguyen Minh Truong" };

            // Lời gọi hàm gọn gàng, đúng trọng tâm
            customer.DisplayContactInfo("0296.3852111");

            Console.ReadKey();
        }
    }
}