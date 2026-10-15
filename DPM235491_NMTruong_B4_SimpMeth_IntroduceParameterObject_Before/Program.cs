using System;

namespace DPM235491_NMTruong_B4_SimpMeth_IntroduceParameterObject_Before
{
    public class Account
    {
        // CODE SMELL: Cặp tham số (start, end) lặp đi lặp lại trong nhiều phương thức
        public double GetFlowBetween(DateTime start, DateTime end)
        {
            Console.WriteLine($"Dang tinh dong tien tu {start:dd/MM/yyyy} den {end:dd/MM/yyyy}...");
            return 1500.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Introduce Parameter Object ===");

            Account acc = new Account();
            DateTime start = new DateTime(2026, 1, 1);
            DateTime end = new DateTime(2026, 1, 31);

            double flow = acc.GetFlowBetween(start, end);
            Console.WriteLine($"Ket qua dong tien: {flow:N0} USD");

            Console.ReadKey();
        }
    }
}