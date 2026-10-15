using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpMethod_Real
{
    public abstract class PaymentGateway
    {
        public string TransactionId { get; set; }

        protected PaymentGateway(string transactionId)
        {
            TransactionId = transactionId;
        }

        // REFACTORED: Phương thức PrintReceipt được đẩy lên lớp cha PaymentGateway
        // để dùng chung cho mọi cổng thanh toán
        public void PrintReceipt(double amount, string currency)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("        BIEN NHAN THANH TOAN           ");
            Console.WriteLine($" Ma giao dich: {TransactionId}");
            Console.WriteLine($" Thoi gian   : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($" So tien     : {amount:N0} {currency}");
            Console.WriteLine("========================================");
        }

        // Kỹ thuật Template Method: Các lớp con tự định nghĩa cách xử lý giao dịch riêng
        public abstract bool ExecutePayment(double amount);
    }

    public class CreditCardGateway : PaymentGateway
    {
        public CreditCardGateway(string transactionId) : base(transactionId) { }

        public override bool ExecutePayment(double amount)
        {
            Console.WriteLine($"[CREDIT CARD] Đang xử lý giao dịch {TransactionId}...");
            return true;
        }
    }

    public class EWalletGateway : PaymentGateway
    {
        public EWalletGateway(string transactionId) : base(transactionId) { }

        public override bool ExecutePayment(double amount)
        {
            Console.WriteLine($"[VI DIEN TU] Đang quét mã QR cho giao dịch {TransactionId}...");
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Pull Up Method trong Cong Thanh Toan ===");

            PaymentGateway card = new CreditCardGateway("TXN-99811");
            PaymentGateway wallet = new EWalletGateway("TXN-99812");

            if (card.ExecutePayment(1500000))
            {
                card.PrintReceipt(1500000, "VND");
            }

            Console.WriteLine();

            if (wallet.ExecutePayment(450000))
            {
                wallet.PrintReceipt(450000, "VND");
            }

            Console.ReadKey();
        }
    }
}