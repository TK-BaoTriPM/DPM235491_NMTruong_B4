using System;
using System.Diagnostics;

namespace DPM235491_NMTruong_B4_SimpCond_IntroduceAssertion_Real
{
    public class SalaryCalculator
    {
        // Tính tiền thưởng năng suất cho nhân viên
        public double CalculateBonus(double baseSalary, double performanceFactor)
        {
            // ASSERTION: Tuyên bố các điều kiện tiên quyết (Pre-conditions)
            // Lương cơ bản không được âm và hệ số hiệu suất phải lớn hơn hoặc bằng 0
            Debug.Assert(baseSalary >= 0, "Lương cơ bản không được nhỏ hơn 0!");
            Debug.Assert(performanceFactor >= 0 && performanceFactor <= 3.0, "Hệ số hiệu suất phải nằm trong khoảng từ 0 đến 3.0!");

            // Nếu chạy trên bản Release, bổ sung kiểm tra an toàn bổ sung
            if (baseSalary < 0 || performanceFactor < 0)
            {
                throw new ArgumentException("Du lieu tinh luong khong hop le!");
            }

            return baseSalary * performanceFactor;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Kiem Tra Gia Dinh Tinh Luong Bang Assertion ===");

            SalaryCalculator calculator = new SalaryCalculator();

            double baseSalary = 15000000; // 15 triệu
            double factor = 1.5;           // Hệ số 1.5

            double bonus = calculator.CalculateBonus(baseSalary, factor);
            Console.WriteLine($"Luong co ban: {baseSalary:N0} VND");
            Console.WriteLine($"He so hieu suat: {factor}");
            Console.WriteLine($"Tien thuong tinh duoc: {bonus:N0} VND");

            Console.ReadKey();
        }
    }
}