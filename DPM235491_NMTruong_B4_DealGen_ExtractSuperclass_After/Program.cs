using System;

namespace DPM235491_NMTruong_B4_DealGen_ExtractSuperclass_After
{
    // REFACTORED: Trích xuất lớp cha Party gom các thuộc tính chung
    public abstract class Party
    {
        public string Name { get; set; }
        public double AnnualCost { get; set; }

        protected Party(string name, double annualCost)
        {
            Name = name;
            AnnualCost = annualCost;
        }
    }

    // Employee kế thừa Party
    public class Employee : Party
    {
        public int Id { get; set; }

        public Employee(string name, int id, double annualCost)
            : base(name, annualCost)
        {
            Id = id;
        }
    }

    // Department kế thừa Party
    public class Department : Party
    {
        public int StaffCount { get; set; }

        public Department(string name, double annualCost, int staffCount)
            : base(name, annualCost)
        {
            StaffCount = staffCount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Extract Superclass ===");

            Employee emp = new Employee("Nguyen Minh Truong", 101, 15000.0);
            Department dept = new Department("Phong CNTT", 120000.0, 8);

            Console.WriteLine($"Nhan vien: {emp.Name} | Chi phi nam: {emp.AnnualCost:N0} USD");
            Console.WriteLine($"Phong ban: {dept.Name} | Chi phi nam: {dept.AnnualCost:N0} USD");

            Console.ReadKey();
        }
    }
}