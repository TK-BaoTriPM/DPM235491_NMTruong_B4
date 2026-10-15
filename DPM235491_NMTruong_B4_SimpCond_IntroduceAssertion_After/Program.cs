using System;
using System.Diagnostics;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceAssertion_After
{
    public class ExpenseAccount
    {
        private const double NULL_LIMIT = -1.0;
        public double ExpenseLimit { get; set; } = NULL_LIMIT;
        public double PrimaryProjectExpense { get; set; } = 500;

        public double GetExpenseLimit()
        {
            // REFACTORED: Thêm Assertion để đảm bảo giả định luôn đúng khi Debug
            Debug.Assert(ExpenseLimit != NULL_LIMIT || PrimaryProjectExpense >= 0,
                "Project chinh phai co han muc chi phi hop le (>= 0)!");

            return (ExpenseLimit != NULL_LIMIT) ? ExpenseLimit : PrimaryProjectExpense;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Introduce Assertion ===");

            ExpenseAccount account = new ExpenseAccount();
            Console.WriteLine($"Han muc chi phi: {account.GetExpenseLimit():N0} USD");

            Console.ReadKey();
        }
    }
}