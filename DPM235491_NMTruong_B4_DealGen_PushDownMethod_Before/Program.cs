using System;

namespace DPM235491_NMTruong_B4_DealGen_PushDownMethod_Before
{
    public abstract class Employee
    {
        public string Name { get; set; }

        // CODE SMELL: Hàm GetSalesQuota() nằm ở lớp cha Employee, 
        // nhưng chỉ có Salesman mới cần dùng, Engineer hoàn toàn không sử dụng.
        public double GetSalesQuota()
        {
            return 50000.0;
        }
    }

    public class Engineer : Employee
    {
        // Kế thừa GetSalesQuota() một cách thừa thãi
    }

    public class Salesman : Employee
    {
        // Là lớp duy nhất thực sự cần GetSalesQuota()
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Push Down Method ===");

            Salesman sales = new Salesman { Name = "Le Van A" };
            Engineer eng = new Engineer { Name = "Nguyen Minh Truong" };

            Console.WriteLine($"Chi tieu cua {sales.Name}: {sales.GetSalesQuota():N0} USD");

            // Bất hợp lý: Kỹ sư cũng có thể gọi hàm chỉ tiêu doanh số
            Console.WriteLine($"Chi tieu cua {eng.Name}: {eng.GetSalesQuota():N0} USD");

            Console.ReadKey();
        }
    }
}