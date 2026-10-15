using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RemoveSettingMethod_Before
{
    public class Account
    {
        private string _id;

        // CODE SMELL: Mở setter cho _id cho phép thay đổi ID tài khoản bất kỳ lúc nào
        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public Account(string id)
        {
            _id = id;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Remove Setting Method ===");

            Account acc = new Account("ACC-1001");
            Console.WriteLine($"ID ban dau: {acc.Id}");

            // Rủi ro: ID bị sửa đổi vô lý ở đâu đó trong chương trình
            acc.Id = "ACC-9999";
            Console.WriteLine($"ID sau khi bi thay doi: {acc.Id}");

            Console.ReadKey();
        }
    }
}