using System;

namespace DPM235491_NMTruong_B4_DealGen_PullUpMethod_After
{
    public abstract class Customer
    {
        // REFACTORED: Chuyển phương thức CreateBill lên lớp cha Customer
        public void CreateBill(double amount)
        {
            Console.WriteLine($"[HOA DON] Ngay: {DateTime.Now:dd/MM/yyyy} | So tien: {amount:N0} USD");
        }
    }

    public class RegularCustomer : Customer
    {
        // Thừa hưởng CreateBill từ Customer
    }

    public class PreferredCustomer : Customer
    {
        // Thừa hưởng CreateBill từ Customer
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Pull Up Method ===");

            RegularCustomer reg = new RegularCustomer();
            PreferredCustomer pref = new PreferredCustomer();

            reg.CreateBill(100);
            pref.CreateBill(250);

            Console.ReadKey();
        }
    }
}