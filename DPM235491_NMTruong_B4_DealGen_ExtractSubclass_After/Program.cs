using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSubclass_After
{
    // Lớp cha chỉ giữ lại các đặc tính chung của mọi JobItem
    public class JobItem
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

        public JobItem(int unitPrice, int quantity)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public virtual int GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }

    // REFACTORED: Tách Subclass LaborItem đại diện cho hạng mục nhân công
    public class LaborItem : JobItem
    {
        public string EmployeeName { get; set; }

        public LaborItem(int unitPrice, int quantity, string employeeName)
            : base(unitPrice, quantity)
        {
            EmployeeName = employeeName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Extract Subclass ===");

            JobItem parts = new JobItem(100, 2);
            LaborItem labor = new LaborItem(50, 4, "Nguyen Minh Truong");

            Console.WriteLine($"Vat tu: {parts.GetTotalPrice()} USD");
            Console.WriteLine($"Nhan cong ({labor.EmployeeName}): {labor.GetTotalPrice()} USD");

            Console.ReadKey();
        }
    }
}