using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulz
{
    class Program
    {
        public static int[][] Pairs(int[][] B, int n)
        {
            int[][] arr = new int[n][];
            for (int i =0; i<n;i++)
            {
                arr[i] = new int[n];
                for (int j = 0; j<n; j++)
                {
                    arr[i][j] = 0;
                }
            }
            for (int i = 0; i<B.Length; i++)
            {
                int[] elem = B[i];
                for (int j = 0; j<elem.Length;j++)
                {
                    int a1 = elem[j];
                    for (int k = j+1; k<elem.Length;k++)
                    {
                        int a2 = elem[k];
                        arr[a1][a2]++;
                    }
                }
            }
            return arr;
        }

        public static Tuple<int[][], int[][]> PowerWays(int[][] arr, int n)
        {
            int[][] arr2 = new int[n][];
            int[][] parr = new int[n][];
            for (int i =0; i<n;i++)
            {
                arr2[i] = new int[n];
                parr[i] = new int[n];
                for (int j =0;j<n;j++)
                {
                    if (arr[i][j] > arr[j][i])
                    {
                        arr2[i][j] = arr[i][j] - arr[j][i];
                        parr[i][j] = i;
                    }
                    else
                    {
                        arr2[i][j] = -1;
                        parr[i][j] = -1;
                    }
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j != i)
                            {
                                if (arr2[i][j] < Math.Min(arr2[i][k], arr2[k][j]))
                                {
                                    arr2[i][j] = Math.Min(arr2[i][k], arr2[k][j]);
                                    parr[i][j] = parr[k][j];
                                }
                            }
                        }
                    }
                }
            }
            return new Tuple<int[][], int[][]>(arr2,parr);
        }

        public static string ListToString(List<List<int>> thing)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var li in thing)
            {
                sb.Append("[" + string.Join<int>(", ", li) + "] ");
            }
            sb.Append("] ");
            return sb.ToString();
        }

        public static List<List<int>> Results(int[][] arr, int n)
        {
            List<List<int>> wins = new List<List<int>>();
            for (int i =0;i<n;i++)
            {
                List<int> list = new List<int>();
                wins.Add(list);
                for (int j =0; j<n;j++)
                {
                    if (i != j)
                    {
                        if (arr[i][j]>arr[j][i])
                        {
                            list.Add(j);
                        }
                    }
                }
            }
            return wins;
        }

        static void Main(string[] args)
        {
            int[][] B = new int[21][] { new int[]{ 0, 2, 3, 1}, new int[]{ 0, 2, 3, 1},new int[]{ 0, 2, 3, 1},new int[]{ 0, 2, 3, 1},new int[]{ 0, 2, 3, 1},new int[]{ 0, 2, 3, 1},
            new int[]{ 1, 0, 3, 2},new int[]{ 1, 0, 3, 2},new int[]{ 1, 0, 3, 2},new int[]{ 1, 0, 3, 2},
            new int[]{ 2, 3, 1, 0},new int[]{ 2, 3, 1, 0},new int[]{ 2, 3, 1, 0},
            new int[]{ 3, 1, 0, 2},new int[]{ 3, 1, 0, 2},new int[]{ 3, 1, 0, 2},new int[]{ 3, 1, 0, 2},
            new int[]{ 3, 2, 1, 0},new int[]{ 3, 2, 1, 0},new int[]{ 3, 2, 1, 0},new int[]{ 3, 2, 1, 0}};

            int[][] arr = Pairs(B, 4);
            Tuple<int[][], int[][]> Pair = PowerWays(arr, 4);
            int[][] arr2 = Pair.Item1;
            List<List<int>> win = Results(arr2, 4);
            
            Console.WriteLine("Алгоритм системы голосования по методу Шульца:");
            Console.WriteLine("A - 0, B - 1, C - 2, D -3\n");
            Console.WriteLine("Массив попарных сравнений предпочтений кандидатов:");
            for (int i =0;i<4;i++)
            {
                Console.WriteLine(" ");
                for (int j=0;j<4;j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Карта сильнейших путей графа выборов:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(arr2[i][j] + " ");
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Winners: ");
            Console.WriteLine(ListToString(win));
            Console.ReadKey();
        }
    }
}
