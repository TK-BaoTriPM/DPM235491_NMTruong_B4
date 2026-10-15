using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceErrorCodeWithException_Real
{
    // Ngoại lệ tùy chỉnh cho nghiệp vụ hết hàng
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }
    }

    public class OrderService
    {
        private int _availableStock = 5;

        // REFACTORED: Ném Exception cụ thể cho từng kịch bản lỗi nghiệp vụ
        public void CreateOrder(string productId, int quantity, double userBalance)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("So luong dat hang phai lon hon 0.");
            }

            if (quantity > _availableStock)
            {
                throw new OutOfStockException($"San pham '{productId}' chi con {_availableStock} san pham trong kho.");
            }

            double totalCost = quantity * 200000;
            if (userBalance < totalCost)
            {
                throw new InvalidOperationException($"Tai khoan khong du tien. Can {totalCost:N0} VND nhung so du chi co {userBalance:N0} VND.");
            }

            _availableStock -= quantity;
            Console.WriteLine($"[THANH CONG] Don hang voi {quantity} san pham '{productId}' da duoc tao.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Quan Ly Don Hang bang Exception Handling ===");

            OrderService service = new OrderService();

            try
            {
                // Thử đặt số lượng vượt quá tồn kho (8 > 5)
                service.CreateOrder(productId: "SP-LAPTOP-01", quantity: 8, userBalance: 5000000);
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine($"[XU LY LIKHO]: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[XU LY THAM SO]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOI HE THONG]: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}