using System;

namespace DPM235491_NMTruong_B4_SimpMeth_IntroduceParameterObject_Real
{
    // Parameter Object: Đại diện cho tất cả tiêu chí tìm kiếm/lọc đơn hàng
    public class OrderFilterRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public string PaymentMethod { get; set; }
        public int MinAmount { get; set; }

        public OrderFilterRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Category = "All";
            PaymentMethod = "All";
            MinAmount = 0;
        }
    }

    public class ReportService
    {
        // REFACTORED: Chỉ cần truyền 1 Parameter Object thay vì 5-6 tham số rời rạc
        public void GenerateRevenueReport(OrderFilterRequest filter)
        {
            Console.WriteLine("=== BAO CAO DOANH THU ===");
            Console.WriteLine($"-> Khoang thoi gian: {filter.StartDate:dd/MM/yyyy} - {filter.EndDate:dd/MM/yyyy}");
            Console.WriteLine($"-> Danh muc: {filter.Category}");
            Console.WriteLine($"-> Phuong thuc thanh toan: {filter.PaymentMethod}");
            Console.WriteLine($"-> Gia tri don hang toi thieu: {filter.MinAmount:N0} VND");
            Console.WriteLine("-> Ket qua: Tong doanh thu dat 45,000,000 VND từ 120 đơn hàng.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Loc Bao Cao bang Introduce Parameter Object ===");

            ReportService service = new ReportService();

            OrderFilterRequest filter = new OrderFilterRequest(
                new DateTime(2026, 10, 1),
                new DateTime(2026, 10, 15)
            )
            {
                Category = "Dien Tu",
                PaymentMethod = "MOMO",
                MinAmount = 500000
            };

            service.GenerateRevenueReport(filter);

            Console.ReadKey();
        }
    }
}