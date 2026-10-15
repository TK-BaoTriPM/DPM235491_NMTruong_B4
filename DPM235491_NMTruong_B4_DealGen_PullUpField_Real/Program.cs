using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpField_Real
{
    // REFACTORED: Lớp cơ sở dùng chung cho tất cả Entity trong cơ sở dữ liệu
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected BaseEntity(string id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }

    // Thực thể Sản Phẩm kế thừa các trường ID và Ngày Tạo từ BaseEntity
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }

        public Product(string id, string productName, double unitPrice) : base(id)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
        }
    }

    // Thực thể Khách Hàng kế thừa các trường ID và Ngày Tạo từ BaseEntity
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public Customer(string id, string fullName, string email) : base(id)
        {
            FullName = fullName;
            Email = email;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Pull Up Field cho Lớp Co So BaseEntity ===");

            Product p = new Product("PROD-001", "Laptop Dell XPS 15", 45000000);
            Customer c = new Customer("CUST-101", "Nguyen Minh Truong", "truong@example.com");

            Console.WriteLine($"[SAN PHAM] ID: {p.Id} | Ten: {p.ProductName} | Ngay tao: {p.CreatedAt:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"[KHACH HANG] ID: {c.Id} | Ten: {c.FullName} | Ngay tao: {c.CreatedAt:dd/MM/yyyy HH:mm:ss}");

            Console.ReadKey();
        }
    }
}