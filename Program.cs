using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------");
                Console.WriteLine("      MENU      ");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Bubble sortik");
                Console.WriteLine("2. Quick sortik");
                Console.WriteLine("===========");
                Console.Write("Vaše volba: ");
            
                int menu;
                while (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 2)
                {
                    Console.Write("Vaše volba: ");
                }
            

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Helpers.BubbleSort();
                        break;
                    case 2:
                        break;
                }
            }
            
        }
    }

    class Helpers
    {
        public static void BubbleSort()
        {
            Console.WriteLine("--- Bubble sort ---");
            List<int> array = GetFileNumbers();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < (array.Count - i - 1); j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                } 
            }
            stopWatch.Stop();
            
            Console.WriteLine();
            Console.WriteLine("Seřazené pole: ");
            foreach (var item in array)
            {
                Console.Write(item + "; ");
            }
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            Console.WriteLine("Čas: " + ts);
            Console.Read();
        }

        public static List<int> GetFileNumbers()
        {
            Console.Write("Zadejte cestu k souboru: ");
            bool check = false;
            string path = null;
            while (check == false)
            {
                path = Console.ReadLine();
                if (File.Exists(path))
                {
                    check = true;
                    break;
                }
                else
                {
                    Console.Write("Zadejte cestu k souboru: ");
                }
            }
            
            string[] rows = File.ReadAllLines(path);
            
            Console.Clear();
            Console.WriteLine("--- Bubble sort ---");
            Console.WriteLine("Originální pole: ");
            foreach (var item in rows)
            {
                Console.Write(item + "; ");
            }
            List<int> result = new List<int>();
            foreach (var item in rows)
            {
                if (int.TryParse(item, out int a))
                {
                    result.Add(a);
                }
            }

            return result;
        }
    }
}
