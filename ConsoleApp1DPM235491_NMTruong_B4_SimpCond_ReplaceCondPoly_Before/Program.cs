using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceCondPoly_Before
{
    public class Bird
    {
        public const int EUROPEAN = 0;
        public const int AFRICAN = 1;
        public const int NORWEGIAN_BLUE = 2;

        public int Type { get; set; }
        public double BaseSpeed { get; set; } = 10.0;
        public double LoadFactor { get; set; } = 1.2;
        public int Coconuts { get; set; } = 2;
        public double Voltage { get; set; } = 100;
        public bool IsNailed { get; set; } = false;

        public Bird(int type)
        {
            Type = type;
        }

        // CODE SMELL: Câu lệnh switch tính tốc độ chim dựa theo mã loại Type
        public double GetSpeed()
        {
            switch (Type)
            {
                case EUROPEAN:
                    return BaseSpeed;
                case AFRICAN:
                    return BaseSpeed - LoadFactor * Coconuts;
                case NORWEGIAN_BLUE:
                    return IsNailed ? 0 : Voltage / 10;
                default:
                    throw new ArgumentException("Loai chim khong hop le!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Conditional with Polymorphism ===");

            Bird b1 = new Bird(Bird.EUROPEAN);
            Bird b2 = new Bird(Bird.AFRICAN);

            Console.WriteLine($"Toc do Chim Chau Au: {b1.GetSpeed()}");
            Console.WriteLine($"Toc do Chim Chau Phi: {b2.GetSpeed()}");

            Console.ReadKey();
        }
    }
}