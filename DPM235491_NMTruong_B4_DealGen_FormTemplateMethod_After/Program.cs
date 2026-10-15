using System;

namespace DPM235491_NMTruong_B4_DealGen_FormTemplateMethod_After
{
    // Lớp cha định nghĩa Template Method
    public abstract class Statement
    {
        // REFACTORED: Template Method định nghĩa khung quy trình in báo cáo cố định
        public void Print(string customerName, double amount)
        {
            PrintHeader(customerName);
            PrintContent(amount);
            PrintFooter();
        }

        protected virtual void PrintHeader(string customerName)
        {
            Console.WriteLine($"=== BAO CAO CHO KHACH HANG: {customerName} ===");
        }

        // Bước chi tiết để các lớp con tự cài đặt
        protected abstract void PrintContent(double amount);

        protected virtual void PrintFooter()
        {
            Console.WriteLine("===========================================");
        }
    }

    public class TextStatement : Statement
    {
        protected override void PrintContent(double amount)
        {
            Console.WriteLine($"[TEXT FORMAT] Tong chi tieu: {amount:N0} USD");
        }
    }

    public class HtmlStatement : Statement
    {
        protected override void PrintContent(double amount)
        {
            Console.WriteLine($"<h1>[HTML FORMAT] Tong chi tieu: {amount:N0} USD</h1>");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Form Template Method ===");

            Statement textStatement = new TextStatement();
            textStatement.Print("Nguyen Minh Truong", 1500.0);

            Console.WriteLine();

            Statement htmlStatement = new HtmlStatement();
            htmlStatement.Print("Nguyen Minh Truong", 1500.0);

            Console.ReadKey();
        }
    }
}