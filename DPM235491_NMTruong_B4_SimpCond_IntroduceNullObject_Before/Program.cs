using System;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceNullObject_Before
{
    public class Customer
    {
        public string Name { get; set; }
        public string Plan { get; set; }
    }

    public class Site
    {
        public Customer Customer { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Introduce Null Object ===");

            Site site = new Site { Customer = null }; // Khách hàng vô danh / chưa đăng nhập

            // CODE SMELL: Kiểm tra null lặp đi lặp lại ở khắp nơi
            Customer customer = site.Customer;

            string customerName;
            if (customer == null)
            {
                customerName = "occupant";
            }
            else
            {
                customerName = customer.Name;
            }

            string plan;
            if (customer == null)
            {
                plan = "basic-plan";
            }
            else
            {
                plan = customer.Plan;
            }

            Console.WriteLine($"Khach hang: {customerName} | Goi dich vu: {plan}");

            Console.ReadKey();
        }
    }
}