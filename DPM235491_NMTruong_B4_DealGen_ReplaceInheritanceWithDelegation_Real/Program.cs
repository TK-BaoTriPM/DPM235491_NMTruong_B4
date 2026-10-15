using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceInheritanceWithDelegation_Real
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    // Lớp xử lý tính toán chiết khấu hóa đơn
    public class DiscountCalculator
    {
        public double ApplyVIPDiscount(double amount)
        {
            return amount * 0.85; // Giảm 15% cho VIP
        }

        public double ApplyCoupon(double amount, string code)
        {
            if (code == "SALE10") return amount * 0.90;
            return amount;
        }
    }

    // REFACTORED: ShoppingCart không kế thừa DiscountCalculator mà chứa đối tượng ủy quyền
    public class ShoppingCart
    {
        private readonly List<Product> _items = new List<Product>();
        private readonly DiscountCalculator _discountCalculator = new DiscountCalculator();

        public void AddProduct(Product product)
        {
            _items.Add(product);
        }

        public double CalculateSubtotal()
        {
            double total = 0;
            foreach (var p in _items) total += p.Price;
            return total;
        }

        // Ủy quyền việc tính chiết khấu cho DiscountCalculator
        public double CalculateFinalTotalForVip(string couponCode)
        {
            double subtotal = CalculateSubtotal();
            double afterCoupon = _discountCalculator.ApplyCoupon(subtotal, couponCode);
            double finalPrice = _discountCalculator.ApplyVIPDiscount(afterCoupon);
            return finalPrice;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Replace Inheritance with Delegation trong Gio Hang ===");

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product("Tai nghe Bluetooth", 500000));
            cart.AddProduct(new Product("Chuot khong day Logi", 350000));

            double rawTotal = cart.CalculateSubtotal();
            double vipTotal = cart.CalculateFinalTotalForVip("SALE10");

            Console.WriteLine($"Tong tien hang: {rawTotal:N0} VND");
            Console.WriteLine($"Tien sau khi uy quyen tinh giam gia VIP & Voucher: {vipTotal:N0} VND");

            Console.ReadKey();
        }
    }
}