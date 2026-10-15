using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractInterface_After
{
    // REFACTORED: Trích xuất Interface IBillable chứa các hợp đồng tính phí
    public interface IBillable
    {
        double GetCharge();
        bool HasSkill();
    }

    // Employee thực thi IBillable
    public class Employee : IBillable
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public bool HasSpecialSkill { get; set; }

        public Employee(string name, double rate, bool hasSpecialSkill)
        {
            Name = name;
            Rate = rate;
            HasSpecialSkill = hasSpecialSkill;
        }

        public double GetCharge()
        {
            return Rate * 8;
        }

        public bool HasSkill()
        {
            return HasSpecialSkill;
        }
    }

    // REFACTORED: TimeSheet giờ đây chỉ phụ thuộc vào Interface IBillable
    public class TimeSheet
    {
        public double CalculateCost(IBillable item)
        {
            double charge = item.GetCharge();
            if (item.HasSkill())
            {
                charge *= 1.2;
            }
            return charge;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Extract Interface ===");

            IBillable emp = new Employee("Nguyen Minh Truong", 50.0, true);
            TimeSheet sheet = new TimeSheet();

            double cost = sheet.CalculateCost(emp);
            Console.WriteLine($"Chi phi tinh qua IBillable Interface: {cost:N0} USD");

            Console.ReadKey();
        }
    }
}