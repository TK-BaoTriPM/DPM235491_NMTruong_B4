using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceInheritanceWithDelegation_After
{
    // REFACTORED: Chuyển quan hệ kế thừa thành quan hệ ủy quyền (Delegation)
    public class MyStack<T>
    {
        // Sử dụng List<T> như một trường nội bộ thay vì kế thừa
        private readonly List<T> _underlyingList = new List<T>();

        public void Push(T item)
        {
            _underlyingList.Add(item); // Ủy quyền cho List
        }

        public T Pop()
        {
            if (_underlyingList.Count == 0)
                throw new InvalidOperationException("Stack rông!");

            T item = _underlyingList[_underlyingList.Count - 1];
            _underlyingList.RemoveAt(_underlyingList.Count - 1);
            return item;
        }

        public int Count => _underlyingList.Count;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== AFTER REFACTORING: Replace Inheritance with Delegation ===");

            MyStack<string> stack = new MyStack<string>();
            stack.Push("Phan tu 1");
            stack.Push("Phan tu 2");

            Console.WriteLine($"Lay ra: {stack.Pop()}");
            Console.WriteLine($"So phan tu con lai: {stack.Count}");

            // stack.Insert(0, "..."); // LỖI BIÊN DỊCH: Không còn vi phạm đóng gói quy tắc Stack nữa!

            Console.ReadKey();
        }
    }
}