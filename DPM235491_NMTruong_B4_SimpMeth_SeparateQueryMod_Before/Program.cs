using System;

namespace DPM235491_NMTruong_B4_SimpMeth_SeparateQueryMod_Before
{
    public class SecuritySystem
    {
        // CODE SMELL: Hàm vừa tìm tên kẻ nghi vấn (Query) vừa phát cảnh báo (Modifier/Side-effect)
        public string FoundMiscreantAndAlert(string[] people)
        {
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Equals("Don") || people[i].Equals("John"))
                {
                    SendAlert(); // Side-effect: Thay đổi trạng thái / gửi cảnh báo
                    return people[i]; // Query: Trả về dữ liệu
                }
            }
            return "";
        }

        private void SendAlert()
        {
            Console.WriteLine("-> [CANH BAO] Phat hien nhan su trong danh sach den!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Separate Query from Modifier ===");

            SecuritySystem system = new SecuritySystem();
            string[] people = { "Alice", "Bob", "Don", "Charlie" };

            // Chỉ muốn kiểm tra xem có ai nghi vấn không nhưng lại vô tình kích hoạt luôn cảnh báo
            string found = system.FoundMiscreantAndAlert(people);
            Console.WriteLine($"Ket qua tim kiem: {found}");

            Console.ReadKey();
        }
    }
}