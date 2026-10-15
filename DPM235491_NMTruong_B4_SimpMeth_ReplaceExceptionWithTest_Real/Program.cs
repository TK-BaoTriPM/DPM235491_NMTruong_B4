using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceExceptionWithTest_Real
{
    public class ShoppingCart
    {
        private Dictionary<string, int> _items = new Dictionary<string, int>();

        public void AddItem(string productId, int quantity)
        {
            _items[productId] = quantity;
        }

        // BEFORE (Dùng Exception): Bắt KeyNotFoundException khi tìm sản phẩm
        // REFACTORED (Dùng Test): Dùng ContainsKey hoặc TryGetValue để kiểm tra điều kiện trước
        public int GetQuantity(string productId)
        {
            // Kiểm tra trước sự tồn tại của khóa thay vì để ném Exception
            if (_items.TryGetValue(productId, out int quantity))
            {
                return quantity;
            }

            return 0; // Trả về 0 nếu sản phẩm chưa có trong giỏ
        }

        public double ApplyDiscount(string couponCode)
        {
            // Kiểm tra mã rỗng hoặc null bằng string.IsNullOrWhiteSpace thay vì try-catch NullReference
            if (string.IsNullOrWhiteSpace(couponCode))
            {
                return 0.0;
            }

            if (couponCode.Equals("SALE10", StringComparison.OrdinalIgnoreCase))
            {
                return 0.10; // Giảm 10%
            }

            return 0.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Tieu Chuan Hoa Kiem Tra Gio Hang bang Replace Exception with Test ===");

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem("SP-LAPTOP-01", 2);

            string searchProduct = "SP-MOUSE-02"; // Chưa có trong giỏ
            int qty = cart.GetQuantity(searchProduct);
            Console.WriteLine($"So luong san pham '{searchProduct}' trong gio: {qty}");

            string nullCoupon = null;
            double discount = cart.ApplyDiscount(nullCoupon);
            Console.WriteLine($"Tỷ le giam gia tu voucher: {discount * 100}%");

            Console.ReadKey();
        }
    }
}