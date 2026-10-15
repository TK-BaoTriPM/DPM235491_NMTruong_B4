using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownField_Real
{
    // Lớp cha đại diện cho hàng hóa chung trong kho
    public abstract class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        protected Product(string productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"[SAN PHAM] Ma: {ProductId} | Ten: {ProductName} | Gia: {Price:N0} VND");
        }
    }

    // Sản phẩm Điện tử (không có Hạn sử dụng)
    public class ElectronicProduct : Product
    {
        public int WarrantyMonths { get; set; }

        public ElectronicProduct(string productId, string productName, double price, int warrantyMonths)
            : base(productId, productName, price)
        {
            WarrantyMonths = warrantyMonths;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"-> Bao hanh: {WarrantyMonths} thang");
        }
    }

    // Sản phẩm Thực phẩm tươi sống (Cần quản lý Hạn sử dụng)
    public class FoodProduct : Product
    {
        // REFACTORED: Đẩy trường ExpirationDate xuống FoodProduct 
        // vì các sản phẩm như Laptop/Điện thoại không có hạn sử dụng
        public DateTime ExpirationDate { get; set; }

        public FoodProduct(string productId, string productName, double price, DateTime expirationDate)
            : base(productId, productName, price)
        {
            ExpirationDate = expirationDate;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"-> Han su dung: {ExpirationDate:dd/MM/yyyy}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Push Down Field trong Quan Ly San Pham ===");

            ElectronicProduct laptop = new ElectronicProduct("LAP-001", "Laptop ASUS ROG", 28000000, 24);
            FoodProduct milk = new FoodProduct("FOOD-101", "Sua Tuoi Tiet Trung", 35000, DateTime.Now.AddDays(30));

            laptop.DisplayDetails();
            Console.WriteLine();
            milk.DisplayDetails();

            Console.ReadKey();
        }
    }
}