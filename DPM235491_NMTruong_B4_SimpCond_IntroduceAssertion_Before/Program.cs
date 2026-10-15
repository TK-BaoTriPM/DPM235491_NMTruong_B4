using System;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceAssertion_Before
{
    public class ExpenseAccount
    {
        private const double NULL_LIMIT = -1.0;
        public double ExpenseLimit { get; set; } = NULL_LIMIT;
        public double PrimaryProjectExpense { get; set; } = 500;

        // CODE SMELL: Đoạn mã ngầm định ExpenseLimit hợp lệ nhưng không có cơ chế kiểm tra
        public double GetExpenseLimit()
        {
            // Nếu không có hạn mức riêng, dùng hạn mức dự án chính
            return (ExpenseLimit != NULL_LIMIT) ? ExpenseLimit : PrimaryProjectExpense;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Introduce Assertion ===");

            ExpenseAccount account = new ExpenseAccount();
            Console.WriteLine($"Han muc chi phi: {account.GetExpenseLimit():N0} USD");

            Console.ReadKey();
        }
    }
}