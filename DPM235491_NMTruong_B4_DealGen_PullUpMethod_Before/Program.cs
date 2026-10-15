using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpMethod_Before
{
    public abstract class Customer
    {
    }

    public class RegularCustomer : Customer
    {
        // CODE SMELL: Hàm CreateBill bị lặp ở RegularCustomer
        public void CreateBill(double amount)
        {
            Console.WriteLine($"[HOA DON] Ngay: {DateTime.Now:dd/MM/yyyy} | So tien: {amount:N0} USD");
        }
    }

    public class PreferredCustomer : Customer
    {
        // CODE SMELL: Hàm CreateBill tiếp tục bị lặp lại ở PreferredCustomer với logic giống hệt
        public void CreateBill(double amount)
        {
            Console.WriteLine($"[HOA DON] Ngay: {DateTime.Now:dd/MM/yyyy} | So tien: {amount:N0} USD");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Pull Up Method ===");

            RegularCustomer reg = new RegularCustomer();
            PreferredCustomer pref = new PreferredCustomer();

            reg.CreateBill(100);
            pref.CreateBill(250);

            Console.ReadKey();
        }
    }
}