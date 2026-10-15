using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractInterface_Before
{
    // Lớp Employee cụ thể chứa các phương thức tính toán chi phí
    public class Employee
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
            return Rate * 8; // 8 gio lam viec
        }

        public bool HasSkill()
        {
            return HasSpecialSkill;
        }
    }

    // CODE SMELL: TimeSheet phụ thuộc trực tiếp vào lớp cụ thể Employee
    public class TimeSheet
    {
        public double CalculateCost(Employee emp)
        {
            double charge = emp.GetCharge();
            if (emp.HasSkill())
            {
                charge *= 1.2; // Phụ phí kỹ năng
            }
            return charge;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Extract Interface ===");

            Employee emp = new Employee("Nguyen Minh Truong", 50.0, true);
            TimeSheet sheet = new TimeSheet();

            double cost = sheet.CalculateCost(emp);
            Console.WriteLine($"Chi phi nhan vien {emp.Name}: {cost:N0} USD");

            Console.ReadKey();
        }
    }
}