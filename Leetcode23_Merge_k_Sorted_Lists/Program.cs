using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode23_Merge_k_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode[] list = {
                                  new ListNode(1, new ListNode(4, new ListNode(5))),
                                  new ListNode(1, new ListNode(3, new ListNode(4))),
                                  new ListNode(2, new ListNode(6))
                              };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = MergeKLists(list);
            Console.WriteLine(stopwatch.Elapsed.ToString("c"));

            PrintResult(result);

            Console.ReadLine();
        }
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
            {
                return null;
            }

            List<int> tmp = new List<int>();
            foreach (var item in lists)
            {
                CheckNextValue(tmp, item);
            }
            return GetResult(tmp.OrderByDescending(o => o).ToList());
        }
        private static void CheckNextValue(List<int> tmp, ListNode item)
        {
            if (item == null)
                return;

            tmp.Add(item.val);

            if (item.next != null)
            {
                CheckNextValue(tmp, item.next);
            }
        }
        private static ListNode GetResult(List<int> tmp)
        {
            List<ListNode> result = new List<ListNode>();
            tmp.ForEach(f =>
            {
                result.Add(new ListNode(f));
            });

            return tmp.Count > 0 ? result.Aggregate((x, y) => new ListNode(y.val, x)) : null;
        }

        private static void PrintResult(ListNode result)
        {
            if (result == null)
                return;

            Console.WriteLine(result.val);

            if (result.next != null)
            {
                PrintResult(result.next);
            }
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
