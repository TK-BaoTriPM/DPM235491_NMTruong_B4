using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSuperclass_Real
{
    // REFACTORED: Lớp cha BaseProduct định nghĩa giao diện chung cho mọi mặt hàng bán trên e-commerce
    public abstract class BaseProduct
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        protected BaseProduct(string productId, string name, double price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public abstract double CalculateFinalPrice();

        public virtual void DisplaySummary()
        {
            Console.WriteLine($"[{ProductId}] {Name} - Gia niem yet: {Price:N0} VND | Gia ban: {CalculateFinalPrice():N0} VND");
        }
    }

    // Sản phẩm vật lý (Cần tính phí vận chuyển)
    public class PhysicalProduct : BaseProduct
    {
        public double WeightKg { get; set; }

        public PhysicalProduct(string productId, string name, double price, double weightKg)
            : base(productId, name, price)
        {
            WeightKg = weightKg;
        }

        public override double CalculateFinalPrice()
        {
            double shippingFee = WeightKg * 15000; // 15k/kg
            return Price + shippingFee;
        }
    }

    // Sản phẩm số (Khóa học/Phần mềm - Không tốn ship, hỗ trợ mã giảm giá 10%)
    public class DigitalProduct : BaseProduct
    {
        public string DownloadUrl { get; set; }

        public DigitalProduct(string productId, string name, double price, string downloadUrl)
            : base(productId, name, price)
        {
            DownloadUrl = downloadUrl;
        }

        public override double CalculateFinalPrice()
        {
            return Price * 0.90; // Giảm 10% chi phí phân phối số
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Extract Superclass BaseProduct cho San Pham E-Commerce ===");

            // Nhờ có Superclass BaseProduct, ta có thể quản lý đa hình trong cùng 1 List
            List<BaseProduct> cart = new List<BaseProduct>
            {
                new PhysicalProduct("PHYS-01", "Ban phim Co Akko", 1200000, 1.2),
                new DigitalProduct("DIGI-99", "Ebook C# Refactoring Guru", 200000, "https://store.com/dl/refactoring-pdf")
            };

            double cartTotal = 0;
            foreach (var item in cart)
            {
                item.DisplaySummary();
                cartTotal += item.CalculateFinalPrice();
            }

            Console.WriteLine($"\n-> TONG CONG GIA TRI GIO HANG: {cartTotal:N0} VND");

            Console.ReadKey();
        }
    }
}