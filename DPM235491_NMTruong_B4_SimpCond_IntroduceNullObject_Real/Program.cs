using System;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceNullObject_Real
{
    public interface ICustomer
    {
        string GetDisplayName();
        double GetDiscountRate();
        void SendNotification(string message);
    }

    // Khách hàng đã đăng ký tài khoản
    public class RegisteredCustomer : ICustomer
    {
        public string FullName { get; set; }
        public double Discount { get; set; }

        public RegisteredCustomer(string fullName, double discount)
        {
            FullName = fullName;
            Discount = discount;
        }

        public string GetDisplayName() => FullName;
        public double GetDiscountRate() => Discount;
        public void SendNotification(string message)
        {
            Console.WriteLine($"[Email / SMS] Gui toi {FullName}: {message}");
        }
    }

    // Null Object: Đại diện cho Khách Vãng Lai (Guest User)
    public class GuestCustomer : ICustomer
    {
        public string GetDisplayName() => "Khach Vang Lai (Guest)";
        public double GetDiscountRate() => 0.0; // Khách vãng lai không có chiết khấu
        public void SendNotification(string message)
        {
            // Null Object: Do-nothing method (không làm gì để tránh lỗi null)
            Console.WriteLine("[Thong bao] Khach vang lai - Khong gui tin nhan qua email/SMS.");
        }
    }

    public class OrderContext
    {
        public ICustomer Customer { get; set; } = new GuestCustomer(); // Mặc định là Null Object
        public double OrderAmount { get; set; } = 1000000;

        public void Checkout()
        {
            Console.WriteLine($"--- THANH TOAN DON HANG ---");
            Console.WriteLine($"Nguoi mua: {Customer.GetDisplayName()}");

            double finalPrice = OrderAmount * (1 - Customer.GetDiscountRate());
            Console.WriteLine($"Tong tien: {finalPrice:N0} VND");

            Customer.SendNotification("Cảm ơn bạn đã mua hàng!");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Quan Ly Khach Vang Lai bang Null Object ===");

            // Case 1: Khách vãng lai mua hàng
            OrderContext order1 = new OrderContext();
            order1.Checkout();

            // Case 2: Khách hàng thân thiết mua hàng
            OrderContext order2 = new OrderContext
            {
                Customer = new RegisteredCustomer("Nguyen Minh Truong", 0.15) // Giảm 15%
            };
            order2.Checkout();

            Console.ReadKey();
        }
    }
}