using System;

namespace DPM235491_NMTruong_B4_SimpMeth_AddParameter_After
{
    public class Customer
    {
        public string Name { get; set; }

        // REFACTORED: Thêm tham số 'date' để tính tiền linh hoạt theo ngày
        public double GetContactBill(DateTime date)
        {
            double baseRate = 100.0;

            // Nếu là ngày cuối tuần thì tăng giá 20%
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return baseRate * 1.2;
            }

            return baseRate;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Add Parameter ===");

            Customer customer = new Customer { Name = "Nguyen Minh Truong" };
            DateTime today = new DateTime(2026, 10, 17); // Thứ Bảy

            Console.WriteLine($"Hoa don ngay {today:dd/MM/yyyy} cua {customer.Name}: {customer.GetContactBill(today):N0} USD");

            Console.ReadKey();
        }
    }
}