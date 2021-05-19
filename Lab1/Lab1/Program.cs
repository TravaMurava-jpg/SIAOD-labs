using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            vivod();
            Console.ReadLine();
        }
        static void vivod()
        {
            //Выбор сортировки
            Console.Write("Выберите сортировку:" + "\r\n");
            Console.Write("1 - Турнирная сортировка" + "\r\n" + "2 - Сортировка вставками" + "\r\n" + "3 - Сортировка обменом" + "\r\n" + "4 - Сортировка Шелла" + "\r\n" + "5 - Сортировка быстрая" + "\r\n" + "6 - Сортировка встроенная" + "\r\n" + "7 - Сортировка пирамидальная" + "\r\n" + "8 - Сортировка выбором" + "\r\n" + "Press the number on your keyboard:");
            //Генерация матрицы
            int[,] FirstMatrix = CreateMatrix();
            Stopwatch timer = null;

            //Осуществление выбранной сортировки
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 7:
                    timer = Stopwatch.StartNew();
                    ChoiceSort(FirstMatrix);
                    timer.Stop();
                    break;
                case 2:
                    timer = Stopwatch.StartNew();
                    InsertsSort(FirstMatrix);
                    timer.Stop();
                    break;
                case 3:
                    timer = Stopwatch.StartNew();
                    ExchangeSort(FirstMatrix);                  
                    break;
                case 4:
                    timer = Stopwatch.StartNew();
                    ShellaSort(FirstMatrix);
                    timer.Stop();
                    break;
                case 5:
                    timer = Stopwatch.StartNew();
                    for (int k = 0; k < MatrixSize; k++)
                    {
                        QuickSort(FirstMatrix, 0, MatrixSize - 1, k);
                    }
                    timer.Stop();
                    break;
                case 6:
                    timer = Stopwatch.StartNew();
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        
                        int[] MyArray = new int[MatrixSize];
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            MyArray[j] = FirstMatrix[i, j];
                        }
                        Array.Sort(MyArray);
                        
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            FirstMatrix[i, j] = MyArray[j];
                        }
                    }
                    timer.Stop();
                    break;
                case 8:
                    timer = Stopwatch.StartNew();
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        
                        int[] MyArray = new int[MatrixSize];
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            MyArray[j] = FirstMatrix[i, j];
                        }
                        TornSort(ref MyArray);
                       
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            FirstMatrix[i, j] = MyArray[j];
                        }
                    }
                    timer.Stop();
                    break;
                case 1:
                    timer = Stopwatch.StartNew();
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        List<int> array = new List<int>(MatrixSize);
                        for (int j = 0; j < MatrixSize; j++)
                        {
                            array.Add(FirstMatrix[i, j]);
                        }
                        Piramida MyPiramida = new Piramida(array);
                        foreach (int a in MyPiramida)
                        {
                            Console.Write(a + " ");
                        }
                        Console.Write("\r\n");
                    }
                    timer.Stop();
                    return;
                                }

            //Вывод времени сортировки
            Console.WriteLine("Время сортировки: " + Convert.ToString(timer.ElapsedMilliseconds) + " мс");

            //Вывод отсортированной матрицы
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Console.Write(Convert.ToString(FirstMatrix[i, j] + " "));
                }
                Console.Write("\r\n");
            }
            
            Console.ReadLine();
        }



        static int MatrixSize = 5;
        #region Генерация матрицы
        static int[,] CreateMatrix()
        {
            int[,] Matrix = new int[MatrixSize, MatrixSize];
            Random rand = new Random();
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Matrix[i, j] = rand.Next(-100, 100);
                }
            }
            return Matrix;
        }
        #endregion
        #region Cортировки
        static void ChoiceSort(int[,] ListForSort)
        {
            for (int k = 0; k < MatrixSize; k++)
            {
                int index = 0;

                for (int i = 0; i < MatrixSize - 1; i++)
                {
                    index = i;

                    for (int j = i + 1; j < MatrixSize; j++)
                    {
                        if (ListForSort[k, j].CompareTo(ListForSort[k, index]) == -1)
                        {
                            index = j;
                        }
                    }

                    if (index != i)
                    {
                        int temp = ListForSort[k, i];
                        ListForSort[k, i] = ListForSort[k, index];
                        ListForSort[k, index] = temp;
                    }
                }
            }
        }


        static void InsertsSort(int[,] ListForSort)
        {

            for (int k = 0; k < MatrixSize; k++)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    var temp = ListForSort[k, i];
                    var j = i;
                    while (j > 0 && temp.CompareTo(ListForSort[k, j - 1]) == -1)
                    {
                        ListForSort[k, j] = ListForSort[k, j - 1];
                        j--;
                    }
                    ListForSort[k, j] = temp;
                }

            }
        }

        static
        void ExchangeSort(int[,] ListForSort)
        {

            for (int k = 0; k < MatrixSize; k++)
            {
                int count = MatrixSize -1;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < count - 1 - j; i++)
                    {
                        var a = ListForSort[k, i];
                        var b = ListForSort[k, i + 1];
                        if (a.CompareTo(b) == 1)
                        {
                            int temp = ListForSort[k, i];
                            ListForSort[k, i] = ListForSort[k, i + 1];
                            ListForSort[k, i + 1] = temp;
                        }

                    }
                    count--;
                }

            }
        }

        static void ShellaSort(int[,] ListForSort)
        {

            for (int k = 0; k < MatrixSize; k++)
            {
                int step = MatrixSize;

                while (step > 0)
                {
                    for (int i = step; i < MatrixSize; i++)
                    {
                        int j = i;
                        while (j >= step && ListForSort[k, j - step].CompareTo(ListForSort[k, j]) == 1)
                        {
                            int temp = ListForSort[k, j - step];
                            ListForSort[k, j - step] = ListForSort[k, j];
                            ListForSort[k, j] = temp;
                            j -= step;
                        }
                    }
                    step /= 2;
                }
            }
        }

        static void QuickSort(int[,] ListForSort, int left, int right, int k)
        {
            if (left >= right) { return; }
            else
            {
                var sorts = Sorting(ListForSort, left, right, k);
                QuickSort(ListForSort, left, sorts - 1, k);
                QuickSort(ListForSort, sorts + 1, right, k);
            }
        }

        static int Sorting(int[,] ListForSort, int left, int right, int k)
        {
            var pointer = left;
            for (int i = left; i <= right; i++)
            {
                if (ListForSort[k, i].CompareTo(ListForSort[k, right]) == -1)
                {
                    int temp1 = ListForSort[k, i];
                    ListForSort[k, i] = ListForSort[k, pointer];
                    ListForSort[k, pointer] = temp1;
                    pointer++;
                }
            }

            int temp = ListForSort[k, right];
            ListForSort[k, right] = ListForSort[k, pointer];
            ListForSort[k, pointer] = temp;

            return pointer;
        }



        static int[] Piramidaify(ref int[] arr, int n, int k)
        {
            int m = k;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left < n && arr[m] < arr[left])
            {
                m = left;
            }
            if (right < n && arr[m] < arr[right])
            {
                m = right;
            }
            if (m != k)
            {
                int temp = arr[k];
                arr[k] = arr[m];
                arr[m] = temp;
                Piramidaify(ref arr, n, m);
            }
            return arr;
        }

        static int[] TornSort(ref int[] arr)
        {
            for (int i = arr.Length / 2; i > -1; i--)
            {
                Piramidaify(ref arr, arr.Length, i);
            }
            for (int i = arr.Length - 1; i > -1; i--)
            {
                if (arr[0] > arr[i])
                {
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                    Piramidaify(ref arr, i, 0);
                }
            }
            return arr;
        }


        #endregion
    }
}