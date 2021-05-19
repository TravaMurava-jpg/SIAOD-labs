using System;
using System.Diagnostics;
using System.Linq;
using Lab2.Folder;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            int SizeMyArray = 11;
            int[] MyArray = new int[SizeMyArray];
            MyArray[SizeMyArray - 2] = 4965;
            MyArray[SizeMyArray - 1] = 1000;
            Random rn = new Random();
            for (int i = 0; i < SizeMyArray - 2; i++)
            {
                MyArray[i] = rn.Next(100, 5000);
            }

            Console.WriteLine("Задание №1" + "\r\n");
            PrintArray(MyArray);
            Console.WriteLine("\r\n" + "1.Интерпаляционный поиск");
            Console.WriteLine("Индекс числа 4965 = " + InterpolationSearch(MyArray, 4965) + "\r\n");
            Console.WriteLine("\r\n" + "2.Нахождение индекса элемента 4965 с помощью бинарного поиска: " + BinarySearch(MyArray, 4965, 0, MyArray.Length - 1));
            var binaryTree = new BinaryTree();
            Random rand = new Random();
            for (int i = 0; i < 9; i++)
            {
                binaryTree.Add(new BinaryTreeNode(rand.Next(0, 50)));
            }
            Console.WriteLine("\r\n" + "3.Бинарное дерево");
            binaryTree.PrintTree();
            Console.WriteLine("Добавим новый элемент");
            binaryTree.Add(new BinaryTreeNode(66));
            binaryTree.PrintTree();
            binaryTree.FindNode(66);
            Console.WriteLine("Удалим его");
            binaryTree.Remove(66);
            binaryTree.PrintTree();
            Console.WriteLine("\r\n" + "4.Фиббоначиев поиск" + "\r\n");
            PrintArray(MyArray);
            Console.WriteLine("Найдено ли число 4965 = " + FibbonachiSearch2(MyArray, 4965, MyArray.Length));

            Console.WriteLine("\r\n" + "Задание №2" + "\r\n");
            Console.WriteLine("1.Поиск по map, в которой коллизии решаются простым рехэшированием");
            Map<int, string> MyMap = new Map<int, string>();
            MyMap.Add(new ItemMap<int, string>(1, "Один"));
            MyMap.Add(new ItemMap<int, string>(1, "Один"));
            MyMap.Add(new ItemMap<int, string>(2, "Два"));
            MyMap.Add(new ItemMap<int, string>(3, "Три"));
            MyMap.Add(new ItemMap<int, string>(4, "Четыре"));
            MyMap.Add(new ItemMap<int, string>(5, "Пять"));
            MyMap.Add(new ItemMap<int, string>(101, "Сто один"));
            Console.WriteLine("Исходная карта:");
            foreach (var item in MyMap)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n" + "Ищем число c ключем 7 " + (MyMap.Search(7) ?? "Не найдено"));
            Console.WriteLine("Ищем число c ключем 101 " + (MyMap.Search(101) ?? "Не найдено"));
            MyMap.Remove(1);
            MyMap.Remove(101);
            Console.WriteLine("\r\n" + "Удалили 1 и 101 ");
            foreach (var item in MyMap)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\n" + "2.Поиск по map, в которой коллизии решаются случайным рехэшированием");
            Map<int, string> MyMap2 = new Map<int, string>();
            MyMap2.Add(new ItemMap<int, string>(2, "Два"));
            MyMap2.Add(new ItemMap<int, string>(2, "Два"));
            MyMap2.Add(new ItemMap<int, string>(9, "Девять"));
            MyMap2.Add(new ItemMap<int, string>(3, "Три"));
            MyMap2.Add(new ItemMap<int, string>(4, "Четыре"));
            MyMap2.Add(new ItemMap<int, string>(5, "Пять"));
            MyMap2.Add(new ItemMap<int, string>(102, "Сто два"));
            Console.WriteLine("Исходная карта:");
            foreach (var item in MyMap2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n" + "Ищем число c ключем 7 " + (MyMap2.Search(7) ?? "Не найдено"));
            Console.WriteLine("Ищем число c ключем 102 " + (MyMap2.Search(102) ?? "Не найдено"));
            MyMap2.Remove(2);
            MyMap2.Remove(102);
            Console.WriteLine("\r\n" + "Удалили 2 и 102 ");
            foreach (var item in MyMap2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\n" + "3.Поиск по хэш таблице, в которой коллизии решаются методом цепочек");
            Console.WriteLine("Исходная таблица:");
            HashTable<int> MyHashTable = new HashTable<int>(5);
            MyHashTable.Add(2);
            MyHashTable.Add(24);
            MyHashTable.Add(65);
            MyHashTable.Add(8);
            MyHashTable.Add(51);
            MyHashTable.Add(61);
            MyHashTable.PrintHashTable();
            Console.WriteLine("\r\n" + "Содержит ли хэш таблица число 42 " + MyHashTable.Search(42));
            Console.WriteLine("Содержит ли хэш таблица число 8 " + MyHashTable.Search(8));
            MyHashTable.Delate(24);
            MyHashTable.Delate(51);
            Console.WriteLine("\r\n" + "Удалили 24 и 51 ");
            MyHashTable.PrintHashTable();

            Console.WriteLine("\r\n" + "Задание №3");
            Console.WriteLine("Расстановка ферзей на поле : (ферзь = 1)" + "\r\n");
            Chess MyChess = new Chess();
            MyChess.Arrange();


            Console.ReadLine();

        }

        static void PrintArray(int[] MyArray)
        {
            Console.Write("Исходный массив: ");
            for (int i = 0; i < MyArray.Length; i++)
            {
                Console.Write(MyArray[i] + " ");
            }
        }

        //БИНАРНЫЙ ПОИСК O(logn)
        static int BinarySearch(int[] array, int searchedValue, int left, int right)
        {
            Array.Sort(array);
            PrintArray(array);
            Stopwatch timer = Stopwatch.StartNew();
            //пока не сошлись границы массива
            while (left <= right)
            {
                //индекс среднего элемента
                var middle = (left + right) / 2;

                if (searchedValue == array[middle])
                {
                    timer.Stop();
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    //сужаем рабочую зону массива с правой стороны
                    right = middle - 1;
                }
                else
                {
                    //сужаем рабочую зону массива с левой стороны
                    left = middle + 1;
                }
            }
            //ничего не нашли
            return -1;
        }

        //ИНТЕРПАЛЯЦИОННЫЙ ПОИСК O(loglogn)
        public static int InterpolationSearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;
            return InterpolationSearch(array, value, ref low, ref high);
        }

        private static int InterpolationSearch(int[] array, int value, ref int low, ref int high)
        {
            int index = -1;

            if (low <= high)
            {
                index = (int)(low + (((int)(high - low) / (array[high] - array[low])) * (value - array[low])));
                if (array[index] == value)
                {
                    return index;
                }
                else
                {
                    if (array[index] < value)
                        low = index + 1;
                    else
                        high = index - 1;
                }

                return InterpolationSearch(array, value, ref low, ref high);
            }

            return index;
        }


        private static bool FibbonachiSearch2(int[] arr, int x, int n)
        {
            int fibMMm2 = 0;
            int fibMMm1 = 1;
            int fibM = fibMMm2 + fibMMm1;


            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            int offset = -1;

            while (fibM > 1)
            {
                int i = Math.Min(offset + fibMMm2, n - 1);

                if (arr[i] < x)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                }

                else if (arr[i] > x)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                }

                else
                    return true;
            }

            if (fibMMm1 == 1 && arr[n - 1] == x)
                return true;

            return false;
        }
    }
}