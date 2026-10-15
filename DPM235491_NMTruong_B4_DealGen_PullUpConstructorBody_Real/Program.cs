using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpConstructorBody_Real
{
    // Lớp cơ sở đại diện cho các loại người dùng trong hệ thống bán hàng
    public abstract class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        // REFACTORED: Constructor lớp cha đảm nhận khởi tạo các thông tin tài khoản cơ bản
        protected User(string userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
            CreatedAt = DateTime.Now;
        }
    }

    // Lớp con: Khách hàng mua sắm
    public class CustomerUser : User
    {
        public string ShippingAddress { get; set; }
        public int LoyaltyPoints { get; set; }

        public CustomerUser(string userId, string username, string email, string address)
            : base(userId, username, email)
        {
            ShippingAddress = address;
            LoyaltyPoints = 0; // Điểm ban đầu
        }
    }

    // Lớp con: Quản trị viên hệ thống
    public class AdminUser : User
    {
        public string Role { get; set; }

        public AdminUser(string userId, string username, string email, string role)
            : base(userId, username, email)
        {
            Role = role;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Pull Up Constructor Body trong Quan Ly User ===");

            CustomerUser customer = new CustomerUser("CUST-901", "nmtruong", "truong@gmail.com", "Long Xuyen, An Giang");
            AdminUser admin = new AdminUser("ADM-001", "admin_sys", "admin@store.com", "SuperAdmin");

            Console.WriteLine($"[KHACH HANG] ID: {customer.UserId} | User: {customer.Username} | Dia chi: {customer.ShippingAddress}");
            Console.WriteLine($"[ADMIN] ID: {admin.UserId} | User: {admin.Username} | Quyen: {admin.Role}");

            Console.ReadKey();
        }
    }
}