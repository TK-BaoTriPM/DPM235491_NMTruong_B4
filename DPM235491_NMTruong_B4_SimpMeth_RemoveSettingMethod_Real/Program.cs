using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveSettingMethod_Real
{
    public class Order
    {
        // Khóa chính và Thời gian tạo đơn là dữ liệu bất biến (Read-only)
        public string OrderCode { get; }
        public DateTime CreatedAt { get; }

        // Các thuộc tính có thể thay đổi trạng thái trong vòng đời đơn hàng
        public string CustomerName { get; set; }
        public string ShippingStatus { get; set; }

        public Order(string orderCode, string customerName)
        {
            OrderCode = orderCode;
            CreatedAt = DateTime.Now;
            CustomerName = customerName;
            ShippingStatus = "Cho Xac Nhan";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[DON HANG] Ma: {OrderCode} | Ngay tao: {CreatedAt:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"-> Khach hang: {CustomerName} | Trang thai: {ShippingStatus}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Khai Báo Thuộc Tính Bất Biến trong Đơn Hàng ===");

            Order order = new Order("DH-20261015-01", "Nguyen Minh Truong");
            order.DisplayInfo();

            // Cập nhật trạng thái hợp lệ
            order.ShippingStatus = "Dang Giao Hang";
            Console.WriteLine("\n[Cap nhat trang thai don hang]");
            order.DisplayInfo();

            // Cố tình sửa OrderCode hoặc CreatedAt sẽ bị trình biên dịch chặn ngay lập tức
            // order.OrderCode = "DH-KHAC"; // CS0200: Property cannot be assigned to -- it is read only

            Console.ReadKey();
        }
    }
}