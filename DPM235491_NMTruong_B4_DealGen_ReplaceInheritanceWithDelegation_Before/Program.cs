using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_DealGen_ReplaceInheritanceWithDelegation_Before
{
    // CODE SMELL: MyStack kế thừa trực tiếp từ List<T>
    // Điều này làm MyStack lộ ra các phương thức không thuộc về Stack như Insert(index), RemoveAt(index), Sort(), ...
    public class MyStack<T> : List<T>
    {
        public void Push(T item)
        {
            Add(item);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack rông!");

            T item = this[Count - 1];
            RemoveAt(Count - 1);
            return item;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE REFACTORING: Replace Inheritance with Delegation ===");

            MyStack<string> stack = new MyStack<string>();
            stack.Push("Phan tu 1");
            stack.Push("Phan tu 2");

            // NGUY HẠI: Người dùng có thể chèn vào giữa danh sách hoặc xóa sai vị trí
            // vì MyStack thừa hưởng toàn bộ hàm của List<T>
            stack.Insert(0, "Phan tu chen sai quy tac Stack");

            foreach (var item in stack)
            {
                Console.WriteLine($"Item: {item}");
            }

            Console.ReadKey();
        }
    }
}