using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceParamWithMethodCall_Real
{
    public class Customer
    {
        public string Name { get; set; }
        public int LoyaltyPoints { get; set; }

        public bool IsVip()
        {
            return LoyaltyPoints >= 1000;
        }
    }

    public class Invoice
    {
        public Customer Buyer { get; set; }
        public double Subtotal { get; set; }

        // Lấy tỷ lệ phí giao hàng dựa vào hạng khách hàng
        private double GetShippingDiscountRate()
        {
            return Buyer != null && Buyer.IsVip() ? 0.5 : 0.0; // VIP giảm 50% phí ship
        }

        // REFACTORED: Loại bỏ việc bắt caller phải tự kiểm tra VipRate rồi truyền vào
        public double CalculateShippingFee(double baseShippingFee)
        {
            double discountRate = GetShippingDiscountRate();
            return baseShippingFee * (1.0 - discountRate);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Tinh Phi Giao Hang voi Replace Parameter with Method Call ===");

            Customer vipCustomer = new Customer { Name = "Nguyen Minh Truong", LoyaltyPoints = 1250 };
            Invoice invoice = new Invoice { Buyer = vipCustomer, Subtotal = 2000000 };

            double standardShipFee = 40000;
            double actualShipFee = invoice.CalculateShippingFee(standardShipFee);

            Console.WriteLine($"Khach hang: {vipCustomer.Name} (Diem thuong: {vipCustomer.LoyaltyPoints})");
            Console.WriteLine($"Phi ship goc: {standardShipFee:N0} VND");
            Console.WriteLine($"Phi ship thuc te sau giam gia VIP: {actualShipFee:N0} VND");

            Console.ReadKey();
        }
    }
}