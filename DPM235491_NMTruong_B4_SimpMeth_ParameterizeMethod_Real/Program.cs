using System;

namespace DPM235491_NMTruong_B4_SimpMeth_ParameterizeMethod_Real
{
    public class ShippingCalculator
    {
        private const double BASE_FEE = 30000; // Phí cơ bản 30,000 VND

        // REFACTORED: Thay vì tạo các hàm CalculateInnerCityFee(), CalculateSuburbanFee(), CalculateOutboundFee()
        // Ta gộp thành hàm duy nhất truyền hệ số nhân theo vùng miền (Zone Rate Factor)
        public double CalculateRegionalFee(double zoneFactor, double extraWeightKg)
        {
            double baseRegionalFee = BASE_FEE * zoneFactor;
            double weightFee = extraWeightKg * 5000; // 5k/kg vượt chuẩn

            return baseRegionalFee + weightFee;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Tinh Phi Giao Hang theo Khu Vuc voi Parameterize Method ===");

            ShippingCalculator calculator = new ShippingCalculator();
            double extraWeight = 2.0; // Vượt 2kg

            // Nội thành (Zone Factor: 1.0)
            double innerFee = calculator.CalculateRegionalFee(1.0, extraWeight);

            // Ngoại thành (Zone Factor: 1.5)
            double suburbanFee = calculator.CalculateRegionalFee(1.5, extraWeight);

            // Liên tỉnh / Xa (Zone Factor: 2.5)
            double outboundFee = calculator.CalculateRegionalFee(2.5, extraWeight);

            Console.WriteLine($"Phi giao Noi thanh (+2kg): {innerFee:N0} VND");
            Console.WriteLine($"Phi giao Ngoai thanh (+2kg): {suburbanFee:N0} VND");
            Console.WriteLine($"Phi giao Lien tinh (+2kg): {outboundFee:N0} VND");

            Console.ReadKey();
        }
    }
}