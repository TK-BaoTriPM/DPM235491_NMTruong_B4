using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveParameter_Real
{
    public class Order
    {
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; } = "Pending";

        // BEFORE: public void ProcessPayment(double amount, string paymentMethod, string unusedUserAgent)
        // REFACTORED: Loại bỏ 'unusedUserAgent' vì hệ thống thanh toán đã ghi log tự động ở tầng Middleware
        public bool ProcessPayment(string paymentMethod)
        {
            Console.WriteLine($"[Thanh Toan] Dang xu ly don hang {OrderId} voi so tien {Amount:N0} VND qua {paymentMethod}...");

            Status = "Paid";
            Console.WriteLine($"[Thanh Toan] Don hang {OrderId} da thanh toan THANH CONG.");
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Thanh Toan Don Hang voi Remove Parameter ===");

            Order order = new Order
            {
                OrderId = "DH-99823",
                Amount = 1250000
            };

            // Gọi hàm thanh toán ngắn gọn mà không cần truyền tham số chuỗi UserAgent thừa
            order.ProcessPayment("MOMO");

            Console.ReadKey();
        }
    }
}