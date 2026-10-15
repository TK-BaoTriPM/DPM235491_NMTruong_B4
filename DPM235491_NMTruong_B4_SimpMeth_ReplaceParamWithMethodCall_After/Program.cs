using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceParamWithMethodCall_After
{
    public class Order
    {
        public int Quantity { get; set; } = 10;
        public double ItemPrice { get; set; } = 50.0;

        public double GetBasePrice()
        {
            return Quantity * ItemPrice;
        }

        public int GetDiscountLevel()
        {
            return Quantity > 100 ? 2 : 1;
        }

        // REFACTORED: Bỏ tham số 'discountLevel', gọi trực tiếp GetDiscountLevel() nội bộ
        public double GetFinalPrice()
        {
            int discountLevel = GetDiscountLevel();

            if (discountLevel == 2)
            {
                return GetBasePrice() * 0.85;
            }
            return GetBasePrice() * 0.95;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Parameter with Method Call ===");

            Order order = new Order { Quantity = 150, ItemPrice = 100 };

            // Caller chỉ cần gọi GetFinalPrice() đơn giản
            double price = order.GetFinalPrice();

            Console.WriteLine($"Tong tien don hang: {price:N0} USD");

            Console.ReadKey();
        }
    }
}