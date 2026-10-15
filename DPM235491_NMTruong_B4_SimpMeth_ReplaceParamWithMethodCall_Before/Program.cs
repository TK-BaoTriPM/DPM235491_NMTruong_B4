using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceParamWithMethodCall_Before
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

        // CODE SMELL: Yêu cầu truyền 'discountLevel' từ bên ngoài dù bản thân Order tự tính được
        public double GetFinalPrice(int discountLevel)
        {
            if (discountLevel == 2)
            {
                return GetBasePrice() * 0.85; // Giảm 15%
            }
            return GetBasePrice() * 0.95; // Giảm 5%
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Parameter with Method Call ===");

            Order order = new Order { Quantity = 150, ItemPrice = 100 };

            // Caller phải tự lấy discountLevel rồi truyền vào hàm
            int discountLevel = order.GetDiscountLevel();
            double price = order.GetFinalPrice(discountLevel);

            Console.WriteLine($"Tong tien don hang: {price:N0} USD");

            Console.ReadKey();
        }
    }
}