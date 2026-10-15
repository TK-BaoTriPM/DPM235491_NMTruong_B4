using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveSettingMethod_After
{
    public class Account
    {
        // REFACTORED: Chỉ cung cấp getter, gán giá trị duy nhất qua Constructor
        public string Id { get; }

        public Account(string id)
        {
            Id = id;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Remove Setting Method ===");

            Account acc = new Account("ACC-1001");
            Console.WriteLine($"ID tai khoan: {acc.Id}");

            // acc.Id = "ACC-9999"; // LỖI BIÊN DỊCH: Property 'Id' là Read-only!

            Console.ReadKey();
        }
    }
}