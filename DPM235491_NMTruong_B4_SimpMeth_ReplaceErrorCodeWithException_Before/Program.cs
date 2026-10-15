using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceErrorCodeWithException_Before
{
    public class Account
    {
        public double Balance { get; private set; } = 1000.0;

        // CODE SMELL: Trả về mã lỗi số (-1: vượt số dư, -2: số tiền âm, 0: thành công)
        public int Withdraw(double amount)
        {
            if (amount <= 0)
                return -2; // Mã lỗi: Số tiền không hợp lệ

            if (amount > Balance)
                return -1; // Mã lỗi: Không đủ số dư

            Balance -= amount;
            return 0; // Mã thành công
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Error Code with Exception ===");

            Account acc = new Account();
            double withdrawAmount = 1500.0;

            // Caller phải chủ động nhớ kiểm tra và xử lý từng mã lỗi bằng if-else
            int code = acc.Withdraw(withdrawAmount);
            if (code == -1)
            {
                Console.WriteLine("[LOI -1] Rut tien pride: So du khong du!");
            }
            else if (code == -2)
            {
                Console.WriteLine("[LOI -2] Rut tien phai lon hon 0!");
            }
            else
            {
                Console.WriteLine($"Rut tien thanh cong! So du con lai: {acc.Balance:N0} USD");
            }

            Console.ReadKey();
        }
    }
}