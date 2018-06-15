using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static public void SelectionSort(int[] arr)
        {
            int min;
            int temp;
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        static public int Factor(int n)
        {
            if (n > 1)
            {
                n = n * Factor(n - 1);
            }
            return n;
        }

        static public void InsertSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public class InsertionSort
        {
            public static LinkedList<T> Sort<T>(LinkedList<T> list) where T : IComparable<T>
            {
                LinkedListNode<T> item = list.First;
                LinkedList<T> slist = new LinkedList<T>();
                while (item != null)
                {
                    LinkedListNode<T> some = slist.Last;
                    while (true)
                    {
                        if (some == null)
                        {
                            slist.AddFirst(new LinkedListNode<T>(item.Value));
                            break;
                        }
                        if (some.Value.CompareTo(item.Value) < 0)
                        {
                            slist.AddAfter(some, new LinkedListNode<T>(item.Value));
                            break;
                        }
                        some = some.Previous;
                    }
                    item = item.Next;
                }
                return slist;
            }
        }

        static public void BucketSort(int[] arr)
        {
            int maxV = arr[0];
            int minV = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxV)
                    maxV = arr[i];

                if (arr[i] < minV)
                    minV = arr[i];
            }

            List<int>[] bucket = new List<int>[maxV - minV + 1];
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - minV].Add(arr[i]);
            }

            int p = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arr[p] = bucket[i][j];
                        p++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            long i1 = Environment.WorkingSet;
            int fi = 4;
            long i3 = GC.GetTotalMemory(true);
            Int32[] m = new Int32[100000000];
            int[] arr = new int[4] { 156, 215, 318, 50 };
            int[] arr2 = new int[4] { 156, 215, 318, 50 };
            long i4 = GC.GetTotalMemory(true);
            long i2 = Environment.WorkingSet;
            long raz = i2 - i1;
            long raz2 = i4 - i3;
            int arrsize = 20;
            Random rnd = new Random();

            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < arrsize; i++)
            {
                list.AddFirst(rnd.Next(0, arrsize));
            }
            //InsertSort_list(list);

            //Console.WriteLine("Origin array:" + list.ToString());
            Console.WriteLine("\n");
            Console.WriteLine("Origin array:");
            int[] rndarr = new int[arrsize];
            for (int i = 0; i < arrsize; i++)
            {
                rndarr[i] = rnd.Next(0, arrsize);
                Console.Write(rndarr[i] + " ");
            }
            int[] rndarr1 = rndarr;
            int[] rndarr2 = rndarr;
            int[] rndarr3 = rndarr;
            Stopwatch sw1 = Stopwatch.StartNew();
            SelectionSort(rndarr1);
            sw1.Stop();
            Stopwatch sw2 = Stopwatch.StartNew();
            InsertSort(rndarr2);
            sw2.Stop();
            Stopwatch sw4 = Stopwatch.StartNew();
            var sortedList = InsertionSort.Sort<int>(list);
            sw4.Stop();
            Stopwatch sw3 = Stopwatch.StartNew();
            BucketSort(rndarr3);
            sw3.Stop();
            //Console.WriteLine(i1);
            //Console.WriteLine(i2);
            //Console.WriteLine(raz);
            //Console.WriteLine(raz2);

            Console.WriteLine("\n");
            Console.WriteLine("Selection Sort:");
            for (int i = 0; i < arrsize; i++)
            {
                Console.Write(rndarr1[i] + " ");
            }
            Console.WriteLine("\nTime Elapsed: " + sw1.Elapsed);
            Console.WriteLine("\n");

            Console.WriteLine("Insert Sort:");
            for (int i = 0; i < arrsize; i++)
            {
                Console.Write(rndarr2[i] + " ");
            }
            Console.WriteLine("\nTime Elapsed: " + sw2.Elapsed);
            Console.WriteLine("\n");

            Console.WriteLine("Bucket Sort:");
            for (int i = 0; i < arrsize; i++)
            {
                Console.Write(rndarr3[i] + " ");
            }
            Console.WriteLine("\nTime Elapsed: " + sw3.Elapsed);
            Console.WriteLine("\n");

            Console.WriteLine("Origin list:");
            LinkedListNode<int> node;
            for (node = list.First; node != null; node = node.Next)
                Console.Write(node.Value + " ");
            Console.WriteLine("\n");

            Console.WriteLine("Insert Sort by linked list:");
            LinkedListNode<int> node2;
            for (node2 = sortedList.First; node2 != null; node2 = node2.Next)
                Console.Write(node2.Value + " ");
            Console.WriteLine("\nTime Elapsed: " + sw4.Elapsed);
            Console.WriteLine("\n");

            Console.WriteLine("Factorial from " + fi + " = " + Factor(fi));
            Console.ReadKey();
        }
    }
}
