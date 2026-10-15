using System;

namespace DPM235491_NMTruong_B4_DealGen_FormTemplateMethod_Before
{
    public class StatementPrinter
    {
        // CODE SMELL: In báo cáo văn bản thuần tuý (Text)
        public void PrintTextStatement(string customerName, double amount)
        {
            Console.WriteLine($"=== BAO CAO CHO KHACH HANG: {customerName} ==="); // Trùng khung
            Console.WriteLine($"[TEXT FORMAT] Tong chi tieu: {amount:N0} USD");
            Console.WriteLine("==========================================="); // Trùng khung
        }

        // CODE SMELL: In báo cáo HTML (Lặp lại thứ tự khung in, chỉ khác định dạng)
        public void PrintHtmlStatement(string customerName, double amount)
        {
            Console.WriteLine($"=== BAO CAO CHO KHACH HANG: {customerName} ==="); // Trùng khung
            Console.WriteLine($"<h1>[HTML FORMAT] Tong chi tieu: {amount:N0} USD</h1>");
            Console.WriteLine("==========================================="); // Trùng khung
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Form Template Method ===");

            StatementPrinter printer = new StatementPrinter();
            printer.PrintTextStatement("Nguyen Minh Truong", 1500.0);
            Console.WriteLine();
            printer.PrintHtmlStatement("Nguyen Minh Truong", 1500.0);

            Console.ReadKey();
        }
    }
}