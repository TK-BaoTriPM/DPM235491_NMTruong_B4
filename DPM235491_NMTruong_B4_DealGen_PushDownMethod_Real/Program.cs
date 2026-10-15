using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownMethod_Real
{
    // Lớp cha đại diện cho đơn hàng tổng quát
    public abstract class Order
    {
        public string OrderId { get; set; }
        public double TotalAmount { get; set; }

        protected Order(string orderId, double totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
        }

        public void DisplayBasicInfo()
        {
            Console.WriteLine($"[DON HANG] Ma: {OrderId} | Tong tien: {TotalAmount:N0} VND");
        }
    }

    // Đơn hàng giao tiêu chuẩn
    public class StandardOrder : Order
    {
        public StandardOrder(string orderId, double totalAmount) : base(orderId, totalAmount) { }
    }

    // Đơn hàng giao hỏa tốc 2H
    public class ExpressOrder : Order
    {
        public ExpressOrder(string orderId, double totalAmount) : base(orderId, totalAmount) { }

        // REFACTORED: Đẩy hàm AssignExpressShipper() xuống ExpressOrder 
        // vì đơn tiêu chuẩn không bao giờ cần gán Shipper hỏa tốc ưu tiên
        public void AssignExpressShipper(string shipperName)
        {
            Console.WriteLine($"-> [HOA TOC 2H] Da dieu xe Shipper '{shipperName}' den kho lay don {OrderId} ngay lập tức!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Push Down Method trong Quan Ly Don Hang ===");

            StandardOrder stdOrder = new StandardOrder("STD-20261015", 350000);
            ExpressOrder expOrder = new ExpressOrder("EXP-20261015", 1200000);

            stdOrder.DisplayBasicInfo();

            expOrder.DisplayBasicInfo();
            // Chỉ đơn hỏa tốc mới được cấp quyền gọi hàm điều phối Shipper hỏa tốc
            expOrder.AssignExpressShipper("Nguyen Van B");

            Console.ReadKey();
        }
    }
}