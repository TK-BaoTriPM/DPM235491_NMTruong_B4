using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceCondPoly_After
{
    // REFACTORED: Chuyển lớp Bird thành abstract class và định nghĩa phương thức ảo GetSpeed()
    public abstract class Bird
    {
        public double BaseSpeed { get; set; } = 10.0;

        public abstract double GetSpeed();
    }

    public class EuropeanBird : Bird
    {
        public override double GetSpeed() => BaseSpeed;
    }

    public class AfricanBird : Bird
    {
        public double LoadFactor { get; set; } = 1.2;
        public int Coconuts { get; set; } = 2;

        public override double GetSpeed() => BaseSpeed - LoadFactor * Coconuts;
    }

    public class NorwegianBlueBird : Bird
    {
        public double Voltage { get; set; } = 100;
        public bool IsNailed { get; set; } = false;

        public override double GetSpeed() => IsNailed ? 0 : Voltage / 10;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Conditional with Polymorphism ===");

            Bird b1 = new EuropeanBird();
            Bird b2 = new AfricanBird();

            Console.WriteLine($"Toc do Chim Chau Au: {b1.GetSpeed()}");
            Console.WriteLine($"Toc do Chim Chau Phi: {b2.GetSpeed()}");

            Console.ReadKey();
        }
    }
}