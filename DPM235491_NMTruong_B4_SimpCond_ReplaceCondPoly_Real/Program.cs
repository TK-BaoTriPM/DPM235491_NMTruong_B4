using System;

namespace DPM235491_NMTruong_B4_SimpCond_ReplaceCondPoly_Real
{
    // Lớp cha đại diện cho Phương thức giao hàng
    public abstract class ShippingMethod
    {
        public string Name { get; set; }

        public ShippingMethod(string name)
        {
            Name = name;
        }

        // Phương thức tính phí giao hàng đa hình
        public abstract double CalculateCost(double weightKg, double distanceKm);
    }

    // Giao hàng Tiêu chuẩn
    public class StandardShipping : ShippingMethod
    {
        public StandardShipping() : base("Giao Hang Tieu Chuan") { }

        public override double CalculateCost(double weightKg, double distanceKm)
        {
            return 15000 + (weightKg * 2000) + (distanceKm * 1000);
        }
    }

    // Giao hàng Hỏa tốc (Express)
    public class ExpressShipping : ShippingMethod
    {
        public ExpressShipping() : base("Giao Hang Hoa Toc") { }

        public override double CalculateCost(double weightKg, double distanceKm)
        {
            return 35000 + (weightKg * 5000) + (distanceKm * 3000);
        }
    }

    // Giao hàng Tiết kiệm (Economy)
    public class EconomyShipping : ShippingMethod
    {
        public EconomyShipping() : base("Giao Hang Tiet Kiem") { }

        public override double CalculateCost(double weightKg, double distanceKm)
        {
            return 10000 + (weightKg * 1000) + (distanceKm * 500);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Tinh Phi Van Chuyen Da Hinh (Polymorphism) ===");

            double weight = 3.5;  // 3.5 kg
            double distance = 12; // 12 km

            ShippingMethod standard = new StandardShipping();
            ShippingMethod express = new ExpressShipping();
            ShippingMethod economy = new EconomyShipping();

            Console.WriteLine($"Don hang: Khhoi luong = {weight}kg | Quang duong = {distance}km\n");
            Console.WriteLine($"1. {standard.Name}: {standard.CalculateCost(weight, distance):N0} VND");
            Console.WriteLine($"2. {express.Name}: {express.CalculateCost(weight, distance):N0} VND");
            Console.WriteLine($"3. {economy.Name}: {economy.CalculateCost(weight, distance):N0} VND");

            Console.ReadKey();
        }
    }
}