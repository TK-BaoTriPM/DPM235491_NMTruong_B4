using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownField_Before
{
    public abstract class Employee
    {
        public string Name { get; set; }

        // CODE SMELL: Trường SalesQuota nằm ở lớp cha Employee, 
        // nhưng Engineer hoàn toàn không bao giờ sử dụng tới.
        public double SalesQuota { get; set; }
    }

    public class Engineer : Employee
    {
        // Kế thừa SalesQuota một cách thừa thãi
    }

    public class Salesman : Employee
    {
        // Là lớp duy nhất cần dùng SalesQuota
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Push Down Field ===");

            Salesman sales = new Salesman { Name = "Le Van A", SalesQuota = 50000.0 };
            Engineer eng = new Engineer { Name = "Nguyen Minh Truong", SalesQuota = 0.0 }; // Dư thừa

            Console.WriteLine($"Salesman: {sales.Name} | Quota: {sales.SalesQuota:N0} USD");
            Console.WriteLine($"Engineer: {eng.Name} | Quota thua: {eng.SalesQuota:N0} USD");

            Console.ReadKey();
        }
    }
}