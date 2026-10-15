using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceExceptionWithTest_After
{
    public class ResourcePool
    {
        private Stack<string> _availableResources = new Stack<string>();

        // REFACTORED: Kiểm tra số lượng phần tử trước bằng câu lệnh if (Test condition)
        public string GetResource()
        {
            if (_availableResources.Count == 0)
            {
                return "Resource_" + Guid.NewGuid().ToString().Substring(0, 4);
            }

            return _availableResources.Pop();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Exception with Test ===");

            ResourcePool pool = new ResourcePool();

            // Luồng chạy êm ái, không phát sinh Exception
            string res1 = pool.GetResource();
            Console.WriteLine($"Tai nguyen cap phat: {res1}");

            Console.ReadKey();
        }
    }
}