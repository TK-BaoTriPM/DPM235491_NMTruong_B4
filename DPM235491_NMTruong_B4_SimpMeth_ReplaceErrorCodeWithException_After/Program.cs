using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceErrorCodeWithException_After
{
    public class Account
    {
        public double Balance { get; private set; } = 1000.0;

        // REFACTORED: Ném ngoại lệ trực tiếp khi gặp sự cố, phương thức trả về void
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("So tien rut phai lon hon 0!");

            if (amount > Balance)
                throw new InvalidOperationException("So du khong du de thuc hien giao dich!");

            Balance -= amount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Error Code with Exception ===");

            Account acc = new Account();
            double withdrawAmount = 1500.0;

            // Tách biệt luồng xử lý chính và luồng xử lý ngoại lệ bằng try-catch
            try
            {
                acc.Withdraw(withdrawAmount);
                Console.WriteLine($"Rut tien thanh cong! So du con lai: {acc.Balance:N0} USD");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Loi Tham So]: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Loi Nghiap Vu]: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}