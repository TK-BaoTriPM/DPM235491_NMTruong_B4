using System;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceDelegationWithInheritance_Real
{
    // Lớp cha đại diện cho Tài khoản người dùng hệ thống e-commerce
    public class UserAccount
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public UserAccount(string userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }

        public virtual void DisplayProfile()
        {
            Console.WriteLine($"[USER] ID: {UserId} | Username: {Username} | Email: {Email}");
        }
    }

    // REFACTORED: AdminAccount kế thừa trực tiếp từ UserAccount thay vì ủy quyền
    public class AdminAccount : UserAccount
    {
        public string AdminRole { get; set; }

        public AdminAccount(string userId, string username, string email, string adminRole)
            : base(userId, username, email)
        {
            AdminRole = adminRole;
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine($"-> Quyen quan tri: {AdminRole}");
        }

        public void AccessAdminDashboard()
        {
            Console.WriteLine($"[ADMIN PANEL] Quyen '{AdminRole}' dang truy cap he thong quan ly ban hang...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Replace Delegation with Inheritance trong Quan Ly Account ===");

            AdminAccount admin = new AdminAccount("ADM-01", "nmtruong_admin", "truong.admin@store.com", "SuperAdmin");

            admin.DisplayProfile();
            admin.AccessAdminDashboard();

            Console.ReadKey();
        }
    }
}