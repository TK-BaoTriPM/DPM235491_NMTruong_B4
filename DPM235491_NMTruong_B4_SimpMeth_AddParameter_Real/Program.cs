using System;

namespace DPM235491_NMTruong_B4_SimpMeth_AddParameter_Real
{
    public class ProductOrder
    {
        public string OrderId { get; set; }
        public double BasePrice { get; set; }
        public int Quantity { get; set; }

        // REFACTORED: Thêm tham số discountPercent và isVipCustomer để tính tổng tiền chính xác
        public double CalculateTotalPrice(double discountPercent, bool isVipCustomer)
        {
            double subtotal = BasePrice * Quantity;
            double discountAmount = subtotal * (discountPercent / 100.0);

            double total = subtotal - discountAmount;

            // Giảm thêm 5% nếu là khách hàng VIP
            if (isVipCustomer)
            {
                total *= 0.95;
            }

            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Tinh Tien Don Hang voi Add Parameter ===");

            ProductOrder order = new ProductOrder
            {
                OrderId = "DH-20261015",
                BasePrice = 500000,
                Quantity = 3
            };

            double discountCode = 10.0; // Giảm 10% từ voucher
            bool isVip = true;          // Khách hàng VIP

            double finalPrice = order.CalculateTotalPrice(discountCode, isVip);

            Console.WriteLine($"Ma don hang: {order.OrderId}");
            Console.WriteLine($"Gia goc: {order.BasePrice * order.Quantity:N0} VND");
            Console.WriteLine($"Tong tien sau khuyen mai (% giam: {discountCode}%, VIP: {isVip}): {finalPrice:N0} VND");

            Console.ReadKey();
        }
    }
}