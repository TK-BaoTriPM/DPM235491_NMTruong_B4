using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceConstructorWithFactoryMethod_Real
{
    // Interface đại diện cho hình thức thanh toán
    public interface IPaymentProcessor
    {
        string ProviderName { get; }
        bool Process(double amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public string ProviderName => "The Tinh Dung (VISA/MasterCard)";
        public bool Process(double amount)
        {
            Console.WriteLine($"[CREDIT CARD] Thanh toan {amount:N0} VND thanh cong.");
            return true;
        }
    }

    public class MoMoProcessor : IPaymentProcessor
    {
        public string ProviderName => "Vi Dien Tu MoMo";
        public bool Process(double amount)
        {
            Console.WriteLine($"[MOMO] Thanh toan {amount:N0} VND qua quet ma QR thanh cong.");
            return true;
        }
    }

    public class CodProcessor : IPaymentProcessor
    {
        public string ProviderName => "Thanh Toan Khi Nhan Hang (COD)";
        public bool Process(double amount)
        {
            Console.WriteLine($"[COD] Ghi nhận don hang {amount:N0} VND thanh toan khi giao hang.");
            return true;
        }
    }

    // Factory Class sử dụng Factory Method để khởi tạo đối tượng Processor tương ứng
    public static class PaymentProcessorFactory
    {
        public static IPaymentProcessor CreateProcessor(string paymentMethodCode)
        {
            switch (paymentMethodCode?.ToUpper())
            {
                case "CREDIT_CARD":
                    return new CreditCardProcessor();
                case "MOMO":
                    return new MoMoProcessor();
                case "COD":
                    return new CodProcessor();
                default:
                    throw new ArgumentException($"Phuong thuc thanh toan '{paymentMethodCode}' khong duoc ho tro!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Khởi Tạo Thanh Toán bằng Factory Method ===");

            double orderAmount = 850000;

            // Khai báo danh sách phương thức từ lựa chọn của người dùng trên giao diện
            string userChoice1 = "MOMO";
            string userChoice2 = "CREDIT_CARD";

            IPaymentProcessor processor1 = PaymentProcessorFactory.CreateProcessor(userChoice1);
            Console.WriteLine($"\n[Giao dich 1] Phuong thuc: {processor1.ProviderName}");
            processor1.Process(orderAmount);

            IPaymentProcessor processor2 = PaymentProcessorFactory.CreateProcessor(userChoice2);
            Console.WriteLine($"\n[Giao dich 2] Phuong thuc: {processor2.ProviderName}");
            processor2.Process(orderAmount);

            Console.ReadKey();
        }
    }
}