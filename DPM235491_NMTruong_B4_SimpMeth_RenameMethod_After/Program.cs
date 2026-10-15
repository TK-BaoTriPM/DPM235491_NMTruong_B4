using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RenameMethod_After
{
    public class Person
    {
        private string _officeAreaCode = "0296";
        private string _officeNumber = "3852111";

        // REFACTORED: Đổi tên thành 'GetTelephoneNumber' mô tả chính xác kết quả trả về
        public string GetTelephoneNumber()
        {
            return "(" + _officeAreaCode + ") " + _officeNumber;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Rename Method ===");

            Person person = new Person();
            // Lời gọi hàm rõ ràng, tự giải thích
            Console.WriteLine($"So dien thoai co quan: {person.GetTelephoneNumber()}");

            Console.ReadKey();
        }
    }
}