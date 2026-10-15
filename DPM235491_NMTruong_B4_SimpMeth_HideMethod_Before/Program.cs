using System;

namespace DPM235491_NMTruong_B4_SimpMeth_HideMethod_Before
{
    public class BankAccount
    {
        public double Balance { get; private set; } = 5000.0;

        // CODE SMELL: Hàm ValidateTransaction() chỉ phục vụ cho Withdraw() nhưng lại để public
        public bool ValidateTransaction(double amount)
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
            Console.WriteLine("=== BEFORE REFACTORING: Hide Method ===");

            BankAccount account = new BankAccount();

            // Rủi ro: Lớp ngoài vô tình gọi hàm phụ trợ nội bộ không cần thiết
            bool isValid = account.ValidateTransaction(1000);
            Console.WriteLine($"Kiem tra hop le tu ben ngoai: {isValid}");

            account.Withdraw(1000);

            Console.ReadKey();
        }
    }
}