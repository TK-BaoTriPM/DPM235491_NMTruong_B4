using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSubclass_Real
{
    // Tài khoản khách hàng thông thường
    public class CustomerAccount
    {
        public string AccountId { get; set; }
        public string CustomerName { get; set; }
        public double TotalSpent { get; set; }

        public CustomerAccount(string accountId, string customerName)
        {
            AccountId = accountId;
            CustomerName = customerName;
            TotalSpent = 0;
        }

        public virtual double CalculateDiscount(double orderAmount)
        {
            return 0.0; // Khách hàng thông thường không có chiết khấu mặc định
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[KHACH HANG THUONG] ID: {AccountId} | Ten: {CustomerName} | Da chi: {TotalSpent:N0} VND");
        }
    }

    // REFACTORED: Tách Subclass VipCustomerAccount quản lý các đặc quyền dành riêng cho khách VIP
    public class VipCustomerAccount : CustomerAccount
    {
        public string PersonalConciergeName { get; set; } // Chuyên viên hỗ trợ riêng
        public double VipDiscountRate { get; set; }       // Tỷ lệ giảm giá cố định

        public VipCustomerAccount(string accountId, string customerName, string conciergeName, double discountRate)
            : base(accountId, customerName)
        {
            PersonalConciergeName = conciergeName;
            VipDiscountRate = discountRate;
        }

        public override double CalculateDiscount(double orderAmount)
        {
            return orderAmount * VipDiscountRate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[KHACH HANG VIP] ID: {AccountId} | Ten: {CustomerName} | Giảm giá VIP: {VipDiscountRate * 100}%");
            Console.WriteLine($"-> Chuyen vien ho tro rieng: {PersonalConciergeName}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Extract Subclass Quan Ly Khach Hang VIP ===");

            CustomerAccount regularCust = new CustomerAccount("CUST-101", "Le Van A");
            VipCustomerAccount vipCust = new VipCustomerAccount("VIP-888", "Nguyen Minh Truong", "Tran Thi Support", 0.15);

            double orderValue = 2000000;

            regularCust.DisplayInfo();
            Console.WriteLine($"-> Mức giảm đơn 2tr: {regularCust.CalculateDiscount(orderValue):N0} VND\n");

            vipCust.DisplayInfo();
            Console.WriteLine($"-> Mức giảm đơn 2tr: {vipCust.CalculateDiscount(orderValue):N0} VND");

            Console.ReadKey();
        }
    }
}