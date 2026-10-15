using System;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceNullObject_After
{
    // Lớp cha/Cơ sở
    public class Customer
    {
        public virtual string Name { get; set; }
        public virtual string Plan { get; set; }
        public virtual bool IsNull => false;
    }

    // REFACTORED: Lớp NullObject đại diện cho trường hợp Customer bị null
    public class NullCustomer : Customer
    {
        public override string Name => "occupant";
        public override string Plan => "basic-plan";
        public override bool IsNull => true;
    }

    public class Site
    {
        private Customer _customer;

        public Customer Customer
        {
            get => _customer ?? new NullCustomer(); // Tra ve NullObject neu field null
            set => _customer = value;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Introduce Null Object ===");

            Site site = new Site { Customer = null };

            // REFACTORED: Gọi trực tiếp phương thức/property mà không cần if (customer == null)
            Customer customer = site.Customer;

            string customerName = customer.Name;
            string plan = customer.Plan;

            Console.WriteLine($"Khach hang: {customerName} | Goi dich vu: {plan}");

            Console.ReadKey();
        }
    }
}