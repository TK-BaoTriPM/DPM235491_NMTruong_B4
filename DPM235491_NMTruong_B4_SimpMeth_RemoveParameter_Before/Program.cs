using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveParameter_Before
{
    public class Customer
    {
        public string Name { get; set; }

        // CODE SMELL: Tham số 'dateOfBirth' được truyền vào nhưng không hề được sử dụng trong hàm
        public void DisplayContactInfo(string phone, DateTime dateOfBirth)
        {
            Console.WriteLine($"Khach hang: {Name}");
            Console.WriteLine($"So dien thoai: {phone}");
            // dateOfBirth bi bo quen, khong dung den
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Remove Parameter ===");

            Customer customer = new Customer { Name = "Nguyen Minh Truong" };

            // Người gọi bắt buộc phải truyền thêm DateTime không dùng tới
            customer.DisplayContactInfo("0296.3852111", new DateTime(2003, 5, 20));

            Console.ReadKey();
        }
    }
}