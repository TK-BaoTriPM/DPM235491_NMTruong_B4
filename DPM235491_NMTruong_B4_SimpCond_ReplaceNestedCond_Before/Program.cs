using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceNestedCond_Before
{
    public class Payroll
    {
        public bool IsDead { get; set; }
        public bool IsSeparated { get; set; }
        public bool IsRetired { get; set; }

        // CODE SMELL: Các câu lệnh if-else lồng nhau gây rối mắt và làm ẩn luồng xử lý chính
        public double GetPayAmount()
        {
            double result;
            if (IsDead)
            {
                result = DeadAmount();
            }
            else
            {
                if (IsSeparated)
                {
                    result = SeparatedAmount();
                }
                else
                {
                    if (IsRetired)
                    {
                        result = RetiredAmount();
                    }
                    else
                    {
                        result = NormalPayAmount();
                    }
                }
            }
            return result;
        }

        private double DeadAmount() => 5000;
        private double SeparatedAmount() => 2000;
        private double RetiredAmount() => 3000;
        private double NormalPayAmount() => 1000;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Nested Conditional with Guard Clauses ===");

            Payroll emp = new Payroll { IsDead = false, IsSeparated = false, IsRetired = true };
            Console.WriteLine($"So tien luong / tro cap: {emp.GetPayAmount():N0} USD");

            Console.ReadKey();
        }
    }
}