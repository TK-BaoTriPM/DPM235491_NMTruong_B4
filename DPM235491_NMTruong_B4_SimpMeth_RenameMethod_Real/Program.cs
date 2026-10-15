using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RenameMethod_Real
{
    public class InventoryService
    {
        private int _currentStock = 15;

        // BEFORE (mơ hồ): public bool Chk(int q)
        // REFACTORED: Tên hàm thể hiện rõ ý định kiểm tra đủ số lượng tồn kho hay không
        public bool IsStockAvailable(int requestedQuantity)
        {
            return _currentStock >= requestedQuantity;
        }

        // BEFORE (mơ hồ): public double Calc(double w, double d)
        // REFACTORED: Đổi tên thành CalculateExpressShippingFee thể hiện rõ tính phí hỏa tốc
        public double CalculateExpressShippingFee(double weightKg, double distanceKm)
        {
            double baseFee = 20000;
            return baseFee + (weightKg * 3000) + (distanceKm * 1500);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Quan Ly Kho & Van Chuyen bang Rename Method ===");

            InventoryService service = new InventoryService();
            int orderQuantity = 5;
            double weight = 2.5;
            double distance = 10.0;

            if (service.IsStockAvailable(orderQuantity))
            {
                double shippingFee = service.CalculateExpressShippingFee(weight, distance);
                Console.WriteLine($"-> Dat hang thanh cong cho {orderQuantity} san pham.");
                Console.WriteLine($"-> Phi giao hang hoa toc: {shippingFee:N0} VND");
            }
            else
            {
                Console.WriteLine("-> San pham trong kho khong du!");
            }

            Console.ReadKey();
        }
    }
}