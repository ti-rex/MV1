using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearch
{
    class Program
    {
        public class Node
            {
                public Node (int value)
            {
                Value = value;
            }
                public int Value { get; set; }
                public Node Next { get; set; }
            }

        public class OneList : IEnumerable
        {
            Node head;
            Node tail;
            int count;

            public void Add(int value)
            {
                Node node = new Node(value);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;

                tail = node;
                count++;
            }

            public bool Contains(int value)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                        return true;
                    current = current.Next;
                }
                return false;
            }

            public int Count()
            {
                Node current = head;
                int Counts = 0;
                while (current != null)
                {
                    Counts++;
                    current = current.Next;
                }
                return Counts;
            }

            public int Element(int number)
            {
                Node current = head;
                for (int i = 1; i < number; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                Node current = head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }

        }

        static int BinSearch(OneList List, int key)
        {
            int left = 0;
            int mid = 0;
            int right = List.Count();
            int num = 0;
            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (List.Element(mid) == key)
                    return num;
                if (List.Element(mid) > key)
                {
                    right = mid;
                    num++;
                }
                else
                { left = mid;
                    num++;
                }

            }
            return -(1 + left);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word");
            int n = 10000;
            Random rnd = new Random();
            int search = rnd.Next(0, n);
            List<int> List = new List<int>();
            OneList List1 = new OneList();
            for (int i = 1; i<=n; i++)
            {
                List.Add(i);
                List1.Add(i);
                //Console.Write(List1 + " ");
            }
            foreach (int item in List1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("List statistic:\n");
            Console.WriteLine("Search key: " + search);
            Console.WriteLine("\nLinear Search:\n");
            Stopwatch bsw = Stopwatch.StartNew();
            int bfound = List1.Element(search);
            bsw.Stop();
            Console.WriteLine("Found key: " + List1.Element(search));
            Console.WriteLine("Elapsed time : " + bsw.Elapsed);
            Console.WriteLine("\nBinary Search:\n");
            Stopwatch sw = Stopwatch.StartNew();
            int found = BinSearch(List1, search);
            sw.Stop();
            Console.WriteLine("Found key: " + List1.Element(search));
            Console.WriteLine("Elapsed time : " + sw.Elapsed);
            Console.WriteLine("Steps : " + BinSearch(List1, search));
            //Console.WriteLine(List1.Element(26));

            Console.WriteLine("\nPress any key to Exit");
            Console.ReadKey();
        }
    }
}
