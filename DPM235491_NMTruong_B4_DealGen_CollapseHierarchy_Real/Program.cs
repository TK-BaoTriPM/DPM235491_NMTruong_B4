using System;

namespace DPM235491_NMTruong_B4_DealGen_CollapseHierarchy_Real
{
    // REFACTORED: Gộp lớp StandardShippingCalculator vốn không có logic riêng biệt vào ShippingService chính
    public class ShippingService
    {
        public string ServiceName { get; set; }
        public double BaseFee { get; set; }

        public ShippingService(string serviceName, double baseFee)
        {
            ServiceName = serviceName;
            BaseFee = baseFee;
        }

        public double CalculateShippingFee(double weightKg, double distanceKm)
        {
            // Logic tính cước phí tiêu chuẩn cho mọi đơn hàng
            double weightFee = weightKg * 5000;
            double distanceFee = distanceKm * 2000;
            return BaseFee + weightFee + distanceFee;
        }

        public void PrintShippingLabel(string orderCode, double weightKg, double distanceKm)
        {
            double totalFee = CalculateShippingFee(weightKg, distanceKm);
            Console.WriteLine($"==========================================");
            Console.WriteLine($" HOAN DON VAN CHUYEN - {ServiceName.ToUpper()}");
            Console.WriteLine($" Ma don: {orderCode}");
            Console.WriteLine($" Trong luong: {weightKg} kg | Quang đường: {distanceKm} km");
            Console.WriteLine($" Cuoc phi gộp: {totalFee:N0} VND");
            Console.WriteLine($"==========================================");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Collapse Hierarchy trong Dich Vu Van Chuyển ===");

            ShippingService shipping = new ShippingService("Giao Hang Tieu Chuan", 15000);
            shipping.PrintShippingLabel("DH-20261015-88", weightKg: 2.5, distanceKm: 12.0);

            Console.ReadKey();
        }
    }
}