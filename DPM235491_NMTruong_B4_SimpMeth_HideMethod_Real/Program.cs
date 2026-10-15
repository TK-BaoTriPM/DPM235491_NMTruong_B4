using System;
using System.Text;

namespace DPM235491_NMTruong_B4_SimpMeth_HideMethod_Real
{
    public class OrderProcessingService
    {
        // Public API: Giao diện duy nhất mà các tầng Controller / UI được phép tương tác
        public string ProcessPayment(string orderId, string creditCardNumber, double amount)
        {
            string maskedCard = MaskCreditCard(creditCardNumber);
            string transactionSignature = GenerateHashSignature(orderId, amount);

            Console.WriteLine($"[GATEWAY] Dang gui thanh toan cho don {orderId}...");
            Console.WriteLine($"[GATEWAY] The: {maskedCard} | Chuky: {transactionSignature}");

            return $"PAYMENT_OK_{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }

        // REFACTORED: Ẩn hàm che số thẻ credit (Helper method nội bộ)
        private string MaskCreditCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
                return "****";

            return "****-****-****-" + cardNumber.Substring(cardNumber.Length - 4);
        }

        // REFACTORED: Ẩn hàm tạo chữ ký mã hóa giao dịch (Security logic nội bộ)
        private string GenerateHashSignature(string orderId, double amount)
        {
            string rawData = $"{orderId}_{amount}_SECRET_KEY_2026";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(rawData)).Substring(0, 12);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: An Chi Tiet Ma Hoa bang Hide Method ===");

            OrderProcessingService paymentService = new OrderProcessingService();

            string transactionCode = paymentService.ProcessPayment(
                orderId: "DH-20261015",
                creditCardNumber: "4532111122228888",
                amount: 1500000
            );

            Console.WriteLine($"-> Ket qua giao dịch: {transactionCode}");

            Console.ReadKey();
        }
    }
}