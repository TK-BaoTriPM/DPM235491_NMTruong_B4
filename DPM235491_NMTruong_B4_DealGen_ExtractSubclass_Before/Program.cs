using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSubclass_Before
{
    public class JobItem
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

        // CODE SMELL: Thuộc tính và cờ dành riêng cho công việc nhân công (Labor)
        public bool IsLabor { get; set; }
        public string EmployeeName { get; set; }

        public JobItem(int unitPrice, int quantity, bool isLabor, string employeeName = null)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            IsLabor = isLabor;
            EmployeeName = employeeName;
        }

        public int GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Extract Subclass ===");

            // Hạng mục vật tư
            JobItem parts = new JobItem(unitPrice: 100, quantity: 2, isLabor: false);

            // Hạng mục nhân công (phải dùng cờ isLabor = true)
            JobItem labor = new JobItem(unitPrice: 50, quantity: 4, isLabor: true, employeeName: "Nguyen Minh Truong");

            Console.WriteLine($"Vat tu: {parts.GetTotalPrice()} USD");
            Console.WriteLine($"Nhan cong ({labor.EmployeeName}): {labor.GetTotalPrice()} USD");

            Console.ReadKey();
        }
    }
}