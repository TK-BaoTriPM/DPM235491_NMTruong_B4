using System;

namespace DPM235491_NMTruong_B4_SimpMeth_HideMethod_After
{
    public class BankAccount
    {
        public double Balance { get; private set; } = 5000.0;

        // REFACTORED: Chuyển ValidateTransaction thành private để che giấu chi tiết cài đặt nội bộ
        private bool ValidateTransaction(double amount)
        {
            return amount > 0 && amount <= Balance;
        }

        public void Withdraw(double amount)
        {
            if (ValidateTransaction(amount))
            {
                Balance -= amount;
                Console.WriteLine($"[RUT TIEN] Rut thanh cong: {amount:N0} USD");
            }
            else
            {
                Console.WriteLine("[RUT TIEN] So tien khong hop le hoac vuot qua so du!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Hide Method ===");

            BankAccount account = new BankAccount();

            // Bên ngoài chỉ cần gọi phương thức nghiệp vụ chính Withdraw()
            account.Withdraw(1000);

            // account.ValidateTransaction(1000); // LỖI BIÊN DỊCH: 'ValidateTransaction' is inaccessible due to its protection level

            Console.ReadKey();
        }
    }
}