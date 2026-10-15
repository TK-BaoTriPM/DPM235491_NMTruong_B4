using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_SimpMeth_ReplaceExceptionWithTest_Before
{
    public class ResourcePool
    {
        private Stack<string> _availableResources = new Stack<string>();

        // CODE SMELL: Lạm dụng Exception bắt InvalidOperationException khi Stack rỗng
        public string GetResource()
        {
            try
            {
                string result = _availableResources.Pop();
                return result;
            }
            catch (InvalidOperationException)
            {
                // Thay vì kiểm tra trước, lại cố tình dùng catch để tạo tài nguyên mới
                string newResource = "Resource_" + Guid.NewGuid().ToString().Substring(0, 4);
                return newResource;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Exception with Test ===");

            ResourcePool pool = new ResourcePool();

            // Lấy tài nguyên khi pool rỗng sẽ gây ra Exception ngầm
            string res1 = pool.GetResource();
            Console.WriteLine($"Tai nguyen cap phat: {res1}");

            Console.ReadKey();
        }
    }
}