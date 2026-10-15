using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceNestedCond_Real
{
    public class OrderValidationService
    {
        // Kiểm tra tính hợp lệ của đơn hàng trước khi cho phép thanh toán
        public string ProcessOrder(bool isCartEmpty, bool isUserBlocked, bool isStockAvailable, double paymentAmount)
        {
            // Guard Clause 1: Giỏ hàng rỗng
            if (isCartEmpty)
            {
                return "[LOI] Gio hang cua ban dang rong!";
            }

            // Guard Clause 2: Tài khoản bị khóa
            if (isUserBlocked)
            {
                return "[LOI] Tai khoan cua ban da bi khoa chuc nang dat hang!";
            }

            // Guard Clause 3: Khổng đủ hàng trong kho
            if (!isStockAvailable)
            {
                return "[LOI] San pham trong gio hang da het hang!";
            }

            // Guard Clause 4: Số tiền thanh toán không hợp lệ
            if (paymentAmount <= 0)
            {
                return "[LOI] So tien thanh toan phai lon hon 0 VND!";
            }

            // Luồng chính: Đơn hàng hợp lệ và được tiến hành checkout
            return $"[THANH CONG] Don hang da duoc khoi tao voi so tien {paymentAmount:N0} VND.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Kiem Tra Don Hang bang Guard Clauses ===");

            OrderValidationService service = new OrderValidationService();

            // Test case 1: Tài khoản bị khóa
            string res1 = service.ProcessOrder(isCartEmpty: false, isUserBlocked: true, isStockAvailable: true, paymentAmount: 500000);
            Console.WriteLine($"Ket qua 1: {res1}");

            // Test case 2: Đơn hàng hợp lệ
            string res2 = service.ProcessOrder(isCartEmpty: false, isUserBlocked: false, isStockAvailable: true, paymentAmount: 750000);
            Console.WriteLine($"Ket qua 2: {res2}");

            Console.ReadKey();
        }
    }
}