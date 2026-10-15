using System;

namespace DPM235491_NMTruong_B4_SimpMeth_RenameMethod_Before
{
    public class Person
    {
        private string _officeAreaCode = "0296";
        private string _officeNumber = "3852111";

        // CODE SMELL: Tên hàm 'Gets' mơ hồ, không rõ lấy dữ liệu gì
        public string Gets()
        {
            return "(" + _officeAreaCode + ") " + _officeNumber;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Rename Method ===");

            Person person = new Person();
            // Người đọc code khó đoán 'Gets()' trả về số điện thoại hay thông tin khác
            Console.WriteLine($"Thong tin: {person.Gets()}");

            Console.ReadKey();
        }
    }
}