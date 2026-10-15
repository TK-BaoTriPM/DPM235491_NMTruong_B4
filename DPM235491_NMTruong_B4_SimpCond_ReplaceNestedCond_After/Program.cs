using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceNestedCond_After
{
    public class Payroll
    {
        public bool IsDead { get; set; }
        public bool IsSeparated { get; set; }
        public bool IsRetired { get; set; }

        // REFACTORED: Dùng Guard Clauses (Mệnh đề bảo vệ) kiểm tra và return sớm các trường hợp ngoại lệ
        public double GetPayAmount()
        {
            if (IsDead) return DeadAmount();
            if (IsSeparated) return SeparatedAmount();
            if (IsRetired) return RetiredAmount();

            // Luồng xử lý chính (happy path) nằm phẳng ở cuối hàm
            return NormalPayAmount();
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
            Console.WriteLine("=== AFTER REFACTORING: Replace Nested Conditional with Guard Clauses ===");

            Payroll emp = new Payroll { IsDead = false, IsSeparated = false, IsRetired = true };
            Console.WriteLine($"So tien luong / tro cap: {emp.GetPayAmount():N0} USD");

            Console.ReadKey();
        }
    }
}