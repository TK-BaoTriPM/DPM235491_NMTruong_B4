using System;

namespace DPM235491_NMTruong_B4_SimpMeth_SeparateQueryMod_After
{
    public class SecuritySystem
    {
        // 1. QUERY: Chỉ làm nhiệm vụ kiểm tra/truy vấn dữ liệu, không sinh side-effect
        public string FoundMiscreant(string[] people)
        {
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Equals("Don") || people[i].Equals("John"))
                {
                    return people[i];
                }
            }
            return "";
        }

        // 2. MODIFIER: Chỉ thực hiện hành động / thay đổi trạng thái
        public void SendAlert()
        {
            Console.WriteLine("-> [CANH BAO] Phat hien nhan su trong danh sach den!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Separate Query from Modifier ===");

            SecuritySystem system = new SecuritySystem();
            string[] people = { "Alice", "Bob", "Don", "Charlie" };

            // REFACTORED: Gọi hàm Query để kiểm tra trước
            string found = system.FoundMiscreant(people);

            // Nếu thỏa điều kiện mới chủ động gọi hàm Modifier
            if (!string.IsNullOrEmpty(found))
            {
                system.SendAlert();
            }

            Console.WriteLine($"Ket qua tim kiem: {found}");

            Console.ReadKey();
        }
    }
}