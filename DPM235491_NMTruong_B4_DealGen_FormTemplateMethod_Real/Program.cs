using System;

namespace DPM235491_NMTruong_B4_DealGen_FormTemplateMethod_Real
{
    // Lớp cha trừu tượng định nghĩa Template Method quy trình xử lý đơn hàng
    public abstract class OrderProcessingTemplate
    {
        // TEMPLATE METHOD: Khung quy trình xử lý đơn hàng 4 bước bắt buộc
        public void ProcessOrder(string orderId, double amount)
        {
            Console.WriteLine($"\n>>> BAT DAU XU LY DON HANG: {orderId} <<<");
            SelectProduct(orderId);
            bool isPaid = MakePayment(amount);

            if (isPaid)
            {
                ShipProduct(orderId);
                SendNotification(orderId);
            }
            else
            {
                Console.WriteLine($"[THAT BAI] Don hang {orderId} bi huy do thanh toan khong thanh cong.");
            }
        }

        protected void SelectProduct(string orderId)
        {
            Console.WriteLine($"1. [KHO] Kiem tra ton kho va dong goi san pham cho don {orderId}.");
        }

        // Bước thay đổi tùy theo phương thức thanh toán (COD vs E-Wallet)
        protected abstract bool MakePayment(double amount);

        // Bước thay đổi tùy theo hình thức giao hàng (Giao nhanh vs Giao tiêu chuẩn)
        protected abstract void ShipProduct(string orderId);

        protected void SendNotification(string orderId)
        {
            Console.WriteLine($"4. [THONG BAO] Gui Email/SMS xac nhan don hang {orderId} thanh cong.");
        }
    }

    // Quy trình đơn hàng nội thành giao hỏa tốc thanh toán qua MoMo
    public class LocalExpressOrderProcessor : OrderProcessingTemplate
    {
        protected override bool MakePayment(double amount)
        {
            Console.WriteLine($"2. [THANH TOAN MOMO] Quet ma QR va tru {amount:N0} VND tu vi MoMo.");
            return true;
        }

        protected override void ShipProduct(string orderId)
        {
            Console.WriteLine($"3. [VAN CHUON HOA TOC] Giao cho Shipper GrabExpress giao ngay trong 2h.");
        }
    }

    // Quy trình đơn hàng liên tỉnh thanh toán COD
    public class InterprovincialCodOrderProcessor : OrderProcessingTemplate
    {
        protected override bool MakePayment(double amount)
        {
            Console.WriteLine($"2. [THANH TOAN COD] Cap nhat trang thai: Thu tien {amount:N0} VND khi giao hang.");
            return true;
        }

        protected override void ShipProduct(string orderId)
        {
            Console.WriteLine($"3. [VAN CHUYEN TIEN TIEU CHUAN] Ban giao don hang cho ViettelPost (3-5 ngay).");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Form Template Method trong Quy Trinh Don Hang ===");

            OrderProcessingTemplate expressOrder = new LocalExpressOrderProcessor();
            expressOrder.ProcessOrder("DH-NOITHANH-01", 850000);

            OrderProcessingTemplate codOrder = new InterprovincialCodOrderProcessor();
            codOrder.ProcessOrder("DH-LIENTINH-02", 1250000);

            Console.ReadKey();
        }
    }
}