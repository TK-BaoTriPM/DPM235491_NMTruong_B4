using System;

namespace DPM235491_NMTruong_B4_SimpMeth_IntroduceParameterObject_After
{
    // REFACTORED: Gom nhóm cặp ngày tháng vào lớp DateRange
    public class DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool Includes(DateTime date)
        {
            return date >= Start && date <= End;
        }
    }

    public class Account
    {
        // REFACTORED: Dùng DateRange làm tham số duy nhất
        public double GetFlowBetween(DateRange range)
        {
            Console.WriteLine($"Dang tinh dong tien tu {range.Start:dd/MM/yyyy} den {range.End:dd/MM/yyyy}...");
            return 1500.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Introduce Parameter Object ===");

            Account acc = new Account();
            DateRange range = new DateRange(new DateTime(2026, 1, 1), new DateTime(2026, 1, 31));

            double flow = acc.GetFlowBetween(range);
            Console.WriteLine($"Ket qua dong tien: {flow:N0} USD");

            Console.ReadKey();
        }
    }
}